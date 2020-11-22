using fc_flower_2020.Models;
using MyDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fc_flower_2020.Controllers
{
    public class GiftController : Controller
    {
        GiftModel giftModel = new GiftModel();
        // GET: Gift
        public ActionResult GiftHome()
        {
            return View();
        }
        public ActionResult GiftType(string ma_loai)
        {   
            List<QuaTangKem> quaTangKems = giftModel.getDanhSachQuaTangKem(ma_loai, 0);
            ViewBag.NAME = giftModel.getTenQuaTang(ma_loai);
            ViewBag.LIST = Utils.convertStringArray<List<LoaiQuaTang>>(giftModel.getDanhSachLoaiQua(), "") ;
            ViewBag.MALOAI = ma_loai;
            return View(quaTangKems);
        }
    }
}