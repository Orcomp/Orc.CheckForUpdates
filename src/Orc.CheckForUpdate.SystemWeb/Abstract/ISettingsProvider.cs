// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISettingsProvider.cs" company="ORC">
//   
// </copyright>
// <summary>
//   Interface for getting settings in used by library.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.Web.Abstract
{
    /// <summary>
    /// Interface for getting settings in used by library.
    /// </summary>
    public interface ISettingsProvider
    {
        /// <summary>
        /// Gets application name.
        /// </summary>
        string ApplicationName { get; }

        /// <summary>
        /// Gets the pattern according to which is applied when installer is uploaded.
        /// </summary>
        string InstallerNamePattern { get; }
    }
}