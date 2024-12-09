using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTools.utils
{
    public class FileUtils
    {
        public static string getFileType(string fileName)
        {
            var lastIndex=fileName.LastIndexOf('.');
            return fileName.Substring(lastIndex + 1);

        }
    }
}
