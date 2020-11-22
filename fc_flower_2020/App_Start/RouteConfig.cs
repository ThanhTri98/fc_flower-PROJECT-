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
              url: "chi-tiet-san-pham/{id}",
              defaults: new { controller = "Product", action = "ProductDetail" }
          );
            routes.MapRoute(
             name: "Product",
             url: "san-pham/{name}/{type}",
             defaults: new { controller = "Product", action = "Product", type = UrlParameter.Optional }
         );
            routes.MapRoute(
                       name: "GiftType",
                       url: "qua-tang-kem/{ma_loai}",
                       defaults: new { controller = "Gift", action = "GiftType" }
                   );
            routes.MapRoute(
                       name: "Gift",
                       url: "qua-tang-kem",
                       defaults: new { controller = "Gift", action = "GiftHome" }
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
