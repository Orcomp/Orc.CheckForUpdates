// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Version.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   The version.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.Models
{
    using System;

    /// <summary>
    /// The version.
    /// </summary>
    public class Version
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether stable.
        /// </summary>
        public bool Stable { get; set; }

        /// <summary>
        /// Gets or sets the download url.
        /// </summary>
        public string DownloadUrl { get; set; }

        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        public DateTime? ExpirationDate { get; set; }
    }
}
