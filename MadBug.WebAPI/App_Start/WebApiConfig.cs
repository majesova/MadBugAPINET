using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using System.Web.Http.Cors;

namespace MadBug.WebAPI
{

    
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // CORS
            //var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            //config.EnableCors();

            // Configuración y servicios de Web API
            // Configure Web API para usar solo la autenticación de token de portador.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Clear();

            var jsonFormatter = new JsonMediaTypeFormatter
            {
                SerializerSettings = { ContractResolver = new CamelCasePropertyNamesContractResolver() }
            };
            jsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            jsonFormatter.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            jsonFormatter.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
            config.Formatters.Add(jsonFormatter);
        }
    }
}
