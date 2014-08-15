// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NinjaModule.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   Defines the NinjaModule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.Web.IoC
{
    using Ninject.Modules;

    using Orc.CheckForUpdate.Web.Abstract;
    using Orc.CheckForUpdate.Web.Implementations;

    /// <summary>
    /// The ninja module.
    /// </summary>
    public class NinjaModule : NinjectModule
    {
        /// <summary>
        /// Loads module.
        /// </summary>
        public override void Load()
        {
            Bind<ISettingsProvider>().To<SettingsProvider>();
            Bind<IVersionRepository>().To<VersionFileSystemRepository>();
            Bind<IDownloadLinkProvider>().To<DownloadLinkProvider>();
        }
    }
}
