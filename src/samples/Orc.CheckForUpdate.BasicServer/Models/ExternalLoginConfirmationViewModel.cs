// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExternalLoginConfirmationViewModel.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   Defines the ExternalLoginConfirmationViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.BasicServer.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The external login confirmation view model.
    /// </summary>
    public class ExternalLoginConfirmationViewModel
    {
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        /// <value>
        /// The user name.
        /// </value>
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }
}