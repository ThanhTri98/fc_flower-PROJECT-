using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using MyDataBase;

namespace fc_flower_2020.Models
{
    public class LayoutMainModel
    {
        LayoutDAL layoutMain = new LayoutDAL();
        public List<ChuDe> getDanhSachChuDe()
        {
            return layoutMain.getDanhSachChuDe();
        }
        public List<MauSac> getDanhSachMauSac()
        {
            return layoutMain.getDanhSachMauSac();
        }
        public List<LoaiQuaTang> getDanhSachLoaiQua()
        {
            return layoutMain.getDanhSachLoaiQua();
        }
    }
}