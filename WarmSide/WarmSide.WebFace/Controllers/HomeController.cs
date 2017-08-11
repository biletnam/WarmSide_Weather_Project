using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WarmSide.WebFace.Models;
using WarmSide.WebFace.Interfaces;

namespace WarmSide.WebFace.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserManager _userNamager;

        public HomeController(IUserManager userManager)
        {
            _userNamager = userManager;
        }

        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Warm Side Weather Project";

            if (User.Identity.IsAuthenticated)
            {
                var currentUser = (ClaimsPrincipal)Request.GetOwinContext().Request.User;
                var userDbProfile = await UserInfoHelpers.GetUserDbProfile(currentUser, _userNamager);
                ViewBag.FavoriteCity = userDbProfile.FavoriteCity;
            }
            else
            {
                ViewBag.FavoriteCity = "Los Angeles";
            }


            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Settings()
        {
            var currentUser = (ClaimsPrincipal)Request.GetOwinContext().Request.User;
            var userDbProfile = await UserInfoHelpers.GetUserDbProfile(currentUser, _userNamager);

            return View(userDbProfile);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Settings(User user)
        {
            var result = await _userNamager.UpdateUser(user);
            if(result == false)
            {
                ViewBag.Error = "Unable to save settings";
                return View();
            }

            return RedirectToAction("Index");
        }
    }
}