using DataAccess;
using MyDataBase;
using System;
using System.Collections.Generic;

namespace fc_flower_2020.Models
{
    public class Cart
    {
        public string ma_dh { get; set; }
        public string tai_khoan { get; set; }
        public List<CartItem> items { get; set; }
        public int ma_pttt { get; set; }
        public string ngay_mua { get; set; }
        public int TotalItem()
        {
            int count = 0;
            if (items != null && items.Count != 0)
            {
                foreach (CartItem i in items)
                {
                    count += i.so_luong;
                }
            }

            return count;
        }

        public int TotalPrice()
        {
            int price = 0;
            if (items != null && items.Count != 0)
            {
                foreach (CartItem i in items)
                {
                    price += i.gia * i.so_luong;
                }
            }
            return price;
        }
        public void addToCart(Cart cart)
        {
            CartDAL cartDAL = new CartDAL();
            DonHang donHang = new DonHang();
            string ma_dh = Guid.NewGuid().ToString();// Sinh ra 1 đoạn mã khác nhau trên toàn thế giới -> làm PK
            string tai_khoan = cart.tai_khoan;
            string ngay_mua = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            int ma_pttt = (int)cart.ma_pttt;
            donHang.ma_dh = ma_dh;
            donHang.tai_khoan = tai_khoan;
            donHang.ngay_mua = ngay_mua;
            donHang.ma_pttt = ma_pttt;
            //
            List<ChiTietDonHang> chiTietDonHangs = new List<ChiTietDonHang>();
            ChiTietDonHang ctdh;
            foreach (CartItem item in cart.items)
            {
                ctdh = new ChiTietDonHang();
                ctdh.ma_dh = ma_dh;
                ctdh.ma_loai_hang = item.ma_loai_hang;
                ctdh.ma_hang = item.ma_hang;
                int soLuong = (int)item.so_luong;
                ctdh.so_luong = soLuong;
                int gia = typeof(Hoa).IsInstanceOfType(item.san_pham) ? (int)(item.san_pham as Hoa).gia_moi : (int)(item.san_pham as QuaTangKem).gia;
                ctdh.tong_gia = soLuong * gia;
                chiTietDonHangs.Add(ctdh);
            }
            cartDAL.addToCart(donHang, chiTietDonHangs);
        }
    }
}