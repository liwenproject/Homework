using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Homework
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "MoneyAdd",
            url: "skilltree/{yyyy}/{mm}",
            defaults: new
            {
                controller = "Money",
                action = "Add",
                yyyy = UrlParameter.Optional,
                mm = UrlParameter.Optional
            }
            , namespaces: new[] { "Homework.Controllers" }
            );

            routes.MapRoute(
            name: "MoneyGeneral",
            url: "skilltree/{action}/{yyyy}/{mm}",
            defaults: new
            {
                controller = "Money"
            }
            , namespaces: new[] { "Homework.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
                , namespaces: new[] { "Homework.Controllers" }
            );
        }
    }
}
