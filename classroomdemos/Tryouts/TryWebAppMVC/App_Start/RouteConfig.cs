using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TryWebAppMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();


            // Custom route example
            routes.MapRoute(
                name: "CustomRoute",
                url: "products/{category}/{id}",
                defaults: new { controller = "Products", action = "Details", id = UrlParameter.Optional },
                constraints: new { category = @"\w+" } // Constraints for category (only letters/numbers)
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
