// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagingInfo.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   The paging info.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.Web.Models
{
    using System;

    /// <summary>
    /// The paging info.
    /// </summary>
    public class PagingInfo
    {
        /// <summary>
        /// Gets or sets the total items.
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Gets or sets the items per page.
        /// </summary>
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Gets the total pages.
        /// </summary>
        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)this.TotalItems / this.ItemsPerPage);
            }
        }
    }
}
