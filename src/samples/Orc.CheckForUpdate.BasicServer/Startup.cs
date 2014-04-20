using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Orc.CheckForUpdate.BasicServer.Startup))]
namespace Orc.CheckForUpdate.BasicServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
