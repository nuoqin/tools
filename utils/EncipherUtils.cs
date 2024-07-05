using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace code_tools.utils
{
    public class EncipherUtils
    {
        /**
         * AESECB加密
         */
        public static string AESECBPKCS7Encrypt(string encryptStr, string key) {
            byte[] keyBytes= UTF8Encoding.UTF8.GetBytes(key);
            byte[] encryptStrBytes = UTF8Encoding.UTF8.GetBytes(encryptStr);
            RijndaelManaged rd= new RijndaelManaged();
            rd.Key = keyBytes;
            rd.Mode = CipherMode.ECB;
            rd.Padding = PaddingMode.PKCS7;
            var en= rd.CreateEncryptor();
            var byteArr = en.TransformFinalBlock(encryptStrBytes,0, encryptStrBytes.Length);  
            return Convert.ToBase64String(byteArr,0,byteArr.Length);
        }


        /**
         * 
         * AES ECB 解密
         *  
         */
        public static string AESECBPKCS7DEncrypt(string dencryptStr, string key)
        {
            byte[] keyBytes = UTF8Encoding.UTF8.GetBytes(key);
            byte[] dencryptStrBytes = UTF8Encoding.UTF8.GetBytes(dencryptStr);
            RijndaelManaged rd = new RijndaelManaged();
            rd.Key = keyBytes;
            rd.Mode = CipherMode.ECB;
            rd.Padding = PaddingMode.PKCS7;
            var de =rd.CreateDecryptor();
            var byteArr = de.TransformFinalBlock(dencryptStrBytes, 0, dencryptStrBytes.Length);
            return Convert.ToBase64String(byteArr, 0, byteArr.Length);
        }


        /**
         * AESECB加密
         */
        public static string AESCBCPKCS7Encrypt(string encryptStr, string key)
        {
            byte[] keyBytes = UTF8Encoding.UTF8.GetBytes(key);
            byte[] encryptStrBytes = UTF8Encoding.UTF8.GetBytes(encryptStr);
            RijndaelManaged rd = new RijndaelManaged();
            rd.Key = keyBytes;
            rd.Mode = CipherMode.CBC;
            rd.Padding = PaddingMode.PKCS7;
            var en = rd.CreateEncryptor();
            var byteArr = en.TransformFinalBlock(encryptStrBytes, 0, encryptStrBytes.Length);
            return Convert.ToBase64String(byteArr, 0, byteArr.Length);
        }


        /**
         * 
         * AES ECB 解密
         *  
         */
        public static string AESCBCPKCS7DEncrypt(string dencryptStr, string key)
        {
            byte[] keyBytes = UTF8Encoding.UTF8.GetBytes(key);
            byte[] dencryptStrBytes = UTF8Encoding.UTF8.GetBytes(dencryptStr);
            RijndaelManaged rd = new RijndaelManaged();
            rd.Key = keyBytes;
            rd.Mode = CipherMode.CBC;
            rd.Padding = PaddingMode.PKCS7;
            var de = rd.CreateDecryptor();
            var byteArr = de.TransformFinalBlock(dencryptStrBytes, 0, dencryptStrBytes.Length);
            return Convert.ToBase64String(byteArr, 0, byteArr.Length);
        }

        public static string SHA1Encrypt(String data)
        {
            byte[] keyBytes = UTF8Encoding.UTF8.GetBytes(data);
            var hash = SHA1Managed.Create().ComputeHash(keyBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }



        public static string SHA256Encrypt(String data) {
            byte[] keyBytes = UTF8Encoding.UTF8.GetBytes(data);
            var hash = SHA256Managed.Create().ComputeHash(keyBytes);
            StringBuilder sb=new StringBuilder();
            for (int i = 0; i < hash.Length; i++) {

                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
