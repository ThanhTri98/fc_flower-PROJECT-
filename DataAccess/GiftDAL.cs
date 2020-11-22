using MyDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GiftDAL
    {
        ADO_FcFlower aDO_FcFlower = new ADO_FcFlower();
        public string getTenQuaTang(string ma_loai)
        {
            return aDO_FcFlower.LoaiQuaTang.FirstOrDefault(c => c.ma_loai == ma_loai).ten_loai;
        }
        public List<QuaTangKem> getDanhSachQuaTangKem(string ma_loai, int take)
        {
            if (take == 4) // GiftHome
                return aDO_FcFlower.QuaTangKem.Where(c => c.ma_loai == ma_loai).Take(take).ToList();
            return aDO_FcFlower.QuaTangKem.Where(c => c.ma_loai == ma_loai).ToList();
        }
    }
}
