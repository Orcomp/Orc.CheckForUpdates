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

    /// <summary>
    /// The main window view model.
    /// </summary>
    public class MainWindowViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel() : this(new MainModel())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public MainWindowViewModel(MainModel model)
        {
            Model = model;
        }

        /// <summary>
        /// Gets the model.
        /// </summary>
        public MainModel Model { get; private set; }
    }
}
