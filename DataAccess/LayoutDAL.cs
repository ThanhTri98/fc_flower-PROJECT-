using MyDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{

    public class LayoutDAL
    {
        ADO_FcFlower aDO_FcFlower = new ADO_FcFlower();
        public List<ChuDe> getDanhSachChuDe()
        {
            return aDO_FcFlower.ChuDe.ToList();
        }
        public List<MauSac> getDanhSachMauSac()
        {
            return aDO_FcFlower.MauSac.ToList();
        }
        public List<LoaiQuaTang> getDanhSachLoaiQua()
        {
            return aDO_FcFlower.LoaiQuaTang.ToList();
        }
    }
}
