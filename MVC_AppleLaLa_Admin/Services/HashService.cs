using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MVC_AppleLaLa_Admin.Services
{
    public class HashService
    {
        public static string MD5Hash(string rawString)
        {
            if (string.IsNullOrEmpty(rawString))
            {
                return string.Empty;
            }
            StringBuilder sb;
            using (MD5 md5 = MD5.Create())
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(rawString);

                byte[] encryption = md5.ComputeHash(byteArray);
                sb = new StringBuilder();

                for (int i = 0; i < encryption.Length; i++)
                {
                    sb.Append(encryption[i].ToString("X2"));
                }
            }

            return sb.ToString();
        }
    }
}