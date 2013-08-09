using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MotorWorld
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Bikes",
                url: "Bikes",
                defaults: new { controller = "Bikes", action = "AllBikes" }
            );

            routes.MapRoute(
                name: "Trips",
                url: "Trips",
                defaults: new { controller = "Trips", action = "AllTrips" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}