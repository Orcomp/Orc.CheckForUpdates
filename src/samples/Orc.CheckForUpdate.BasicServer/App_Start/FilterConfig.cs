// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilterConfig.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   Defines the FilterConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.BasicServer
{
    using System.Web.Http;
    using System.Web.Mvc;

    using Ninject;

    using Orc.CheckForUpdate.BasicServer.Filters;
    using Orc.CheckForUpdate.Web.Abstract;

    /// <summary>
    /// The filter config.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Registers global filters.
        /// </summary>
        /// <param name="filters">
        /// The filters.
        /// </param>
        public static void RegisterGlobalFilters(IKernel kernel, GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new HandleCommonViewBag(kernel.Get<ISettingsProvider>()));
        }
    }
}
