using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DB1.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;


            jsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
            //Removendo XML
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            //Formato de como será exposto a informação
            settings.Formatting = Formatting.Indented;
            //Convert propriedades em Minusculo
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();


            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
