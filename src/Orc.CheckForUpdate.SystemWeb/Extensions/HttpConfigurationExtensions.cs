namespace Orc.CheckForUpdate.SystemWeb.Extensions
{
    using System.Web.Http;
    using System.Web.Mvc;

    public static class VersionsApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "VersionApi",
                routeTemplate: "api/versions/{id}",
                defaults: new { controller = "Versions", id = RouteParameter.Optional });

            System.Web.Mvc.ControllerBuilder.Current.DefaultNamespaces.Add("Orc.CheckForUpdate.Web.Controllers");
        }
    }
}
