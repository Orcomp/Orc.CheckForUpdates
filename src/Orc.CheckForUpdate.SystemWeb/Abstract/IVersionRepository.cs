// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IVersionRepository.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   The VersionRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.Web.Abstract
{
    using System.Collections.Generic;
    using System.Web;

    using Orc.CheckForUpdate.Models;

    /// <summary>
    /// The VersionRepository interface.
    /// </summary>
    public interface IVersionRepository
    {
        /// <summary>
        /// Gets or sets server for repository functioning.
        /// </summary>
        HttpServerUtility Server { get; set; }

        /// <summary>
        /// Gets all available versions.
        /// </summary>
        /// <returns>
        /// List of available versions.
        /// </returns>
        IEnumerable<Version> GetAll();

        /// <summary>
        /// Gets version object. 
        /// </summary>
        /// <param name="id">
        /// The id of the version.
        /// </param>
        /// <returns>
        /// The <see cref="Version"/>.
        /// </returns>
        Version Get(string id);

        /// <summary>
        /// Gets file path of given version.
        /// </summary>
        /// <param name="id">The id of the version.</param>
        /// <returns>The file path.</returns>
        string GetVersionFilePath(string id);

        /// <summary>
        /// Adds file as an release version.
        /// </summary>
        /// <param name="item">The version to be added.</param>
        /// <param name="file">Uploaded file.</param>
        /// <returns>Updated version instance.</returns>
        Version Add(Version item, HttpPostedFile file);

        /// <summary>
        /// Adds file as an release version.
        /// </summary>
        /// <param name="item">The version to be added.</param>
        /// <param name="sourceFilePath">The path to the version file.</param>
        /// <returns>Updated version instance.</returns>
        Version Add(Version item, string sourceFilePath);

        /// <summary>
        /// Updates existing version.
        /// </summary>
        /// <param name="item">The version to be updated.</param>
        /// <param name="file">The newly uploaded version file.</param>
        /// <returns>True if update was successful.</returns>
        bool Update(Version item, HttpPostedFile file);

        /// <summary>
        /// Updates existing version.
        /// </summary>
        /// <param name="item">The version to be updated.</param>
        /// <param name="sourceFilePath">The path to the version file.</param>
        /// <returns>True if update was successful.</returns>
        bool Update(Version item, string sourceFilePath);

        /// <summary>
        /// Deletes version with given id.
        /// </summary>
        /// <param name="id">The version id.</param>
        void Remove(string id);
    }
}
