using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace tools.utils
{
    public class MD5Util
    {
        
        public static string MD5Str(string sourceStr)
        {
            sourceStr = sourceStr.Trim();
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(Encoding.UTF8.GetBytes(sourceStr));
            StringBuilder fileMD5 = new StringBuilder();
            for (int i = 0; i < result.Length; i++) {
                byte b = result[i];
                fileMD5.Append(b.ToString("x2"));
            }
            return fileMD5.ToString();
        }
    }
}
