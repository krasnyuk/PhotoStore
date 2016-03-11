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
        //настройка маршрутизации
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //дефолтный маршрут
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
            //для обеспечения просмотра страниц
            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "PhotoTechnique", action = "List", category = (string)null },
                constraints: new { page = @"\d+" }
            );
            //для отображения товаров по категориям
            routes.MapRoute(null, "{category}", new { controller = "PhotoTechnique", action = "List", page = 1 });
            //по категориям и страницам
            routes.MapRoute(null,"{category}/Page{page}", new { controller = "PhotoTechnique", action = "List" }, new { page = @"\d+" });
            //общий маршрут
            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
