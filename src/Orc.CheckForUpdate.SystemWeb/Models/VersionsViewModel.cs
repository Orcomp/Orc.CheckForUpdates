// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VersionsViewModel.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   The paging info.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Orc.CheckForUpdate.Web.Models
{
    using System.Collections.Generic;
    using Version = Orc.CheckForUpdate.Models.Version;

    /// <summary>
    /// The versions view model.
    /// </summary>
    public class VersionsViewModel
    {
        /// <summary>
        /// Gets or sets the members.
        /// </summary>
        public List<Version> Versions { get; set; }

        /// <summary>
        /// Gets or sets the paging info.
        /// </summary>
        public PagingInfo PagingInfo { get; set; }
    }
}
