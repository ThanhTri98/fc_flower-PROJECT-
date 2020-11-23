using DataAccess;
using MyDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fc_flower_2020.Models
{
    public class FlowerMeaningModel
    {
        FlowerMeaningDAL flowerMeaning = new FlowerMeaningDAL();
        public List<LoaiHoa> getDanhSachLoaiHoa()
        {
            return flowerMeaning.getDanhSachLoaiHoa();
        }
        public YNghiaHoa getYNghiaHoa(int ma_y_nghia)
        {
            return flowerMeaning.getYNghiaHoa(ma_y_nghia);
        }
        public string getHinhAnh(int ma_y_nghia)
        {
            return flowerMeaning.getHinhAnh(ma_y_nghia);
        }
        public string getTenHoa(int ma_y_nghia)
        {
            return flowerMeaning.getTenHoa(ma_y_nghia);
        }
    }
}