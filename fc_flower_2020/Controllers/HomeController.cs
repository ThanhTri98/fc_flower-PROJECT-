using fc_flower_2020.Models;
using System.Web.Mvc;

namespace fc_flower_2020.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProductModel productModel = new ProductModel();
            ViewBag.ProductNew = productModel.getHoaTheoTrangThai(4);
            ViewBag.ProductSale = productModel.getHoaTheoTrangThai(2);
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
    }
}