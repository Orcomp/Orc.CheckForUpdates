// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   Defines the Startup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Orc.CheckForUpdate.BasicServer.Startup))]
namespace Orc.CheckForUpdate.BasicServer
{
    /// <summary>
    /// The web application startup.
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        /// <param name="app">
        /// The application builder.
        /// </param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
