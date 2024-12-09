using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace tools.utils
{
    public class HttpUtils
    {

        public static string encode(string url)
        {

            return HttpUtility.UrlEncode(url);
        }


        public static string decode(string url)
        {
            return HttpUtility.UrlDecode(url);
        }
    }
}
