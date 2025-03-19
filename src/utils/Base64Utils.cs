using System;
using System.IO;
using System.Text;

namespace nuoqin.src.utils
{
    public class Base64Utils
    {
        /**
         * 解密
         */
        public static string encode(string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);
            return Convert.ToBase64String(bytes); ;
        }
        /**
         * 加密
         */
        public static string decode(string str)
        {
            byte[] bytes = Convert.FromBase64String(str);
            return Encoding.Default.GetString(bytes);
        }

        /***
         * 编码图片
         */
        public static string encodeImage(string fileName)
        {
            var bytes = File.ReadAllBytes(fileName);
            return Convert.ToBase64String(bytes);
        }

        public static string decodeImage(string text, string fileType)
        {
            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filePath += "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "." + fileType;
            var bytes = Convert.FromBase64String(text);
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
            return filePath;
        }
    }
}
