using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TodoApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",

                //http://localhost:8080/Todoes/Details/3
                //{controller}=TodoesController
                //{action}=Details
                //{id}=3
                url: "{controller}/{action}/{id}",

                //デフォルトページの設定
                //http://localhost:8080/
                //{controller}=TodoesController
                //{action}=index
                //{id}=(null)
                defaults: new { controller = "Todoes", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
