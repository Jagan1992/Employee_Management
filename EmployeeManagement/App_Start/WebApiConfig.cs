using System;
using System.Linq;
using Newtonsoft.Json;
using System.Web.Http;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Serialization;


namespace EmployeeManagement
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //Getting the xmlType Format.
            var xmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.SingleOrDefault(x => x.MediaType == "application/xml");

            //configuring the camel case format globally for returning the JSON object in camelcase.
            var settings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //Removing the xmlType Format.
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(xmlType);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );     
        }
    }
}
