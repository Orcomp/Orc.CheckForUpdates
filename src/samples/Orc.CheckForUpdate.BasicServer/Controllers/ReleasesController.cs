// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReleasesController.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   Defines the ReleasesController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.BasicServer.Controllers
{
    using System.Web.Mvc;

    using Orc.CheckForUpdate.Web.Abstract;
    using Orc.CheckForUpdate.Web.Controllers;

    /// <summary>
    /// The releases controller.
    /// </summary>
    public class ReleasesController : BaseDownloadController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReleasesController"/> class.
        /// </summary>
        /// <param name="repository">
        /// The repository.
        /// </param>
        public ReleasesController(IVersionRepository repository)
            : base(repository)
        {
        }

        /// <summary>
        /// The index action.
        /// </summary>
        /// <param name="page">
        /// The page number.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index(int page = 1)
        {
            return View(this.GetViewModel(page));
        }

        /// <summary>
        /// The administer action.
        /// </summary>
        /// <param name="page">
        /// The page number.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Administer(int page = 1)
        {
            return View(this.GetViewModel(page));
        }

        /// <summary>
        /// The releases list.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <returns>
        /// The <see cref="PartialViewResult"/>.
        /// </returns>
        public PartialViewResult ReleasesList(int page = 1)
        {
            return this.PartialView("ReleasesList", this.GetViewModel(page));
        }
    }
}