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
        public Task IsUpdateAvailable()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The get latest version.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> of getting latest version number.
        /// </returns>
        public Task GetLatestVersion()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The download version.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> of downloading version.
        /// </returns>
        public Task DownloadVersion()
        {
            throw new System.NotImplementedException();
        }
    }
}
