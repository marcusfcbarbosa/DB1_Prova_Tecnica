using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DB1.Api
{
    public class StartUp
    {

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureWebApi(config);
            //Aceitando requisicao de qualquer dominio
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.Use(config);
        }

        public static void ConfigureWebApi(HttpConfiguration config) {

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public void ConfigureOAuth() { 
        
        }
    }
}