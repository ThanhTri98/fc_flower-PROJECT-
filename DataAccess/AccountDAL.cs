using MyDataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccountDAL
    {
        ADO_FcFlower aDO_FcFlower = new ADO_FcFlower();
        public TaiKhoan checkLogin(string tai_khoan, string mat_khau)
        {
            return aDO_FcFlower.TaiKhoan.Where(c => c.tai_khoan == tai_khoan && c.mat_khau == mat_khau).FirstOrDefault();
        }
        public void taoTaiKhoan(TaiKhoan taiKhoan)
        {
            aDO_FcFlower.TaiKhoan.Add(taiKhoan);
            aDO_FcFlower.SaveChanges();
        }
        public bool kiemTraTonTai(string field, string noiDung)
        {
            if (!field.Equals("tai_khoan") && !field.Equals("email")) return false;
            string sql = "SELECT * FROM TAIKHOAN WHERE " + field + "=@CT";
            return aDO_FcFlower.Database.SqlQuery<TaiKhoan>(sql, new SqlParameter("@CT", noiDung)).FirstOrDefault() != null;
        }
    }
}
