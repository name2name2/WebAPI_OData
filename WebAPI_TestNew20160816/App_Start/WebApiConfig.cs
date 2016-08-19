using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using WebAPI_TestNew20160816.Models;


namespace WebAPI_TestNew20160816
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


            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<T4>("T4");
            config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());

        }
    }
}
