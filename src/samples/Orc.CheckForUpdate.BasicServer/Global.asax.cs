using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Orc.CheckForUpdate.BasicServer
{
    using System.Web.Http;

    using Orc.CheckForUpdate.SystemWeb.Extensions;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            VersionsApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
