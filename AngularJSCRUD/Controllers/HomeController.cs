
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace devTest.UI.Controllers
{
    public class HomeController : Controller
    {
        //// GET: Home
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index()
        {
            return File(Server.MapPath("~/App/Templates/Home/Home.html"), "text/plain");
        }
    }
}