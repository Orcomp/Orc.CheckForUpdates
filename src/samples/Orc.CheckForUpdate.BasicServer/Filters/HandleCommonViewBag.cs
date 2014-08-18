// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HandleCommonViewBag.cs" company="ORC">
//   
// </copyright>
// <summary>
//   Defines the HandleCommonViewBag type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.BasicServer.Filters
{
    using System.Web.Mvc;

    using Orc.CheckForUpdate.Web.Abstract;

    /// <summary>
    /// The handle common view bag.
    /// </summary>
    public class HandleCommonViewBag : ActionFilterAttribute
    {
        private readonly ISettingsProvider settingsProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandleCommonViewBag"/> class.
        /// </summary>
        /// <param name="settingsProvider">
        /// The settings provider.
        /// </param>
        public HandleCommonViewBag(ISettingsProvider settingsProvider)
        {
            this.settingsProvider = settingsProvider;
        }

        /// <summary>
        /// The on result executing.
        /// </summary>
        /// <param name="filterContext">
        /// The filter context.
        /// </param>
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.ApplicationName = this.settingsProvider.ApplicationName;
        }
    }
}