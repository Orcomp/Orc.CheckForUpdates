// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VersionFileSystemRepository.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   The version file system repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.Web.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Web;

    using Orc.CheckForUpdate.Helpers;
    using Orc.CheckForUpdate.Web.Abstract;

    using Version = Orc.CheckForUpdate.Models.Version;

    /// <summary>
    /// The version file system repository.
    /// </summary>
    public class VersionFileSystemRepository : IVersionRepository
    {
        /// <summary>
        /// The installer name pattern.
        /// </summary>
        private const string InstallerNamePattern = "Rantt-{0}{1}.exe";

        /// <summary>
        /// Gets or sets server for repository functioning.
        /// </summary>
        public HttpServerUtility Server { get; set; }

        /// <summary>
        /// Gets all available versions.
        /// </summary>
        /// <returns>
        /// List of available versions.
        /// </returns>
        public IEnumerable<Version> GetAll()
        {
            string path = HttpContext.Current.Server.MapPath("~/App_Data/Repository");
            var result = new List<Version>();

            if (Directory.Exists(path))
            {
                var di = new DirectoryInfo(path);
                DirectoryInfo[] directories = di.GetDirectories();

                foreach (DirectoryInfo directoryInfo in directories)
                {
                    if (VersionStringHelper.IsValidVersionString(directoryInfo.Name))
                    {
                        string versionId = directoryInfo.Name;
                        string stableName = string.Format(InstallerNamePattern, versionId, string.Empty);
                        string betaName = string.Format(InstallerNamePattern, versionId, "-beta");

                        string filePath = HttpContext.Current.Server.MapPath(string.Format("~/App_Data/Repository/{0}/{1}", directoryInfo.Name, stableName));
                        if (File.Exists(filePath))
                        {
                            result.Add(new Version
                            {
                                Id = versionId,
                                Stable = true,
                                ExpirationDate = this.ExtractExpirationDate(versionId)
                            });
                        }
                        else
                        {
                            filePath = HttpContext.Current.Server.MapPath(string.Format("~/App_Data/Repository/{0}/{1}", directoryInfo.Name, betaName));
                            if (File.Exists(filePath))
                            {
                                result.Add(new Version
                                {
                                    Id = versionId,
                                    Stable = false,
                                    ExpirationDate = this.ExtractExpirationDate(versionId)
                                });
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets version object. 
        /// </summary>
        /// <param name="id">
        /// The id of the version.
        /// </param>
        /// <returns>
        /// The <see cref="Version"/>.
        /// </returns>
        public Version Get(string id)
        {
            string stableName = string.Format(InstallerNamePattern, id, string.Empty);
            string betaName = string.Format(InstallerNamePattern, id, "-beta");

            string filePath = HttpContext.Current.Server.MapPath(string.Format("~/App_Data/Repository/{0}/{1}", id, stableName));
            if (File.Exists(filePath))
            {
                return new Version
                {
                    Id = id,
                    Stable = true,
                    ExpirationDate = this.ExtractExpirationDate(id)
                };
            }

            filePath = HttpContext.Current.Server.MapPath(string.Format("~/App_Data/Repository/{0}/{1}", id, betaName));
            if (File.Exists(filePath))
            {
                return new Version
                {
                    Id = id,
                    Stable = false,
                    ExpirationDate = this.ExtractExpirationDate(id)
                };
            }

            return null;
        }

        /// <summary>
        /// Gets file path of given version.
        /// </summary>
        /// <param name="id">The id of the version.</param>
        /// <returns>The file path.</returns>
        public string GetVersionFilePath(string id)
        {
            var version = this.Get(id);
            return this.GetVersionFileName(version, false);
        }

        /// <summary>
        /// Adds file as an release version.
        /// </summary>
        /// <param name="item">The version to be added.</param>
        /// <param name="file">Uploaded file.</param>
        /// <returns>Updated version instance.</returns>
        public Version Add(Version item, HttpPostedFile file)
        {
            string filePath = GetVersionFileName(item);

            if (File.Exists(filePath))
            {
                throw new Exception(string.Format("File {0} already exists", filePath));
            }

            file.SaveAs(filePath);
            if (item.ExpirationDate.HasValue)
            {
                string infoFilePath = this.GetAdditionalInfoFileName(item.Id);
                File.WriteAllText(
                    infoFilePath, item.ExpirationDate.Value.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
            }

            return item;
        }

        /// <summary>
        /// Adds file as an release version.
        /// </summary>
        /// <param name="item">The version to be added.</param>
        /// <param name="sourceFilePath">The path to the version file.</param>
        /// <returns>Updated version instance.</returns>
        public Version Add(Version item, string sourceFilePath)
        {
            string filePath = this.GetVersionFileName(item);
            File.Move(sourceFilePath, filePath);
            if (item.ExpirationDate.HasValue)
            {
                string infoFilePath = this.GetAdditionalInfoFileName(item.Id);
                File.WriteAllText(
                    infoFilePath, item.ExpirationDate.Value.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
            }

            return item;
        }

        /// <summary>
        /// Updates existing version.
        /// </summary>
        /// <param name="item">The version to be updated.</param>
        /// <param name="file">The newly uploaded version file.</param>
        /// <returns>True if update was successful.</returns>
        public bool Update(Version item, HttpPostedFile file)
        {
            string filePath = this.GetVersionFileName(item);

            if (!File.Exists(filePath))
            {
                return false;
            }

            File.Delete(filePath);

            file.SaveAs(filePath);

            if (item.ExpirationDate.HasValue)
            {
                string infoFilePath = this.GetAdditionalInfoFileName(item.Id);
                File.WriteAllText(
                    infoFilePath, item.ExpirationDate.Value.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
            }

            return true;
        }

        /// <summary>
        /// Updates existing version.
        /// </summary>
        /// <param name="item">The version to be updated.</param>
        /// <param name="sourceFilePath">The path to the version file.</param>
        /// <returns>True if update was successful.</returns>
        public bool Update(Version item, string sourceFilePath)
        {
            string filePath = this.GetVersionFileName(item);
            File.Move(sourceFilePath, filePath);
            return true;
        }

        /// <summary>
        /// Deletes version with given id.
        /// </summary>
        /// <param name="id">The version id.</param>
        public void Remove(string id)
        {
            string folderPath = HttpContext.Current.Server.MapPath(string.Format("~/App_Data/{0}", id));
            Directory.Delete(folderPath);
        }

        /// <summary>
        /// Get file name based on version number.
        /// </summary>
        /// <param name="item">
        /// The version instance.
        /// </param>
        /// <param name="createFolder">
        /// Shows whether to create folder if ti doesn't exists.
        /// </param>
        /// <returns>
        /// The full file path.
        /// </returns>
        private string GetVersionFileName(Version item, bool createFolder = true)
        {
            string folderPath = this.Server.MapPath(string.Format("~/App_Data/Repository/{0}", item.Id));
            if (!Directory.Exists(folderPath) && createFolder)
            {
                Directory.CreateDirectory(folderPath);
            }

            string fileName = string.Format(InstallerNamePattern, item.Id, item.Stable ? string.Empty : "-beta");
            return this.Server.MapPath(string.Format("~/App_Data/Repository/{0}/{1}", item.Id, fileName));
        }

        /// <summary>
        /// Gets file name path for additional info.
        /// </summary>
        /// <param name="id">
        /// The version number.
        /// </param>
        /// <returns>
        /// The file name path for additional info.
        /// </returns>
        private string GetAdditionalInfoFileName(string id)
        {
            return this.Server.MapPath(string.Format("~/App_Data/Repository/{0}/{1}", id, "version.info"));
        }

        /// <summary>
        /// The extract expiration date.
        /// </summary>
        /// <param name="id">
        /// The version number.
        /// </param>
        /// <returns>
        /// Date of expiration if any.
        /// </returns>
        private DateTime? ExtractExpirationDate(string id)
        {
            string filePath = this.GetAdditionalInfoFileName(id);
            if (File.Exists(filePath))
            {
                string text = File.ReadAllText(filePath);
                DateTime dateTime;
                if (DateTime.TryParseExact(
                    text, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                {
                    return dateTime;
                }
            }

            return null;
        }
    }
}
