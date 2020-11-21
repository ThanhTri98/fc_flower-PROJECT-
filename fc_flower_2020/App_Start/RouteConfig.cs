using System.Web.Mvc;
using System.Web.Routing;

namespace fc_flower_2020
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
               name: "HomePage",
               url: "trang-chu",
               defaults: new { controller = "Home", action = "Index" }
           );
            routes.MapRoute(
               name: "Profile",
               url: "trang-ca-nhan",
               defaults: new { controller = "Account", action = "Profile" }
           );
            routes.MapRoute(
              name: "ProductDetail",
              url: "chi-tiet-san-pham",
              defaults: new { controller = "Product", action = "ProductDetail" }
          );
            routes.MapRoute(
             name: "Product",
             url: "san-pham",
             defaults: new { controller = "Product", action = "Product" }
         );
            routes.MapRoute(
           name: "Cart",
           url: "gio-hang",
           defaults: new { controller = "Cart", action = "Cart" }
       );
            routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
         );
        }
    }
}
