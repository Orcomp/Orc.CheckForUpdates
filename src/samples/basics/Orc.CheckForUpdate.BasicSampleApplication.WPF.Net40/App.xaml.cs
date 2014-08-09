// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   Interaction logic for App.xaml.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.BasicSampleApplication.WPF.Net40
{
    using System.Threading;
    using System.Windows;

    using Ninject;

    using Orc.CheckForUpdate.BasicSampleApplication.WPF.Net40.ViewModels;
    using Orc.CheckForUpdate.Client;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App
    {
        private Mutex instanceMutex = null;

        private IKernel kernel;

        /// <summary>
        /// The on startup initialization.
        /// </summary>
        /// <param name="e">
        /// The startup event arguments.
        /// </param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // check that there is only one instance of the control panel running...
            bool createdNew;
            this.instanceMutex = new Mutex(true, @"Global\ControlPanel", out createdNew);
            if (!createdNew)
            {
                this.instanceMutex = null;
                MessageBox.Show("Application instance is already running");
                Shutdown();
                return;
            }

            ConfigureContainer();

            var viewModel = this.kernel.Get<MainWindowViewModel>();
            var window = new MainWindow { DataContext = viewModel };

            var checkForUpdatesSettings = this.kernel.Get<IVersioningSettingsService>();
            var checkForUpdatesService = this.kernel.Get<IVersioningService>();
            if (checkForUpdatesSettings.CheckOnStartup)
            {
            }

            MainWindow = window;
            window.Show();
        }

        private void ConfigureContainer()
        {
            this.kernel = new StandardKernel();
            this.kernel.Bind<IVersioningSettingsService>().To<DefaultVersioningSettingsService>().InSingletonScope();
            this.kernel.Bind<IVersioningService>().To<VersioningService>().InSingletonScope();
        }
    }
}
