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
        /// Initializes a new instance of the <see cref="VersionFileSystemRepository"/> class.
        /// </summary>
        public VersionFileSystemRepository()
        {
        }

        /// <summary>
        /// Gets or sets server for repository functioning.
        /// </summary>
        public HttpServerUtility Server { get; set; }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
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
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
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
        /// The get version file path.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetVersionFilePath(string id)
        {
            Version version = this.Get(id);
            return this.GetVersionFileName(version, false);
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="file">
        /// The file.
        /// </param>
        /// <returns>
        /// The <see cref="Version"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// If file already exists.
        /// </exception>
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
        /// The add.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="sourceFilePath">
        /// The source file path.
        /// </param>
        /// <returns>
        /// The <see cref="Version"/>.
        /// </returns>
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
        /// The update.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="file">
        /// The file.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
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
        /// The update.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="sourceFilePath">
        /// The source file path.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Update(Version item, string sourceFilePath)
        {
            string filePath = this.GetVersionFileName(item);
            File.Move(sourceFilePath, filePath);
            return true;
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Remove(string id)
        {
            string folderPath = HttpContext.Current.Server.MapPath(string.Format("~/App_Data/{0}", id));
            Directory.Delete(folderPath);
        }

        /// <summary>
        /// The get version file name.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="createFolder">
        /// The create folder.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
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
        /// The get additional info file name.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetAdditionalInfoFileName(string id)
        {
            return this.Server.MapPath(string.Format("~/App_Data/Repository/{0}/{1}", id, "version.info"));
        }

        /// <summary>
        /// The extract expiration date.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="DateTime?"/>.
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
