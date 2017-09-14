using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BusinessServices;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;

namespace Metrics
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

            config.Routes.MapHttpRoute(
                name: "GetTenantData",
                routeTemplate: "api/{controller}/{id}/{status}"
            );

            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            config.Formatters.JsonFormatter.SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };



            // Unity Configuration
            var container = new UnityContainer();
            container.RegisterType<ITenantServices, TenantServices>(new HierarchicalLifetimeManager());
            container.RegisterType<IJobServices, JobServices>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

        }

    }
}
