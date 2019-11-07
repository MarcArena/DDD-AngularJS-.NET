using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJSCRUD.Controllers
{
    public class LoginFormsController : Controller
    {
        public ActionResult List()
        {
            return File(Server.MapPath("~/App/Templates/LoginForms/LoginForms.html"), "text/plain");
        }
    }
}