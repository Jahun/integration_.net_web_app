using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Integration
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "index",id="" }
           );

            routes.MapRoute(
             name: "Account",
             url: "{controller}/{action}/{form}",
             defaults: new { controller = "Account", action = "account", form = "" }
            );


            routes.MapRoute(
                name: "Person",
                url: "{controller}/{action}/{country}/{city}/{region}/{order_by}/{order_type}/{view_count}/{page}",
                defaults: new { controller = "Person", action = "GetPersons", country = "", city = "", region = "", order_by = "", order_type = "", view_count = "", page = "" }
            );

          

           

        }
    }
}