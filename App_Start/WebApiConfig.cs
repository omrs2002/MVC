using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MVCCourse2017
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //formating JSON as Camel:
            var sett = config.Formatters.JsonFormatter.SerializerSettings;
            sett.ContractResolver = new CamelCasePropertyNamesContractResolver();
            sett.Formatting = Newtonsoft.Json.Formatting.Indented;



            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute
                (
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{action}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            /*
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            */



        }
    }
}
