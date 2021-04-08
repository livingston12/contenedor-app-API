using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Contenedor_WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(
            config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml"));

            string urlApp = "";
            try
            {
                urlApp = System.Configuration.ConfigurationManager.AppSettings["urlApp"];
            }
            catch (Exception)
            {
                urlApp = "";
            }

            var cors = new EnableCorsAttribute(urlApp, "*", "*");

            config.EnableCors(cors);
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
