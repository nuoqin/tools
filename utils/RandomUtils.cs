using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTools.utils
{
    public class RandomUtils
    {
        /**
         * 有“-”符号
         */
        public static string randomUUID()
        {
           return Guid.NewGuid().ToString();
        }
        /**
         * 纯字母+数字
         */
        public static string randomNUUID()
        {
            return Guid.NewGuid().ToString("N");
        }

        public static string dateTimeStr()
        {
            return DateTime.Now.ToString();
        }


        public static string randomNum(int begin, int end)
        {
            Random rd = new Random();
            return rd.Next(begin, end)+"";
        }
    }
}
