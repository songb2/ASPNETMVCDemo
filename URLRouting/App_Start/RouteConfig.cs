using System.Web.Mvc;
using System.Web.Routing;
using URLRouting.Infrastructure;

namespace URLRouting
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // UrlRoutingModule-4.0
            routes.RouteExistingFiles = true;

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /* Constrianing a Route Using a Regrular Expression */
            //routes.MapRoute(
            //    "MyRoute",
            //    "{controller}/{action}/{id}",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    new { controller = "^H.*" }
            //);

            /* Constraining a Route to a Set of Specific Values */
            //routes.MapRoute(
            //    "MyRoute",
            //    "{controller}/{action}/{id}",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    new { controller = "^H.*", action = "^Index$|^About$"}
            //);

            /* Constraining a Route Using HTTP Methods */
            //routes.MapRoute(
            //    "Default",
            //    "{controller}/{action}/{id}",
            //    new { controller = "Product", action = "Index", id = UrlParameter.Optional },
            //    new { controller = "^P.*", httpMethod = new HttpMethodConstraint("GET", "POST") }
            //);


            /* Defining a Custom Constraint by implementing IRouteConstraint */

            //routes.MapRoute("ChromeRoute", "{*catchall}",
            //new { controller = "Home", action = "Index" },
            //new { customConstraint = new UserAgentConstraint("Chrome") });

            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
            //new { controller = "Product", action = "Index", id = UrlParameter.Optional });


            /* Using the Routing System to Generate an Outgoing URL */
            //routes.MapRoute("NewRoute", "App/Do{action}", new { controller = "Product" });

            routes.MapRoute("MyRoute", "{controller}/{action}/{id}",
            new { controller = "Product", action = "Index", id = UrlParameter.Optional });
        }
    }
}
