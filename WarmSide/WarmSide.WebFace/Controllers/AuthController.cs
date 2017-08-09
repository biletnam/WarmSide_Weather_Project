using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using WarmSide.WebFace.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WarmSide.WebFace.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Title = "Warm Side Weather Project - Login";
            return View();
        }
        [HttpPost]
        public ActionResult Login(AuthViewModel model)
        {
            ViewBag.Title = "Warm Side Weather Project - Login";
            return View();
        }

        public ActionResult LoginViaGoogle()
        {
            return new ChallengeResult("Google", Url.Action("ExternalLoginCallback", "Auth", new { ReturnUrl = "/Home/Index" }));
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
            var userManager = new UserManager(@"http://localhost:50798/", new HttpClientFactory());

            var context = (ClaimsPrincipal)Request.GetOwinContext().Request.User;

            string userId = (from c in context.Claims where c.Type == ClaimTypes.NameIdentifier select c.Value).FirstOrDefault();

            var loggedUser = await userManager.FindUserById(userId);

            if (loggedUser == null)
            {
                string userEmail = (from c in context.Claims where c.Type == ClaimTypes.Email select c.Value).FirstOrDefault();
                var user = new User() { UserID = userId, Email = userEmail, FavoriteCity = "New York", IsGoogle = true, Password = ""};

                bool result = await userManager.AddUser(user);

                if (!result)
                {
                    return new HttpStatusCodeResult(500);
                }

                loggedUser = user;
            }

            return RedirectToAction("Index", "Home", loggedUser);
        }
    }
}