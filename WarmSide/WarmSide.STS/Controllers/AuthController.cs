using System;
using System.IdentityModel;
using System.IdentityModel.Configuration;
using System.IdentityModel.Services;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using WarmSide.STS.Models;
using WarmSide.STS.Interfaces;
using System.ServiceModel.Security;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WarmSide.STS.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Auth
        public async Task<ActionResult> SignIn()
        {
            if (Request.GetOwinContext().Request.User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login");
            }

            string action = Request.QueryString[WSFederationConstants.Parameters.Action];
            string reply = Request.QueryString[WSFederationConstants.Parameters.Reply];

            if (action == WSFederationConstants.Actions.SignIn)
            {
                SignInRequestMessage requestMessage = (SignInRequestMessage)WSFederationMessage.CreateFromUri(Request.Url);

                var config = new SecurityTokenServiceConfiguration(
                "http://WarmSideWebPortal", new X509SigningCredentials(GetCertificate(StoreName.My, StoreLocation.LocalMachine, "CN=www.warmside.com")));
                config.CertificateValidationMode = X509CertificateValidationMode.None;
                config.DefaultTokenType = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV2.0";

                SecurityTokenService sts = new WarmSideSecurityTokenService(config);

                SignInResponseMessage responseMessage =
                    FederatedPassiveSecurityTokenServiceOperations.ProcessSignInRequest(requestMessage, (ClaimsPrincipal)Request.GetOwinContext().Request.User, sts);

                return Content(responseMessage.WriteFormPost());

            }

            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(AuthViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var isValid = await ValidateUser(model);

            if (isValid)
            {
                var user = await _userService.FindUser(model.Username, model.Password);
                var identity = new ClaimsIdentity("Application Cookie");
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserID));

                Request.GetOwinContext().Authentication.SignIn(identity);
                SignInRequestMessage message = new SignInRequestMessage(
               new Uri("http://localhost:56020/Auth/SignIn/"),
               "http://WarmSideWebPortal", "http://localhost:50793//Auth/SignIn");

                HttpContext.Response.Redirect(message.WriteQueryString());

                return RedirectToAction("SignIn");
            }
            else
            {
                return View("InvalidPassword");
            }
        }

        private static X509Certificate2 GetCertificate(StoreName name, StoreLocation location, string subjectName)
        {
            X509Store store = new X509Store(name, location);
            X509Certificate2Collection certificates = null;
            store.Open(OpenFlags.ReadOnly);

            try
            {
                X509Certificate2 result = null;
                certificates = store.Certificates;

                for (int i = 0; i < certificates.Count; i++)
                {
                    X509Certificate2 cert = certificates[i];
                    if (cert.SubjectName.Name.ToLower() == subjectName.ToLower())
                    {
                        if (result != null)
                        {
                            throw new ApplicationException(string.Format("There are multiple certificates for subject Name {0}", subjectName));
                        }

                        result = new X509Certificate2(cert);
                    }
                }

                if (result == null)
                {
                    throw new ApplicationException(string.Format("No certificate was found for subject Name {0}", subjectName));
                }

                return result;
            }
            finally
            {
                if (certificates != null)
                {
                    for (int i = 0; i < certificates.Count; i++)
                    {
                        X509Certificate2 cert = certificates[i];
                        cert.Reset();
                    }
                }

                store.Close();
            }
        }

        private async Task<bool> ValidateUser(AuthViewModel model)
        {
            var user = await _userService.FindUser(model.Username, model.Password);

            if (user == null)
            {
                return false;            
            }

            return true;
        }
    }

}