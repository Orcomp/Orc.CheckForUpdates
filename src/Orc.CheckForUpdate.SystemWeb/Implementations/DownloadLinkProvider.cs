// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DownloadLinkProvider.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   Defines the DownloadLinkProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.Web.Implementations
{
    using Orc.CheckForUpdate.Web.Abstract;

    /// <summary>
    /// The download link provider.
    /// </summary>
    public class DownloadLinkProvider : IDownloadLinkProvider
    {
        /// <summary>
        /// Gets the route name.
        /// </summary>
        public string RouteName
        {
            get
            {
                return "DownloadFile";
            }
        }

        /// <summary>
        /// Gets the controller name.
        /// </summary>
        public string ControllerName
        {
            get
            {
                return "Home";
            }
        }

        /// <summary>
        /// Gets the action name.
        /// </summary>
        public string ActionName
        {
            get
            {
                return "Download";
            }
        }
    }
}
