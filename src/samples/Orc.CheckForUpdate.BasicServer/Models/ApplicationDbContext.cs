// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationDbContext.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   Defines the ApplicationUser type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.BasicServer.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    /// The application db context.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}