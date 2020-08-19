using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_AppleLaLa_Admin
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Car/Brand-Year/{brand}-{year}
            routes.MapRoute(
                name: "DeleteDesignerSchedule",
                url: "{controller}/{action}/{id}-{year}-{month}-{day}",
                defaults: new { controller = "Work_schedule", action = "Delete", id = 10001}
            );



            routes.MapRoute(
                name: "DesignerSchedule",
                url: "DesignerSchedule/{schedule_date}",
                defaults: new { controller = "Work_schedule", action = "Index", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
