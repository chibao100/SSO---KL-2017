using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Movie
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "IDPhim",
              url: "XemPhim/IdPhim/{id}/{tap}",
              defaults: new { controller = "XemPhim", action = "IdPhim", id = UrlParameter.Optional, tap = UrlParameter.Optional }
          );

            routes.MapRoute(
               name: "XemPhim",
               url: "XemPhim/{name}/{tap}",
               defaults: new { controller = "XemPhim", action = "Index", name = UrlParameter.Optional, tap = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}
