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
    using System;
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
        Task<bool> IsUpdateAvailable();

        /// <summary>
        /// The get latest version.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> of getting latest version number.
        /// </returns>
        Task<string> GetLatestVersion();

        /// <summary>
        /// The download version.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> of downloading version.
        /// </returns>
        Task<string> DownloadVersion();

        /// <summary>
        /// Starts workflow in which
        /// a) gets the latest version number from the server;
        /// b) compares the latest version number with current one;
        /// c) *if needed* downloads latest version installer from the server;
        /// d) *if needed* executes action to determine whether latest version installer should be started;
        /// e) *if needed* starts latest version installer.
        /// </summary>
        /// <param name="shouldStartInsaller">
        /// The function which helps to determine whether latest version installer should be started.
        /// </param>
        /// <returns>
        /// The workflow <see cref="Task"/> .
        /// </returns>
        Task<string> StartCheckWorkflow(Func<string, bool> shouldStartInsaller);
    }
}