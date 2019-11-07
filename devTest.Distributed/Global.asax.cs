using AngularJSCRUD.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace devTest.Distributed
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Could not load file or assembly
            //    'System.Web.Http.WebHost, Version=5.2.3.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35' 
            //    or one of its dependencies.The located assembly's 
            //    manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)

            // Registrar las dependencias
            IocConfig.Initialize();
        }
    }
}
