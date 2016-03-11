using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhotosStore.WebUI
{
    public class RouteConfig
    {
<<<<<<< HEAD
        //настройка маршрутизации
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //дефолтный маршрут
=======
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
            routes.MapRoute(null,
                "",
                new
                {
                    controller = "PhotoTechnique",
                    action = "List",
                    category = (string)null,
                    page = 1
                }
            );
<<<<<<< HEAD
            //для обеспечения просмотра страниц
=======

>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "PhotoTechnique", action = "List", category = (string)null },
                constraints: new { page = @"\d+" }
            );
<<<<<<< HEAD
            //для отображения товаров по категориям
            routes.MapRoute(null, "{category}", new { controller = "PhotoTechnique", action = "List", page = 1 });
            //по категориям и страницам
            routes.MapRoute(null,"{category}/Page{page}", new { controller = "PhotoTechnique", action = "List" }, new { page = @"\d+" });
            //общий маршрут
=======

            routes.MapRoute(null, "{category}", new { controller = "PhotoTechnique", action = "List", page = 1 });

            routes.MapRoute(null,"{category}/Page{page}", new { controller = "PhotoTechnique", action = "List" }, new { page = @"\d+" });

>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
