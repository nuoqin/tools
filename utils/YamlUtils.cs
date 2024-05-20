using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace code_tools.utils
{
    public class YamlUtils
    {
        /**
         * yaml文件转json 
         * server:
         *     port: 8090
         */
        private static string spacePattern = @"(?>\r\n|\n|\r)(?>\s+)";

        private static string pattern = @"(?>\r\n|\n|\r)(?!\s)";

        public static string toJSONStr(string yamlStr) {
            if (string.IsNullOrEmpty(yamlStr)) { return ""; }
            var strArr = yamlStr.Split(new string[] { Environment.NewLine},StringSplitOptions.None);





            return "";
        }

    }
}
