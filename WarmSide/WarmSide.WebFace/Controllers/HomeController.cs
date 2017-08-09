using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WarmSide.WebFace.Models;

namespace WarmSide.WebFace.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(User user = null)
        {
            ViewBag.Title = "Warm Side Weather Project";

            if (user.UserID == null)
            {
                ViewBag.FavoriteCity = "Los Angeles";
            }
            else
            {
                ViewBag.FavoriteCity = user.FavoriteCity;
            }
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Settings()
        {
            var userManager = new UserManager(@"http://localhost:50798/", new HttpClientFactory());

            var context = (ClaimsPrincipal)Request.GetOwinContext().Request.User;

            string userId = (from c in context.Claims where c.Type == ClaimTypes.NameIdentifier select c.Value).FirstOrDefault();

            var loggedUser = await userManager.FindUserById(userId);

            return View(loggedUser);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Settings(User user)
        {
            var userManager = new UserManager(@"http://localhost:50798/", new HttpClientFactory());
            await userManager.UpdateUser(user);

            return RedirectToAction("Index", user);
        }
    }
}