using devTest.CrossCutting;
using devTest.CrossCutting.Bootstrapper;
using System.Web.Http;

namespace AngularJSCRUD.App_Start
{
    public static class IocConfig
    {
        public static void Initialize()
        {
            GlobalConfiguration.Configuration.DependencyResolver = ApplicationContext.Container.GetDependencyResolverWebApi();
            IocRegistration.Register(ApplicationContext.Container);
        }
    }
}