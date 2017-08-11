using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using WarmSide.WebFace.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using WarmSide.WebFace.Interfaces;


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
    }
}