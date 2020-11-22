using Antlr.Runtime.Tree;
using MyDataBase;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace fc_flower_2020.Models
{

    public class Utils
    {

        public static string toCurrency(int curcy)
        {
            return string.Format("{0:#,##}", curcy) + "đ";
        }
        public static List<string[]> convertStringArray<T>(T listGeneric, string name)
        {
            List<string[]> rs = new List<string[]>();
            if (name.Equals("chu-de"))
            {
                List<ChuDe> chuDes = listGeneric as List<ChuDe>;
                foreach (ChuDe cd in chuDes)
                {
                    rs.Add(new string[2] { cd.ma_chu_de, cd.ten_chu_de });
                }
            }
            else if (name.Equals("mau-sac"))
            {
                List<MauSac> mauSacs = listGeneric as List<MauSac>;
                foreach (MauSac ms in mauSacs)
                {
                    rs.Add(new string[2] { ms.ma_mau_sac, ms.ten_mau_sac });
                }
            }
            else
            {
                List<LoaiQuaTang> quaTangs = listGeneric as List<LoaiQuaTang>;
                foreach (LoaiQuaTang lqt in quaTangs)
                {
                    rs.Add(new string[2] { lqt.ma_loai, lqt.ten_loai });
                }
            }

            return rs;
        }

    }
}


