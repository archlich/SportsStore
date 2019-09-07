using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vic.SportsStore.WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(//config rout
                name: "Default",
                url: "{controller}/{action}/{id}",//url templat
                defaults: 
                new
                {
                    controller = "Product",
                    action = "List",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}
