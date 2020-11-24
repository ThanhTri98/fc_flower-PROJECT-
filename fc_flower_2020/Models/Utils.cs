using MyDataBase;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

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
        public static string ConvertToMD5(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}


