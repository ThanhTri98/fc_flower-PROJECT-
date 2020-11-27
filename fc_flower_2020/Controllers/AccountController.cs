using fc_flower_2020.Models;
using MyDataBase;
using System.Web.Mvc;

namespace fc_flower_2020.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult LoginOrRegister()
        {
            return View();
        }
        // Xử lý đăng nhập
        [HttpPost]
        public JsonResult Login(FormCollection data)
        {
            string username = data["username"];
            string password = Utils.ConvertToMD5(data["password"]);
            TaiKhoan taiKhoan = new AccountModel().checkLogin(username, password);
            JsonResult jsr = new JsonResult();
            string link = Session["link-cart"] as string;
            if (taiKhoan == null)
            {
                jsr.Data = new
                {
                    status = "ER"
                };
            }
            else
            {
                Session.Add("TAIKHOAN", taiKhoan);
                jsr.Data = new
                {
                    status = "OK",
                    link_cart = link
                };
            }
            return Json(jsr, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Register(FormCollection data)
        {
            string email = data["email"];
            string username = data["username"];
            AccountModel accountModel = new AccountModel();
            JsonResult jsr = new JsonResult();
            if (accountModel.kiemTraTonTai("tai_khoan", username))
            {
                jsr.Data = new
                {
                    status = "ER",
                    message = "Tên tài khoản đã người sử dụng!"
                };
            }
            else if (accountModel.kiemTraTonTai("email", email))
            {
                jsr.Data = new
                {
                    status = "ER",
                    message = "Địa chỉ Email đã có người sử dụng!"
                };
            }
            else
            {
                string password = data["password"];
                string address = data["address"];
                string gender = data["gender"];
                string phone = data["phone"];
                string fullname = data["fullname"];
                TaiKhoan taiKhoan = new TaiKhoan();
                taiKhoan.tai_khoan = username;
                taiKhoan.mat_khau = Utils.ConvertToMD5(password);
                taiKhoan.email = email;
                taiKhoan.dia_chi = address;
                taiKhoan.gioi_tinh = gender;
                taiKhoan.so_dien_thoai = phone;
                taiKhoan.ho_ten = fullname;
                accountModel.taoTaiKhoan(taiKhoan);
                jsr.Data = new
                {
                    status = "OK",
                    message = "Tạo tài khoản thành công, bạn có thể đăng nhập."
                };
            }
            return Json(jsr, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UpdateInfor(FormCollection data)
        {
            string email = data["email"];
            TaiKhoan taiKhoanSS = Session["TAIKHOAN"] as TaiKhoan;
            TaiKhoan taiKhoanDB;
            AccountModel accountModel = new AccountModel();
            JsonResult jsr = new JsonResult();
            if (taiKhoanSS == null)
            {
                Logout();
            }
            else if (!email.Equals(taiKhoanSS.email) && accountModel.kiemTraTonTai("email", email))
            {
                jsr.Data = new
                {
                    status = "ER",
                    message = "Địa chỉ Email đã có người sử dụng!"
                };
            }
            else
            {
                taiKhoanDB = accountModel.getTaiKhoan(taiKhoanSS.tai_khoan);
                if (taiKhoanDB == null)
                {
                    Logout();
                }
                else
                {
                    string address = data["address"];
                    string gender = data["gender"];
                    string phone = data["phone"];
                    string fullname = data["fullname"];

                    taiKhoanDB.email = email;
                    taiKhoanDB.dia_chi = address;
                    taiKhoanDB.gioi_tinh = gender;
                    taiKhoanDB.so_dien_thoai = phone;
                    taiKhoanDB.ho_ten = fullname;
                    accountModel.saveChanges(); // Lưu lại thay đổi
                    // Cập nhật lại session
                    taiKhoanSS.email = email;
                    taiKhoanSS.dia_chi = address;
                    taiKhoanSS.gioi_tinh = gender;
                    taiKhoanSS.so_dien_thoai = phone;
                    taiKhoanSS.ho_ten = fullname;
                    jsr.Data = new
                    {
                        status = "OK",
                        message = "Cập nhật thông tin thành công."
                    };
                }

            }
            return Json(jsr, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ChangePassword(FormCollection data)
        {

            TaiKhoan taiKhoanSS = Session["TAIKHOAN"] as TaiKhoan;
            TaiKhoan taiKhoanDB;
            AccountModel accountModel = new AccountModel();
            JsonResult jsr = new JsonResult();
            if (taiKhoanSS == null)
            {
                Logout();
            }
            else
            {
                taiKhoanDB = accountModel.getTaiKhoan(taiKhoanSS.tai_khoan);
                if (taiKhoanDB == null)
                {
                    Logout();
                }
                else
                {
                    string curPassword = Utils.ConvertToMD5(data["curPassword"]); ;
                    
                    if (!curPassword.Equals(taiKhoanDB.mat_khau))
                    {
                        jsr.Data = new
                        {
                            status = "ER"
                        };
                    }
                    else
                    {
                        string newPassword = Utils.ConvertToMD5(data["newPassword"]);
                        taiKhoanDB.mat_khau = newPassword;
                        accountModel.saveChanges(); // Lưu lại thay đổi
                        // Cập nhật lại session
                        taiKhoanSS.mat_khau = newPassword;
                        jsr.Data = new
                        {
                            status = "OK"
                        };
                    }
                }

            }
            return Json(jsr, JsonRequestBehavior.AllowGet);
        }
        public void Logout()
        {
            Session.Clear();
            Response.Redirect("/trang-chu");
        }

    }
}