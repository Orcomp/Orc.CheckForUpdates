namespace Orc.CheckForUpdate.Web.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Routing;

    using Orc.CheckForUpdate.Models;
    using Orc.CheckForUpdate.Web.Abstract;

    using Version = Orc.CheckForUpdate.Models.Version;

    /// <summary>
    /// The download url extension.
    /// </summary>
    public static class DownloadUrlExtension
    {
        /// <summary>
        /// The supply with download url.
        /// </summary>
        /// <param name="list">
        /// The list.
        /// </param>
        /// <param name="urlHelper">
        /// The url helper.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public static IEnumerable<Version> SupplyWithDownloadUrl(this IEnumerable<Version> list, UrlHelper urlHelper, IDownloadLinkProvider downloadLinkProvider)
        {
            return list.Select(version => version.SupplyWithDownloadUrl(urlHelper, downloadLinkProvider));
        }

        /// <summary>
        /// The supply with download url.
        /// </summary>
        /// <param name="version">
        /// The version.
        /// </param>
        /// <param name="urlHelper">
        /// The url helper.
        /// </param>
        /// <returns>
        /// The <see cref="Version"/>.
        /// </returns>
        public static Version SupplyWithDownloadUrl(this Version version, UrlHelper urlHelper, IDownloadLinkProvider downloadLinkProvider)
        {
            version.DownloadUrl = urlHelper.Link(downloadLinkProvider.RouteName, 
                new { 
                    controller = downloadLinkProvider.ControllerName, 
                    action = downloadLinkProvider.ActionName, 
                    id = version.Id });

            return version;
        }
    }
}
