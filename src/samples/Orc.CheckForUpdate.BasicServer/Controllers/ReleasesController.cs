namespace Orc.CheckForUpdate.BasicServer.Controllers
{
    using System.Web.Mvc;

    using Orc.CheckForUpdate.Web.Abstract;
    using Orc.CheckForUpdate.Web.Controllers;

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
        
        public ActionResult Index(int page = 1)
        {
            return View(this.GetViewModel(page));
        }

        public ActionResult Administer(int page = 1)
        {
            return View(this.GetViewModel(page));
        }
    }
}