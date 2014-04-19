using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Gets all available versions
        /// </summary>
        /// <returns></returns>
        IEnumerable<Version> GetAll();

        /// <summary>
        /// Gets version object 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Version Get(string id);

        /// <summary>
        /// Gets file path of given version.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetVersionFilePath(string id);

        /// <summary>
        /// Adds file as an release version.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        Version Add(Version item, HttpPostedFile file);

        /// <summary>
        /// Adds file as an release version.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="sourceFilePath"></param>
        /// <returns></returns>
        Version Add(Version item, string sourceFilePath);

        /// <summary>
        /// Updates existing version.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        bool Update(Version item, HttpPostedFile file);

        /// <summary>
        /// Updates existing version.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="sourceFilePath"></param>
        /// <returns></returns>
        bool Update(Version item, string sourceFilePath);

        /// <summary>
        /// Deletes version with given id.
        /// </summary>
        /// <param name="id"></param>
        void Remove(string id);
    }
}
