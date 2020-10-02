using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApplication4
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //ADD MANUALMENTE...REMOVE A FORMATAÇÃO PADRÃO EM XML DO PROJETO NAS CONSULTAS DA API
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //IDENTA A FORMATAÇÃO DO JSON
            config.Formatters.JsonFormatter.Indent = true;

        }
    }
}
