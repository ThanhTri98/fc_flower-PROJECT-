using fc_flower_2020.Models;
using MyDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fc_flower_2020.Controllers
{
    public class ProductController : Controller
    {
        ProductModel productModel = new ProductModel();
        public ActionResult Product(string name, string type)
        {
            List<Hoa> hoas = new List<Hoa>();
            if (name.Equals("chu-de"))
            {
                ViewBag.ACTION = "CHỦ ĐỀ";
                ViewBag.NAME = productModel.getTenChuDe(type);
                ViewBag.LIST = Utils.convertStringArray<List<ChuDe>>(productModel.getDanhSachChuDe(), name);
                hoas = productModel.getHoaTheoChuDe(type);
            }
            else if (name.Equals("mau-sac"))
            {
                ViewBag.ACTION = "MÀU SẮC";
                ViewBag.NAME = productModel.getTenMauSac(type);
                ViewBag.LIST = Utils.convertStringArray<List<MauSac>>(productModel.getDanhSachMauSac(), name);
                hoas = productModel.getHoaTheoMauSac(type);
            }
            ViewBag.TYPE = type;
            hoas.Shuffle();
            return View(hoas);
        }
        public ActionResult ProductDetail(string id)
        {
            Hoa hoa = productModel.getHoa(int.Parse(id));
            ViewBag.DongGia = productModel.getHoaDongGia((int)hoa.gia_moi);
            ViewBag.CungLoai = productModel.getHoaCungLoai(hoa.ma_loai_hoa);
            return View(hoa);
        }


    }
}