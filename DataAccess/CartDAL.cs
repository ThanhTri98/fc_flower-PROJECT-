using MyDataBase;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class CartDAL
    {
        ADO_FcFlower aDO_FcFlower = new ADO_FcFlower();
        public void addToCart(DonHang don_hang, List<ChiTietDonHang> chiTietDonHangs)
        {
            // Thêm vào đơn hàng
            aDO_FcFlower.DonHang.Add(don_hang);
            // Thêm vào Chi tiết đơn hàng
            foreach (ChiTietDonHang ctdh in chiTietDonHangs)
            {
                aDO_FcFlower.ChiTietDonHang.Add(ctdh);
            }
            aDO_FcFlower.SaveChanges();
        }

    }
}
