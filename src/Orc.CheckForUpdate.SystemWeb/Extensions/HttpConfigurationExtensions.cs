namespace Orc.CheckForUpdate.SystemWeb.Extensions
{
    using System.Web.Http;

    public static class HttpConfigurationExtensions
    {
        public static void MapVersionApi(this HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "VersionApi",
                routeTemplate: "verapi/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
