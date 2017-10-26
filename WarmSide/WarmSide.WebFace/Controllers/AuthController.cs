using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using WarmSide.WebFace.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using WarmSide.WebFace.Interfaces;
using System.IdentityModel.Services;
using System.Xml;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Selectors;
using System.Security.Cryptography.X509Certificates;


namespace WarmSide.WebFace.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserManager _userManager;

        public AuthController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Title = "Warm Side Weather Project - Login";
            return View();
        }

        public ActionResult LoginViaSTS()
        {
            SignInRequestMessage message = new SignInRequestMessage(
                new Uri("http://localhost:56020/Auth/SignIn/"),
                "http://WarmSideWebPortal", "http://localhost:50793//Auth/SignIn");

            HttpContext.Response.Redirect(message.WriteQueryString());

            return View("Login");
        }

        public ActionResult LoginViaGoogle()
        {
            return new ChallengeResult("Google", Url.Action("ExternalLoginCallback", "Auth", new { ReturnUrl = "/Home/Index" }));
        }

        public ActionResult SignIn()
        {
            if (Request.Unvalidated.Form[WSFederationConstants.Parameters.Result] != null)
            {
                SignInResponseMessage mess = WSFederationMessage.CreateFromNameValueCollection(
                                    WSFederationMessage.GetBaseUrl(Request.Url),
                                    Request.Unvalidated.Form) as SignInResponseMessage;

                string tokenResponseCollectionXml = mess.Result;

                XmlDocument samlXml = new XmlDocument();
                samlXml.LoadXml(tokenResponseCollectionXml);

                string samlTokenXml = samlXml
                            .DocumentElement  // <trust:RequestSecurityTokenResponseCollection>
                            .ChildNodes[0] // <trust:RequestSecurityTokenResponse>
                            .ChildNodes[2] // <trust:RequestedSecurityToken>
                            .InnerXml; // <Assertion>

                var c = System.IdentityModel.Services.FederatedAuthentication.FederationConfiguration;
                c.IdentityConfiguration.AudienceRestriction.AllowedAudienceUris.Add(new Uri("http://localhost:50793/"));
                SecurityTokenHandlerCollection collection = SecurityTokenHandlerCollection.CreateDefaultSecurityTokenHandlerCollection();

                // Create the service token resolver from the service certificate.
                List<SecurityToken> serviceTokens = new List<SecurityToken>();
                // This service certificate is considered to have been defined elsewhere
                var serviceCertificate = GetCertificate(StoreName.My, StoreLocation.LocalMachine, "CN=www.warmside.com");
                serviceTokens.Add(new X509SecurityToken(serviceCertificate));
                SecurityTokenResolver serviceResolver = SecurityTokenResolver.CreateDefaultSecurityTokenResolver(serviceTokens.AsReadOnly(), false);
                collection.Configuration.ServiceTokenResolver = serviceResolver;

                // Create an issuer token resolver that consults the trusted people store.
                X509CertificateStoreTokenResolver certificateStoreIssuerResolver = new X509CertificateStoreTokenResolver(StoreName.My, StoreLocation.LocalMachine);
                collection.Configuration.IssuerTokenResolver = certificateStoreIssuerResolver;
                var token2 = collection.ReadToken(new XmlTextReader(new StringReader(samlTokenXml)));
                var identity = collection.ValidateToken(token2).First();


                //  var handlers = FederatedAuthentication.FederationConfiguration.IdentityConfiguration.SecurityTokenHandlers;

                var sessionToken = new SessionSecurityToken(new ClaimsPrincipal(identity),
                                                            TimeSpan.FromMinutes(20));

                FederatedAuthentication.SessionAuthenticationModule.WriteSessionTokenToCookie(sessionToken);


                var xmlTextReader = new XmlTextReader(new StringReader(samlTokenXml));

                //var id = (from c in claims.Claims where c.Type == ClaimTypes.NameIdentifier select c.Value).FirstOrDefault();
                //var identity = new ClaimsIdentity("Application Cookie");
                //identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, id));
                //Request.GetOwinContext().Authentication.SignIn(identity);

                return RedirectToAction("Index", "Home");
            }


            return RedirectToAction("Login", "Auth");
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index", "Home", null);
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }

        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var currentUser = (ClaimsPrincipal)Request.GetOwinContext().Request.User;

            var userDbProfile = await UserInfoHelpers.GetUserDbProfile(currentUser, _userManager);

            if (userDbProfile == null)
            {
                string userEmail = UserInfoHelpers.GetUserClaim(ClaimTypes.Email, currentUser);
                string userId = UserInfoHelpers.GetUserClaim(ClaimTypes.NameIdentifier, currentUser);

                var user = new User() { UserID = userId, Email = userEmail, FavoriteCity = "New York", IsGoogle = true, Password = ""};

                bool result = await _userManager.AddUser(user);

                if (!result)
                {
                    return new HttpStatusCodeResult(500);
                }
            }

            return RedirectToAction("Index", "Home");
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

        public class MyX509CertificateValidator : X509CertificateValidator
        {
            string allowedIssuerName;
            public MyX509CertificateValidator()
            {
           
            }
            public override void Validate(X509Certificate2 certificate)
            {
            
            }
        }
    }
}