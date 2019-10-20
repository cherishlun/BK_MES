using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BK_MES_MVC.App_Code
{
    public class WebHelper
    {
        public static void SetCookie(db_models.YongHu aYH)
        {
            HttpCookie cook = new HttpCookie("Bk_MES");

            cook.Values.Set("yhbm", aYH.yhbm.ToString());
            cook.Values.Set("yhms", aYH.yhms.ToString());
            cook.Values.Set("yhqxm", aYH.yhqxm.ToString());
            cook.Values.Set("yhxm", aYH.yhxm.ToString());
            cook.Values.Set("yhdlm", aYH.yhdlm.ToString());

            cook.Expires.AddDays(1);//设置过期时间
            HttpContext.Current.Response.SetCookie(cook);//若已有此cookie，更新内容
            HttpContext.Current.Response.Cookies.Add(cook);//添加此cookie
        }

        public static db_models.YongHu GetCookie()
        {
            db_models.YongHu _ayh = new db_models.YongHu();
            HttpCookie cook = HttpContext.Current.Request.Cookies["Bk_MES"];
            if (cook != null)
            {
                _ayh.yhbm = Convert.ToInt16(cook.Values["yhbm"]);
                _ayh.yhms = cook.Values["yhms"];
                _ayh.yhqxm = Convert.ToInt16(cook.Values["yhqxm"]);
                _ayh.yhxm = cook.Values["yhxm"];
                _ayh.yhdlm = cook.Values["yhdlm"];
            }
            return _ayh;
        }

        public static string GetCookie(string cname)
        {
            string _value=null;
            db_models.YongHu _ayh = new db_models.YongHu();
            HttpCookie cook = HttpContext.Current.Request.Cookies["Bk_MES"];
            if (cook != null)
            {
                try
                {
                    _value = cook.Values[cname];
                }
                catch(Exception ex)
                {
                    _value = null;
                }
            }
            return _value;
        }

        public static void DeleCookie()
        {
            HttpCookie cook = HttpContext.Current.Request.Cookies["Bk_MES"];
            if (cook != null)
            {
                cook.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.SetCookie(cook);//若已有此cookie，更新内容
                HttpContext.Current.Response.Cookies.Add(cook);//添加此cookie
            }
        }

        public static bool ExistsCookie()
        {
            HttpCookie cook = HttpContext.Current.Request.Cookies["Bk_MES"];
            if (cook != null)
            {
                if (Convert.ToInt16(cook.Values["yhbm"]) > 0)
                    return true;

            }

            return false;
        }

        /// <summary>
        /// 16位MD5加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string MD5Encrypt16(string cpw)
        {
            var md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(cpw)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }

        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string MD5Encrypt32(string password)
        {
            string cl = password;
            string pwd = "";
            MD5 md5 = MD5.Create(); //实例化一个md5对像
                                    // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                pwd = pwd + s[i].ToString("X");
            }
            return pwd;
        }
        public static string MD5Encrypt64(string password)
        {
            string cl = password;
            //string pwd = "";
            MD5 md5 = MD5.Create(); //实例化一个md5对像
                                    // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            return Convert.ToBase64String(s);
        }

    }

}