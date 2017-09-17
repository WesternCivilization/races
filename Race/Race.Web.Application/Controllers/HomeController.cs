using System.Web.Mvc;

namespace Race.Web.Application.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}