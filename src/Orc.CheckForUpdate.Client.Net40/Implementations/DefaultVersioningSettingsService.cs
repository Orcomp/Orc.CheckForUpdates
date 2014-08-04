// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultVersioningSettingsService.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   Defines the DefaultVersioningSettingsService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.Client
{
    using System.Configuration;
    using System.Linq;

    /// <summary>
    /// The default versioning settings service.
    /// </summary>
    public class DefaultVersioningSettingsService : IVersioningSettingsService
    {
        /// <summary>
        /// Gets a value indicating whether to check for unstable versions.
        /// </summary>
        public bool CheckForUnstableVersions
        {
            get
            {
                return (ConfigurationManager.AppSettings.AllKeys.Contains("CheckForUnstableVersions") && ConfigurationManager.AppSettings["CheckForUnstableVersions"] == bool.TrueString);
            }
        }

        /// <summary>
        /// Gets the versions api url.
        /// </summary>
        public string VersionsApiUrl 
        {
            get
            {
                return ConfigurationManager.AppSettings.AllKeys.Contains("VersionsApiUrl")
                           ? ConfigurationManager.AppSettings["VersionsApiUrl"]
                           : string.Empty;
            }
        }
    }
}
