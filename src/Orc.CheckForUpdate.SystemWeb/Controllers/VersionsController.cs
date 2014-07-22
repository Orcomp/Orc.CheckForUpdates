// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VersionsController.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   The versions controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http;

    using Orc.CheckForUpdate.Helpers;
    using Orc.CheckForUpdate.Web.Abstract;
    using Orc.CheckForUpdate.Web.Extensions;

    using Version = Orc.CheckForUpdate.Models.Version;

    /// <summary>
    /// The versions controller.
    /// </summary>
    public class VersionsController : ApiController
    {
        /// <summary>
        /// The repository.
        /// </summary>
        private readonly IVersionRepository repository;

        private readonly IDownloadLinkProvider downloadLinkProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="VersionsController"/> class.
        /// </summary>
        /// <param name="repository">
        /// The repository.
        /// </param>
        /// <param name="downloadLinkProvider">
        /// The download Link Provider.
        /// </param>
        public VersionsController(IVersionRepository repository, IDownloadLinkProvider downloadLinkProvider)
        {
            repository.Server = HttpContext.Current.Server;
            this.repository = repository;
            this.downloadLinkProvider = downloadLinkProvider;
        }

        /// <summary>
        /// The get versions.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public IEnumerable<Version> GetVersions()
        {
            return this.repository.GetAll()
                .OrderByDescending(v => v.Id, new VersionStringHelper.VersionStringComparer())
                .SupplyWithDownloadUrl(this.Url, this.downloadLinkProvider);
        }

        /// <summary>
        /// The get versions.
        /// </summary>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <param name="pageIndex">
        /// The page index.
        /// </param>
        /// <param name="beta">
        /// The string option which shows whether to include beta versions or not.
        /// </param>
        /// <returns>
        /// The list of available versions.
        /// </returns>
        public IEnumerable<Version> GetVersions(int pageSize, int pageIndex, string beta)
        {
            if (beta == "include")
            {
                return this.repository.GetAll()
                    .OrderByDescending(v => v.Id, new VersionStringHelper.VersionStringComparer())
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .SupplyWithDownloadUrl(this.Url, this.downloadLinkProvider);
            }

            return this.repository.GetAll()
                    .Where(v => v.Stable)
                    .OrderByDescending(v => v.Id, new VersionStringHelper.VersionStringComparer())
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .SupplyWithDownloadUrl(this.Url, this.downloadLinkProvider);
        }

        /// <summary>
        /// The get version.
        /// </summary>
        /// <param name="id">
        /// The version id.
        /// </param>
        /// <returns>
        /// The Version <see cref="Version"/> instance with given id.
        /// </returns>
        /// <exception cref="HttpResponseException">
        /// Thrown when version is not found.
        /// </exception>
        public Version GetVersion(string id)
        {
            Version item = this.repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            item.DownloadUrl = Url.Link("Default", new { action = "Download", id = item.Id });

            return item;
        }

        /// <summary>
        /// Uploads version to the server.
        /// </summary>
        /// <returns>
        /// The uploading task  <see cref="Task"/>.
        /// </returns>
        /// <exception cref="HttpResponseException">
        /// Thrown if unable to extract the version file.
        /// </exception>
        [Authorize]
        public async Task<HttpResponseMessage> PostVersion()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data/Temp");

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                // Read the form data and return an async task.
                await Request.Content.ReadAsMultipartAsync(provider);

                string[] ids = provider.FormData.GetValues("versionId");
                string[] stables = provider.FormData.GetValues("versionStable");
                string[] expDates = provider.FormData.GetValues("expirationDate");

                bool isStable = false;

                bool idInvalid = ids == null || ids.Length != 1 || !VersionStringHelper.IsValidVersionString(ids[0]);
                bool stabInvalid = stables == null || stables.Length != 1 || !bool.TryParse(stables[0], out isStable);
                bool expirationInvalid = expDates == null || expDates.Length != 1;
                if (idInvalid || stabInvalid || expirationInvalid || provider.FileData.Count != 1)
                {
                    throw new HttpResponseException(HttpStatusCode.ExpectationFailed);
                }

                DateTime? expirationDate = null;
                if (!string.IsNullOrEmpty(expDates[0]))
                {
                    DateTime parseResult;
                    if (DateTime.TryParseExact(expDates[0], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parseResult))
                    {
                        expirationDate = parseResult;
                    }
                    else
                    {
                        throw new HttpResponseException(HttpStatusCode.ExpectationFailed);
                    }
                }

                Version versionItem = new Version
                {
                    Id = ids[0],
                    Stable = isStable,
                    ExpirationDate = expirationDate
                };

                var postedFile = provider.FileData[0];

                var item = this.repository.Add(versionItem, postedFile.LocalFileName);

                item.DownloadUrl = Url.Link("Default", new { action = "Download", id = item.Id });

                var response = Request.CreateResponse(HttpStatusCode.Created, item);
                response.Headers.Location = new Uri(item.DownloadUrl);
                return response;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        /// <summary>
        /// Puts version.
        /// </summary>
        /// <param name="id">
        /// The version id.
        /// </param>
        /// <param name="item">
        /// The version instance.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// Not implemented yet.
        /// </exception>
        [Authorize]
        public void PutVersion(string id, Version item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The delete version.
        /// </summary>
        /// <param name="id">
        /// The version id.
        /// </param>
        [Authorize]
        public void DeleteVersion(string id)
        {
            this.repository.Remove(id);
        }
    }
}
