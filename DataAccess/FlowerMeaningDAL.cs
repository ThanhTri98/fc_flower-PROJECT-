using MyDataBase;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class FlowerMeaningDAL
    {
        ADO_FcFlower aDO_FcFlower = new ADO_FcFlower();
        public List<LoaiHoa> getDanhSachLoaiHoa()
        {
            return aDO_FcFlower.LoaiHoa.ToList();
        }
        public YNghiaHoa getYNghiaHoa(int ma_y_nghia)
        {
            return aDO_FcFlower.YNghiaHoa.FirstOrDefault(c => c.ma_y_nghia == ma_y_nghia);
        }

        public string getHinhAnh(int ma_y_nghia)
        {
            return aDO_FcFlower.LoaiHoa.Where(c => c.ma_y_nghia == ma_y_nghia).FirstOrDefault().hinh_anh;
        }
        public string getTenHoa(int ma_y_nghia)
        {
            return aDO_FcFlower.LoaiHoa.Where(c => c.ma_y_nghia == ma_y_nghia).FirstOrDefault().ten_loai_hoa;
        }
    }
}
