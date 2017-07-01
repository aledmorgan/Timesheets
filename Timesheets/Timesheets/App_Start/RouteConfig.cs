using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Timesheets
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Service",
                url: "ServiceController/{action}",
                defaults: new { controller = "Service", action = "{action}" }
            );

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Layout", action = "Index", id = UrlParameter.Optional }
            );

            

            
        }
    }
}
