// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsProvider.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   Defines the SettingsProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.Web.Implementations
{
    using System.Configuration;

    using Orc.CheckForUpdate.Web.Abstract;
    using Orc.CheckForUpdate.Web.Configuration;

    /// <summary>
    /// The settings provider.
    /// </summary>
    public class SettingsProvider : ISettingsProvider
    {
        private readonly OrcCheckForUpdateSection config;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsProvider"/> class.
        /// </summary>
        public SettingsProvider()
        {
            config = (OrcCheckForUpdateSection)ConfigurationManager.GetSection("OrcCheckForUpdate")
                     ?? new OrcCheckForUpdateSection { ApplicationName = "MyApp", InstallerNamePattern = "MyApp-{number}{stability}.exe" };
        }

        /// <summary>
        /// Gets the application name.
        /// </summary>
        public string ApplicationName
        {
            get
            {
                return config.ApplicationName;
            }
        }

        /// <summary>
        /// Gets the pattern according to which is applied when installer is uploaded.
        /// </summary>
        public string InstallerNamePattern
        {
            get
            {
                return config.InstallerNamePattern;
            }
        }
    }
}
