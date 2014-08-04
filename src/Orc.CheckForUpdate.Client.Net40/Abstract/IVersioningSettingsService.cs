// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IVersioningSettingsService.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   Defines the IVersioningSettingsService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.Client
{
    /// <summary>
    /// The VersioningSettingsService interface.
    /// </summary>
    public interface IVersioningSettingsService
    {
        /// <summary>
        /// Gets a value indicating whether to check for unstable versions.
        /// </summary>
        bool CheckForUnstableVersions { get; }

        /// <summary>
        /// Gets the versions api url.
        /// </summary>
        string VersionsApiUrl { get; }
    }
}