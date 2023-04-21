using System.Web.Mvc;
using System.Web.Routing;

namespace FifthLab
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Version2Parameter",
                url: "V2/{controller}/{action}",
                defaults: new { controller = "MResearch", action = "M02" }
            );
            routes.MapRoute(
                name: "Version3Parameter",
                url: "V3/{controller}/{x}/{action}",
                defaults: new { controller = "MResearch", action = "M03", x = UrlParameter.Optional}
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MResearch", action = "M01", id = UrlParameter.Optional }
            );
        }
    }
}
