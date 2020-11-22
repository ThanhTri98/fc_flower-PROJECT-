using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using MyDataBase;

namespace fc_flower_2020.Models
{
    public class ProductModel
    {
        ProductDAL product = new ProductDAL();
        public List<Hoa> getHoaTheoTrangThai(int ma_tth)
        {
            return product.getHoaTheoTrangThai(ma_tth);
        }
        public Hoa getHoa(int id)
        {
            return product.getHoa(id);
        }
        public List<Hoa> getHoaCungLoai(string ma_loai_hoa)
        {
            return product.getHoaCungLoai(ma_loai_hoa);
        }
        public List<Hoa> getHoaDongGia(int gia)
        {
            return product.getHoaDongGia(gia);
        }
        //TOPIC MODEL

        public List<ChuDe> getDanhSachChuDe()
        {
            return new LayoutMainModel().getDanhSachChuDe();
        }

        public string getTenChuDe(string ma_chu_de)
        {
            return product.getTenChuDe(ma_chu_de);
        }
        public List<Hoa> getHoaTheoChuDe(string ma_chu_de)
        {
            return product.getHoaTheoChuDe(ma_chu_de);
        }
        // COLOR
        public List<MauSac> getDanhSachMauSac()
        {
            return new LayoutMainModel().getDanhSachMauSac();
        }
        public string getTenMauSac(string ma_mau_sac)
        {
            return product.getTenMauSac(ma_mau_sac);
        }
        public List<Hoa> getHoaTheoMauSac(string ma_mau_sac)
        {
            return product.getHoaTheoMauSac(ma_mau_sac);
        }
    }
}