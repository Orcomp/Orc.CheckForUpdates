// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDownloadLinkProvider.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   Defines the IDownloadLinkProvider interface so it can be injected into the consumer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.Web.Abstract
{
    /// <summary>
    /// The DownloadLinkProvider interface.
    /// </summary>
    public interface IDownloadLinkProvider
    {
        /// <summary>
        /// Gets the route name.
        /// </summary>
        string RouteName { get; }

        /// <summary>
        /// Gets the controller name.
        /// </summary>
        string ControllerName { get; }

        /// <summary>
        /// Gets the action name.
        /// </summary>
        string ActionName { get; } 
    }
}