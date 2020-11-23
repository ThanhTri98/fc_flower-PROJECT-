using MyDataBase;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess
{
    public class ProductDAL
    {
        ADO_FcFlower aDO_FcFlower = new ADO_FcFlower();
        // Lấy tất cả các hoa theo trạng thái hoa, ví dụ [khuyến mãi, hot]
        public List<Hoa> getHoaTheoTrangThai(int ma_tth)
        {
            return aDO_FcFlower.Hoa.Where(c => c.ma_tth == ma_tth).Take(8).ToList();
        }
        public Hoa getHoa(int id)
        {
            return aDO_FcFlower.Hoa.Where(c => c.ma_hoa == id).FirstOrDefault();
        }
        public List<Hoa> getHoaCungLoai(string ma_loai_hoa)
        {
            return aDO_FcFlower.Hoa.Where(hoa => hoa.ma_loai_hoa == ma_loai_hoa).Take(10).ToList();
        }
        public List<Hoa> getHoaDongGia(int gia)
        {
            int giaChenhLech = 50000;
            return aDO_FcFlower.Hoa.Where(hoa => hoa.gia_moi > (gia-giaChenhLech) && hoa.gia_moi<(gia+giaChenhLech)).Take(10).OrderBy(c=>c.tieu_de).ToList();
        }

        //TOPIC
        public string getTenChuDe(string ma_chu_de)
        {
            return aDO_FcFlower.ChuDe.FirstOrDefault(c => c.ma_chu_de == ma_chu_de).ten_chu_de;
        }
        public string getTenMauSac(string ma_mau_sac)
        {
            return aDO_FcFlower.MauSac.FirstOrDefault(c => c.ma_mau_sac==ma_mau_sac).ten_mau_sac;
        }
        public List<Hoa> getHoaTheoChuDe(string ma_chu_de)
        {
            List<Hoa> hoa = aDO_FcFlower
                .Database.SqlQuery<Hoa>("SELECT H.* FROM HOA AS H JOIN HOATHEOCHUDE AS HTCD ON H.MA_HOA=HTCD.MA_HOA AND HTCD.MA_CHU_DE=@MCD"
                ,new SqlParameter("@MCD", ma_chu_de))
                .ToList();
            return hoa;
        }
        public List<Hoa> getHoaTheoMauSac(string ma_mau_sac)
        {
            List<Hoa> hoa = aDO_FcFlower
                .Database.SqlQuery<Hoa>("SELECT * FROM HOA WHERE HOA.MA_MAU_SAC=@MMS"
                , new SqlParameter("@MMS", ma_mau_sac))
                .ToList();
            return hoa;
        }

    }
}
