using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Mvc;
using WarmSide.WebFace.Models;

namespace WarmSide.WebFace.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string City = null)
        {
            ViewBag.Title = "Warm Side Weather Project";

            if (City == null)
                City = "Los Angeles";

            return View(new UserPreferences { City = City });
        }
    }
}