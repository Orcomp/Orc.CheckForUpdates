// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   Defines the MvcApplication type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
    using Orc.CheckForUpdate.Web.IoC;

    /// <summary>
    /// The mvc application.
    /// </summary>
    public class MvcApplication : NinjectHttpApplication
    {
        private IKernel _kernel;

        /// <summary>
        /// Creates ninject kernel.
        /// </summary>
        /// <returns>
        /// The <see cref="IKernel"/>.
        /// </returns>
        protected override IKernel CreateKernel()
        {
            if (_kernel != null)
            {
                return null;
            }

            _kernel = new StandardKernel(new INinjectModule[] { new NinjaModule() });
            return _kernel;
        }

        /// <summary>
        /// The on application started handler.
        /// </summary>
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(_kernel);

            AreaRegistration.RegisterAllAreas();

            VersionsApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(_kernel, GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
