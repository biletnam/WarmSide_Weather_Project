using System.Web.Mvc;

namespace WarmSide.WebFace.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Warm Side Weather Project";
            return View();
        }
    }
}