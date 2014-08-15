// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrcCheckForUpdateSection.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   Defines the OrcCheckForUpdateSection type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.Web.Configuration
{
    using System.Configuration;

    /// <summary>
    /// The orc check for update section.
    /// </summary>
    public class OrcCheckForUpdateSection : ConfigurationSection
    {
        /// <summary>
        /// Gets or sets the application name.
        /// </summary>
        [ConfigurationProperty("applicationName", DefaultValue = "MyApp", IsRequired = true)]
        public string ApplicationName
        {
            get
            {
                return (string)this["applicationName"];
            }
            set
            {
                this["applicationName"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the installer name pattern.
        /// </summary>
        [ConfigurationProperty("installerNamePattern", DefaultValue = "MyApp-{number}{stability}.exe", IsRequired = true)]
        public string InstallerNamePattern
        {
            get
            {
                return (string)this["installerNamePattern"];
            }
            set
            {
                this["installerNamePattern"] = value;
            }
        }
    }
}
