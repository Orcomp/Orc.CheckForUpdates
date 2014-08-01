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

    using Orc.CheckForUpdate.BasicSampleApplication.WPF.Net40.ViewModels;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App
    {
        private Mutex instanceMutex = null;

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

            var viewModel = new MainWindowViewModel();
            var window = new MainWindow { DataContext = viewModel };

            MainWindow = window;
            window.Show();
        }
    }
}
