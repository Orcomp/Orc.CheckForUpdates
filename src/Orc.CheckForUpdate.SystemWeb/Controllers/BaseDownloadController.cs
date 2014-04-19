using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orc.CheckForUpdate.Web.Controllers
{
    using System.IO;
    using System.Web;
    using System.Web.Mvc;

    using Orc.CheckForUpdate.Helpers;
    using Orc.CheckForUpdate.Web.Abstract;
    using Orc.CheckForUpdate.Web.Models;

    public class BaseDownloadController : Controller
    {
        /// <summary>
        /// The repository.
        /// </summary>
        protected readonly IVersionRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDownloadController"/> class.
        /// </summary>
        /// <param name="repository">
        /// The repository.
        /// </param>
        public BaseDownloadController(IVersionRepository repository)
        {
            repository.Server = System.Web.HttpContext.Current.Server;
            this.repository = repository;
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
        /// The page.
        /// </param>
        /// <returns>
        /// The <see cref="VersionsViewModel"/>.
        /// </returns>
        protected VersionsViewModel GetViewModel(int page)
        {
            var list = repository.GetAll().Where(v => !v.ExpirationDate.HasValue ||
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
        /// The download.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="FileResult"/>.
        /// </returns>
        public FileResult Get(string id)
        {
            string fileName = this.repository.GetVersionFilePath(id);
            FileInfo fileInfo = new FileInfo(fileName);
            string contentType = "application/x-msi";

            return new FilePathResult(fileName, contentType) { FileDownloadName = fileInfo.Name };
        }
        
    }
}
