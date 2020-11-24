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
    }
}