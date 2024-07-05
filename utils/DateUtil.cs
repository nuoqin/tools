using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tools.utils
{
    public class DateUtil
    {

        public static string timeStampToDateStr(string timeStamp)
        {
            long timestamp = long.Parse(timeStamp);
            //判断是秒还是毫秒
            DateTime targetDate;

            if (timestamp > -62135596800L && timestamp < 253402300799L)
            {
                targetDate = DateTimeOffset.FromUnixTimeSeconds(timestamp).LocalDateTime;
            }else{
                targetDate = DateTimeOffset.FromUnixTimeMilliseconds(timestamp).LocalDateTime;
            }
            string timestampStr= targetDate.ToString("F")+ "\n\n";
            timestampStr+= targetDate.ToString("G") + "\n\n"; 
            
            timestampStr += targetDate.ToString("yyyy-MM-dd") + "\n\n";
            timestampStr += targetDate.ToString("yyyy-MM-dd HH:mm:ss") + "\n\n";
            timestampStr += targetDate.ToString("ddd") + "\n\n";
            return timestampStr;
        }

        public static string toDateAllStr(string timeStamp)
        {
            long timestamp = long.Parse(timeStamp);
            //判断是秒还是毫秒
            DateTime targetDate;
            if (timestamp > -62135596800L && timestamp < 253402300799L){
                targetDate = DateTimeOffset.FromUnixTimeSeconds(timestamp).LocalDateTime;
            }else{
                targetDate = DateTimeOffset.FromUnixTimeMilliseconds(timestamp).LocalDateTime;
            }
            string timestampStr = targetDate.ToString("yyyy-MM-dd HH:mm:ss");
            return timestampStr;
        }

        public static string toTimeStr(string timeStamp)
        {
            long timestamp = long.Parse(timeStamp);
            //判断是秒还是毫秒
            DateTime targetDate = getDateTime(timestamp);
            string timestampStr = targetDate.ToString("HH:mm:ss");
            return timestampStr;
        }

        public static string toDateStr(string timeStamp)
        {
            long timestamp = long.Parse(timeStamp);
            //判断是秒还是毫秒
            DateTime targetDate = getDateTime(timestamp);
            string timestampStr = targetDate.ToString("yyyy-MM-dd");
            return timestampStr;
        }

        private static DateTime getDateTime(long timestamp)
        {
            DateTime targetDate;
            if (timestamp > -62135596800L && timestamp < 253402300799L)
            {
                targetDate = DateTimeOffset.FromUnixTimeSeconds(timestamp).LocalDateTime;
            }
            else
            {
                targetDate = DateTimeOffset.FromUnixTimeMilliseconds(timestamp).LocalDateTime;
            }

            return targetDate;
        }

        public static string toTimeStampMs(string dateStr){
            var str = "";
            //判断是秒还是毫秒
            DateTime targetDate = DateTime.Parse(dateStr);
            var date = new DateTimeOffset(targetDate);
            str = date.ToUnixTimeMilliseconds().ToString() ;
            return str;
        }

        public static string toTimeStampS(string dateStr)
        {
            var str = "";
            //判断是秒还是毫秒
            DateTime targetDate = DateTime.Parse(dateStr);
            var date = new DateTimeOffset(targetDate);
            str = date.ToUnixTimeSeconds().ToString() ;
            return str;
        }

        public static string dateToTimeStamp(string dateStr)
        {
            var str = "";
            //判断是秒还是毫秒
            DateTime targetDate = DateTime.Parse(dateStr);
            var date = new DateTimeOffset(targetDate);
            str = date.ToUnixTimeSeconds().ToString() + "\n\n";
            str += date.ToUnixTimeMilliseconds().ToString() + "\n\n";
            return str;
        }

    }
}
