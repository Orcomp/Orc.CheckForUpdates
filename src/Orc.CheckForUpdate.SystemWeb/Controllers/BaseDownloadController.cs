// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseDownloadController.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   The base download controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Orc.CheckForUpdate.Helpers;
    using Orc.CheckForUpdate.Web.Abstract;
    using Orc.CheckForUpdate.Web.Models;

    /// <summary>
    /// The base download controller.
    /// </summary>
    public class BaseDownloadController : Controller
    {
        /// <summary>
        /// The repository.
        /// </summary>
        protected readonly IVersionRepository Repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDownloadController"/> class.
        /// </summary>
        /// <param name="repository">
        /// The repository.
        /// </param>
        public BaseDownloadController(IVersionRepository repository)
        {
            repository.Server = System.Web.HttpContext.Current.Server;
            this.Repository = repository;
            this.PageSize = 10;
        }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        protected int PageSize { get; set; }

        /// <summary>
        /// The get view model.
        /// </summary>
        /// <param name="page">
        /// The page number.
        /// </param>
        /// <returns>
        /// The <see cref="VersionsViewModel"/> ready for use.
        /// </returns>
        protected VersionsViewModel GetViewModel(int page)
        {
            var list = this.Repository.GetAll().Where(v => !v.ExpirationDate.HasValue ||
                v.ExpirationDate.Value > DateTime.Now).ToList();

            Uri contextUri = System.Web.HttpContext.Current.Request.Url;

            var baseUri = string.Format(
                "{0}://{1}{2}",
                contextUri.Scheme,
                contextUri.Host,
                contextUri.Port == 80 ? string.Empty : ":" + contextUri.Port);

            foreach (var version in list)
            {
                var localUrl = this.Url.Action("Get", new { id = version.Id });
                version.DownloadUrl = string.Format("{0}{1}", baseUri, VirtualPathUtility.ToAbsolute(localUrl));
            }

            var viewModel = new VersionsViewModel
            {
                Versions = list
                    .OrderByDescending(v => v.Id, new VersionStringHelper.VersionStringComparer())
                    .Skip((page - 1) * this.PageSize)
                    .Take(this.PageSize).ToList(),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = this.PageSize,
                    TotalItems = list.Count()
                }
            };

            return viewModel;
        }

        /// <summary>
        /// The download action.
        /// </summary>
        /// <param name="id">
        /// The version id.
        /// </param>
        /// <returns>
        /// The <see cref="FileResult"/> file user downloads.
        /// </returns>
        public FileResult Get(string id)
        {
            var fileName = this.Repository.GetVersionFilePath(id);
            var fileInfo = new FileInfo(fileName);
            var contentType = "application/x-msi";

            return new FilePathResult(fileName, contentType) { FileDownloadName = fileInfo.Name };
        }
    }
}
