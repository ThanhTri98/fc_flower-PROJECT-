using fc_flower_2020.Models;
using MyDataBase;
using System;
using System.Collections.Generic;
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
        public JsonResult CartProcess(FormCollection data)
        {
            string ma_loai_hang = data["loai-hang"];
            string ma_hang = data["ma-hang"];
            string so_luongAjax = data["so-luong"];
            string isUpdate = data["isUpdate"];
            int soLuong = 0;
            // Response
            int gia_rp = 0;

            Object sp = null;
            try
            {
                if (ma_loai_hang == "1")
                {
                    Hoa hoa = product.getHoa(int.Parse(ma_hang));
                    sp = hoa;
                    gia_rp = (int)hoa.gia_moi;

                }
                else
                {
                    QuaTangKem qua = gift.getQuaTangKem(int.Parse(ma_hang));
                    sp = qua;
                    gia_rp = (int)qua.gia;

                }
            }
            catch (Exception)
            {
            }

            if (sp != null)
            {
                Cart cart = Session[cartSession] as Cart;
                if (!String.IsNullOrEmpty(so_luongAjax)) // Thêm hoặc cập nhật số lượng item
                {
                    soLuong = Convert.ToInt32(so_luongAjax);
                    if (cart == null)
                    {
                        cart = new Cart();
                        List<CartItem> items = new List<CartItem>();
                        CartItem item = new CartItem();
                        if (ma_loai_hang == "1")
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
                        foreach (CartItem i in items)
                        {
                            //int id = typeof(Hoa).IsInstanceOfType(i.san_pham) ? (i.san_pham as Hoa).ma_hoa : (i.san_pham as QuaTangKem).ma_qua;
                            if (ma_hang == i.ma_hang + "")
                            {
                                if (isUpdate == null)
                                {
                                    i.so_luong = i.so_luong + 1;
                                }
                                else
                                {
                                    i.so_luong = soLuong;
                                }
                                check = true;
                                break;
                            }
                        }

                        if (!check)
                        {
                            CartItem item = new CartItem();
                            item.so_luong = soLuong;
                            if (ma_loai_hang == "1")
                            {
                                Hoa hoa = sp as Hoa;
                                item.san_pham = hoa;
                                item.gia = (int)hoa.gia_moi;
                                item.ma_hang = hoa.ma_hoa;
                                item.ma_loai_hang = 1;
                            }
                            else
                            {
                                QuaTangKem quaTangKem = sp as QuaTangKem;
                                item.san_pham = quaTangKem;
                                item.gia = (int)quaTangKem.gia;
                                item.ma_hang = quaTangKem.ma_qua;
                                item.ma_loai_hang = 2;
                            }
                            items.Add(item);
                        }
                    }
                }
                else // Xóa 1 item ra giỏ hàng
                {
                    List<CartItem> items = cart.items;

                    foreach (CartItem i in items)
                    {
                        //int id = typeof(Hoa).IsInstanceOfType(i.san_pham) ? (i.san_pham as Hoa).ma_hoa : (i.san_pham as QuaTangKem).ma_qua;
                        if (ma_hang == i.ma_hang + "")
                        {
                            items.Remove(i);
                            break;
                        }
                    }
                }
                Session.Add(cartSession, cart);
            }
            JsonResult jsr = new JsonResult();
            Cart currentCart = Session[cartSession] as Cart;
            if (isUpdate == null)
            {
                jsr.Data = new
                {
                    status = "OK",
                    totalItem = currentCart.TotalItem().ToString(),
                    totalPrice = Utils.toCurrency(currentCart.TotalPrice())
                };
            }
            else
            {
                jsr.Data = new
                {
                    status = "OK",
                    totalItem = currentCart.TotalItem().ToString(),
                    totalPrice = Utils.toCurrency(currentCart.TotalPrice()),
                    totalPriceOfItem = Utils.toCurrency(soLuong * gia_rp),
                };
            }

            return Json(jsr, JsonRequestBehavior.AllowGet);
        }
        public void Order(string pttt)
        {
            Cart cart = Session[cartSession] as Cart;
            TaiKhoan taiKhoan = Session["TAIKHOAN"] as TaiKhoan;
            if (cart.items.Count != 0)
            {
                cart.tai_khoan = taiKhoan.tai_khoan;
                cart.ma_pttt = int.Parse(pttt);
                new Cart().addToCart(cart);
                cart.items.Clear();
            }
            Response.Redirect("/gio-hang");
        }
    }
}
