using fc_flower_2020.Models;
using MyDataBase;
using System.Collections.Generic;
using System.Web.Mvc;

namespace fc_flower_2020.Controllers
{
    public class FlowerMeaningController : Controller
    {
        FlowerMeaningModel flowerMeaningModel = new FlowerMeaningModel();
        // GET: FlowerMeaning
        public ActionResult FlowerMeaningHome()
        {
            List<LoaiHoa> loaiHoas = flowerMeaningModel.getDanhSachLoaiHoa();
            return View(loaiHoas);
        }
        public ActionResult FlowerMeaningDetail(string ma_y_nghia)
        {
            YNghiaHoa yNghiaHoa = flowerMeaningModel.getYNghiaHoa(int.Parse(ma_y_nghia));
            ViewBag.HINHANH = flowerMeaningModel.getHinhAnh(int.Parse(ma_y_nghia));
            ViewBag.TENHOA = flowerMeaningModel.getTenHoa(int.Parse(ma_y_nghia));
            return View(yNghiaHoa);
        }
    }
}