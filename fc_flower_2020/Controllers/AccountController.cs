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
            string password = data["password"];
            TaiKhoan taiKhoan = new AccountModel().checkLogin(username, password);
            JsonResult jsr = new JsonResult();
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
                    status = "OK"
                };
            }
            return Json(jsr, JsonRequestBehavior.AllowGet);
        }
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
                taiKhoan.mat_khau = password;
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
        public void Logout()
        {
            Session.Clear();
            Response.Redirect("/trang-chu");
        }

    }
}