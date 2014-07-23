// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginViewModel.cs" company=ORC"">
//   MS-PL
// </copyright>
// <summary>
//   Defines the LoginViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.BasicServer.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The login view model.
    /// </summary>
    public class LoginViewModel
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

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether remember me.
        /// </summary>
        /// <value>
        /// The remember me.
        /// </value>
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}