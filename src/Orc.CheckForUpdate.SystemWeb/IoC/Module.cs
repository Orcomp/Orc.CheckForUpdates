namespace Orc.CheckForUpdate.Web.IoC
{
    using Ninject.Modules;

    using Orc.CheckForUpdate.Web.Abstract;
    using Orc.CheckForUpdate.Web.Implementations;

    public class NinjaModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IVersionRepository>().To<VersionFileSystemRepository>();
            Bind<IDownloadLinkProvider>().To<DownloadLinkProvider>();
        }
    }
}
