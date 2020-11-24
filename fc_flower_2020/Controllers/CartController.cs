using fc_flower_2020.Models;
using MyDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fc_flower_2020.Controllers
{
    public class CartController : Controller
    {
        private const string cartSession = "CartSession";
        ProductModel product = new ProductModel();
        GiftModel gift = new GiftModel();
        // GET: Cart
        public ActionResult Cart()
        {
            return View();
        }
        public JsonResult AddItem(FormCollection data)
        {
            string loai_hang = data["loai-hang"];
            string ma_hang = data["ma-hang"];
            string so_luong = data["so-luong"];
            string update = data["update"];
            int soLuong;


            Object sp = null;
            try
            {
                if (loai_hang == "1")
                {
                    sp = product.getHoa(int.Parse(ma_hang));
                }
                else if (loai_hang == "2")
                {
                    sp = gift.getQuaTangKem(int.Parse(ma_hang));
                }
            }
            catch (Exception)
            {
            }

            if (sp != null)
            {
                Cart cart = Session[cartSession] as Cart;
                if (!String.IsNullOrEmpty(so_luong))
                {
                    soLuong = Convert.ToInt32(so_luong);
                    if (cart == null)
                    {
                        cart = new Cart();
                        List<CartItem> items = new List<CartItem>();
                        CartItem item = new CartItem();
                        if (loai_hang == "1")
                        {
                            Hoa hoa = sp as Hoa;
                            item.ma_loai_hang = 1;
                            item.san_pham = hoa;
                            item.gia = (int)hoa.gia_moi;
                            item.so_luong = soLuong;
                            item.ma_hang = hoa.ma_hoa;
                        }
                        else
                        {
                            QuaTangKem quaTangKem = sp as QuaTangKem;
                            item.ma_loai_hang = 2;
                            item.san_pham = quaTangKem;
                            item.gia = (int)quaTangKem.gia;
                            item.so_luong = soLuong;
                            item.ma_hang = quaTangKem.ma_qua;
                        }
                        items.Add(item);
                        cart.items = items;
                    }
                    else
                    {
                        List<CartItem> items = cart.items;
                        bool check = false;
                        if (loai_hang == "1")
                        {
                            foreach (CartItem i in items)
                            {

                                if ((i.ma_hang == (sp as Hoa).ma_hoa))
                                {
                                    if (update == null && soLuong == 1)
                                    {
                                        i.so_luong = i.so_luong + 1;
                                    }
                                    else
                                    {
                                        i.so_luong = soLuong;
                                    }
                                    check = true;
                                }
                            }
                        }
                        else
                        {
                            foreach (CartItem i in items)
                            {
                                if ((i.ma_hang == (sp as QuaTangKem).ma_qua))
                                {
                                    if (update == null && soLuong == 1)
                                    {
                                        i.so_luong = i.so_luong + 1;
                                    }
                                    else
                                    {
                                        i.so_luong = soLuong;
                                    }
                                    check = true;
                                }
                            }
                        }
                        if (!check)
                        {
                            CartItem item = new CartItem();
                            item.so_luong = soLuong;
                            if (loai_hang == "1")
                            {
                                Hoa hoa = sp as Hoa;
                                item.san_pham = hoa;
                                item.gia = (int)hoa.gia_moi;
                                item.ma_hang = hoa.ma_hoa;
                            }
                            else
                            {
                                QuaTangKem quaTangKem = sp as QuaTangKem;
                                item.san_pham = quaTangKem;
                                item.gia = (int)quaTangKem.gia;
                                item.ma_hang = quaTangKem.ma_qua;
                            }
                            items.Add(item);
                        }
                    }
                }
                else
                {
                    //xoa 1 item ra gio hang
                    //List<Item> items = gh.Item;
                    //foreach (Item item in items)
                    //{
                    //    if (item.Product.ProductId == sp.ProductId)
                    //    {
                    //        items.Remove(item);
                    //        break;
                    //    }
                    //}
                }
                Session.Add(cartSession,cart);
            }
            JsonResult jsr = new JsonResult();
            Cart currentCart = Session[cartSession] as Cart;
            jsr.Data = new
            {   
                status = "OK",
                totalItem = currentCart.TotalItem().ToString(), 
                totalPrice = Utils.toCurrency(currentCart.TotalPrice())
            };
            return Json(jsr, JsonRequestBehavior.AllowGet);
        }
    }
}
