using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BasicMVCNorthwind
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(name: "FormRoute", url: "app/forms/{controller}/{action}");

            routes.MapRoute("DefaultDetails", "{controller}/{action}/{id}", new { controller = "Products", action = "Index", id = UrlParameter.Optional });

            //routes.MapRoute("DefaultDetails", "{controller}/Details", new { controller = "Products", action = "Index", id = UrlParameter.Optional });

            //routes.MapRoute(
            //    name: "Default",
            //    url: "My{controller}/{action}/{id}",
            //    defaults: new { controller = "Products", action = "Index", id = UrlParameter.Optional }
            //);

            //            routes.MapRoute(
            //    name: "Default",
            //    url: "Products/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            
        }
    }
}