using System.Web.Http;

namespace CalculatorService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "calculator/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "QueryApi",
                routeTemplate: "journal/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
