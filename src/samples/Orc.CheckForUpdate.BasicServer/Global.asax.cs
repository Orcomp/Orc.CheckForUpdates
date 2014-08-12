namespace Orc.CheckForUpdate.BasicServer
{
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Ninject;
    using Ninject.Modules;
    using Ninject.Web.Common;

    using Orc.CheckForUpdate.SystemWeb.Extensions;
    using Orc.CheckForUpdate.Web.Abstract;
    using Orc.CheckForUpdate.Web.Implementations;
    using Orc.CheckForUpdate.Web.IoC;

    public class MvcApplication : NinjectHttpApplication
    {
        private IKernel _kernel; 
        protected override IKernel CreateKernel()
        {
            if (_kernel != null)
            {
                return null;
            }

            _kernel = new StandardKernel(new INinjectModule[] { new NinjaModule() });
            return _kernel;
        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();

            VersionsApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(_kernel);
        }
    }
}
