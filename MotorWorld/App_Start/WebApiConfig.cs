using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MotorWorld
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableQuerySupport();

            config.Routes.MapHttpRoute(
                name: "ActionAPI",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { action = "Bikes", id = RouteParameter.Optional }
            );

            var json = config.Formatters.JsonFormatter;
            //Removes $id tag..... handles recursive references
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
