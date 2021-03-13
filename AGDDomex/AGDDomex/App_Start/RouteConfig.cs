using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AGDDomex
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "JedenKatalog",
                "KatalogProduktow/katalog/{index}",
                new { controller = "Produkt", action = "jedenKatalog" }
                );

            routes.MapRoute(
                "JedenProdukt",
                "KatalogProduktow/produkt/{index}/{mess}",
                new { controller = "Produkt", action = "jedenProdukt", mess = UrlParameter.Optional }
                );

            routes.MapRoute(
                "Add",
                "Koszyk/1/{index}",
                new { controller = "Koszyk", action = "Add" }
                 );

            routes.MapRoute(
                "Add2",
                "Kinga/Koszyk/{index}/{mess}",
                new { controller = "Koszyk", action = "Add2", mess = UrlParameter.Optional }
                );

            routes.MapRoute(
                "koszyk",
                "Kinga/Koszyk",
                new { controller = "Koszyk", action = "Koszyk" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
