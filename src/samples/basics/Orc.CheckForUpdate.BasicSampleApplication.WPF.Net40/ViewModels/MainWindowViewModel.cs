// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   Defines the MainWindowViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.BasicSampleApplication.WPF.Net40.ViewModels
{
    using Orc.CheckForUpdate.BasicSampleApplication.WPF.Net40.Models;
    using Orc.CheckForUpdate.Client;

    /// <summary>
    /// The main window view model.
    /// </summary>
    public class MainWindowViewModel
    {
        private IVersioningService versioningService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        /// <param name="versioningService">
        /// The versioning Service.
        /// </param>
        public MainWindowViewModel(IVersioningService versioningService)
            : this(new MainModel(), versioningService)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <param name="versioningService">
        /// The versioning Service.
        /// </param>
        public MainWindowViewModel(MainModel model, IVersioningService versioningService)
        {
            Model = model;
            this.versioningService = versioningService;
        }

        /// <summary>
        /// Gets the model.
        /// </summary>
        public MainModel Model { get; private set; }
    }
}
