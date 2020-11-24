using DataAccess;
using MyDataBase;
using System.Collections.Generic;

namespace fc_flower_2020.Models
{
    public class GiftModel
    {
        GiftDAL gift = new GiftDAL();
        public List<LoaiQuaTang> getDanhSachLoaiQua()
        {
            return new LayoutMainModel().getDanhSachLoaiQua();
        }
        public string getTenQuaTang(string ma_loai)
        {
            return gift.getTenQuaTang(ma_loai);
        }
        public List<QuaTangKem> getDanhSachQuaTangKem(string ma_loai, int take)
        {
            return gift.getDanhSachQuaTangKem(ma_loai, take);
        }
        public QuaTangKem getQuaTangKem(int ma_qua)
        {
            return gift.getQuaTangKem(ma_qua);
        }
    }
}