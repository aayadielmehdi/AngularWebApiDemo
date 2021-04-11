using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Web.Http.Cors;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // on l'ajout pour permettre au api de retourner du json.
            // si je mets pas cette ligne , j'aurai pas resultat de mon api si il est de datatable.
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // * pour tous domaine , si je mets google , google va pouvoir acceder a mon api !!
            // cors c'est un mécanisme qui permet à des ressources d'une page d'être recupérer par un autre domaine exterieure # du premier ressource.
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

        }
    }
}
