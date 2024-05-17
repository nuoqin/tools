using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tools.utils
{
    public class Base64Utils
    {
        /**
         * 解密
         */
        public static string decode(string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);
            return Convert.ToBase64String(bytes); ;
        }

        /**
         * 
         * 加密
         * 
         */
        public static string encode(string str)
        {
            byte[] bytes = Convert.FromBase64String(str);
            return Encoding.Default.GetString(bytes);
        }
    }
}
