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
    using System.Web.Mvc;

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
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
