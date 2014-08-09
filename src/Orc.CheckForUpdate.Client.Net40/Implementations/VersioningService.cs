// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VersioningService.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   Defines the VersioningService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.Client
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// The versioning service.
    /// </summary>
    public class VersioningService : IVersioningService
    {
        private IVersioningSettingsService versioningSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="VersioningService"/> class.
        /// </summary>
        /// <param name="versioningSettings">
        /// The versioning settings.
        /// </param>
        public VersioningService(IVersioningSettingsService versioningSettings)
        {
            this.versioningSettings = versioningSettings;
        }

        /// <summary>
        /// Gets current version.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetCurrentVersion()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Checks whether update available.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> of checking whether update available.
        /// </returns>
        public Task<bool> IsUpdateAvailable()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The get latest version.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> of getting latest version number.
        /// </returns>
        public Task<string> GetLatestVersion()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The download version.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> of downloading version.
        /// </returns>
        public Task<string> DownloadVersion()
        {
            throw new System.NotImplementedException();
        }

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
        public Task<string> StartCheckWorkflow(Func<string, bool> shouldStartInsaller)
        {
            throw new System.NotImplementedException();
        }
    }
}
