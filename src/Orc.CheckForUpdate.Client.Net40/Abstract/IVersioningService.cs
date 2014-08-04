// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IVersioningService.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   Interface defining basic versioning operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.Client
{
    using System.Threading.Tasks;

    /// <summary>
    /// Interface defining basic versioning operations.
    /// </summary>
    public interface IVersioningService
    {
        /// <summary>
        /// Gets current version.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string GetCurrentVersion();

        /// <summary>
        /// Checks whether update available.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> of checking whether update available.
        /// </returns>
        Task IsUpdateAvailable();

        /// <summary>
        /// The get latest version.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> of getting latest version number.
        /// </returns>
        Task GetLatestVersion();

        /// <summary>
        /// The download version.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> of downloading version.
        /// </returns>
        Task DownloadVersion();
    }
}