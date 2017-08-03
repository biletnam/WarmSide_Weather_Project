using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using WarmSide.WebFace.Models;

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
            return RedirectToAction("Index", "Home");
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

        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            return RedirectToAction("Index", "Home", new { City = "Khust" });
        }
    }
}