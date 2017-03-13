using System.Web.Mvc;
using System.Web.Routing;

namespace SnappetChallenge
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //// add Web Api routes
            //routes.MapRoute(
            //    name: "WebApi",
            //    url: "api/{controller}/{id}",
            //    defaults: new { controller = "Data", action = "GetResponseData", id = UrlParameter.Optional }
            //);

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
