using DataAccess;
using MyDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fc_flower_2020.Models
{
    public class AccountModel
    {
        AccountDAL account = new AccountDAL();
        public TaiKhoan checkLogin(string tai_khoan, string mat_khau)
        {
            return account.checkLogin(tai_khoan, mat_khau);
        }
        public bool kiemTraTonTai(string field, string noiDung)
        {
            return account.kiemTraTonTai(field, noiDung);
        }
        public void taoTaiKhoan(TaiKhoan taiKhoan)
        {
            account.taoTaiKhoan(taiKhoan);
        }
    }
}