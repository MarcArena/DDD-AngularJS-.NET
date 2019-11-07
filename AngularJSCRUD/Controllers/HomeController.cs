using System.Web.Mvc;

namespace devTest.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return File(Server.MapPath("~/App/Templates/Home/Home.html"), "text/plain");
        }
    }
}