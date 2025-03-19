using System;
using System.Security.Cryptography;
using System.Text;

namespace nuoqin.src.utils
{
    public class EncipherUtils
    {
        /**
         * AESECB加密
         */
        public static string AESEncrypt(string encryptStr, string key, PaddingMode mode, CipherMode cipherMode)
        {
            if (key.Length != 16) return "key 长度必须为16个字符";
            byte[] keyBytes = UTF8Encoding.UTF8.GetBytes(key);
            byte[] encryptStrBytes = UTF8Encoding.UTF8.GetBytes(encryptStr);
            RijndaelManaged rd = new RijndaelManaged();
            rd.Key = keyBytes;
            rd.Mode = cipherMode;
            rd.Padding = mode;
            var en = rd.CreateEncryptor();
            var byteArr = en.TransformFinalBlock(encryptStrBytes, 0, encryptStrBytes.Length);
            return Convert.ToBase64String(byteArr, 0, byteArr.Length);
        }


        /**
         * 
         * AES ECB 解密
         *  
         */
        public static string AESDEncrypt(string dencryptStr, string key, PaddingMode mode, CipherMode cipherMode)
        {
            if (key.Length != 16) return "key 长度必须为16个字符";
            byte[] keyBytes = UTF8Encoding.UTF8.GetBytes(key);
            byte[] dencryptStrBytes = Convert.FromBase64String(dencryptStr); ;
            RijndaelManaged rd = new RijndaelManaged();
            rd.Key = keyBytes;
            rd.Mode = cipherMode;
            rd.Padding = mode;
            var de = rd.CreateDecryptor();
            var byteArr = de.TransformFinalBlock(dencryptStrBytes, 0, dencryptStrBytes.Length);
            return System.Text.Encoding.UTF8.GetString(byteArr);
        }

        /**
         * AESCBC加密
         */
        public static string AESCEncrypt(string encryptStr, string key, string iv, PaddingMode mode, CipherMode cipherMode)
        {
            if (key.Length != 16) return "key 长度必须为16个字符";
            byte[] keyBytes = UTF8Encoding.UTF8.GetBytes(key);
            byte[] encryptStrBytes = UTF8Encoding.UTF8.GetBytes(encryptStr);
            RijndaelManaged rd = new RijndaelManaged();
            rd.Key = keyBytes;
            rd.IV = UTF8Encoding.UTF8.GetBytes(iv);
            rd.Mode = cipherMode;
            rd.Padding = mode;
            var en = rd.CreateEncryptor();
            var byteArr = en.TransformFinalBlock(encryptStrBytes, 0, encryptStrBytes.Length);
            return Convert.ToBase64String(byteArr, 0, byteArr.Length);
        }


        /**
         * 
         * AES CBC 解密
         *  
         */
        public static string AESCDEncrypt(string dencryptStr, string key, string iv, PaddingMode mode, CipherMode cipherMode)
        {
            if (key.Length != 16) return "key 长度必须为16个字符";
            byte[] keyBytes = UTF8Encoding.UTF8.GetBytes(key);
            byte[] dencryptStrBytes = Convert.FromBase64String(dencryptStr); ;
            RijndaelManaged rd = new RijndaelManaged();
            rd.Key = keyBytes;
            rd.IV = UTF8Encoding.UTF8.GetBytes(iv);
            rd.Mode = cipherMode;
            rd.Padding = mode;
            var de = rd.CreateDecryptor();
            var byteArr = de.TransformFinalBlock(dencryptStrBytes, 0, dencryptStrBytes.Length);
            return System.Text.Encoding.UTF8.GetString(byteArr);
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



        public static string SHA256Encrypt(String data)
        {
            byte[] keyBytes = UTF8Encoding.UTF8.GetBytes(data);
            var hash = SHA256Managed.Create().ComputeHash(keyBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {

                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public static string gen()
        {
            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                var publickey = rsa.ToXmlString(true);
                var privatekey = rsa.ToXmlString(false);
                privatekey = RsaKeyConvert.PrivateKeyXmlToPkcs8(privatekey);
                publickey = RsaKeyConvert.PublicKeyXmlToPem(publickey);
                return string.Format("公钥：{0}\r\n 私钥：{1}", publickey, privatekey);
            }
        }



        /**
         * RSA加密
         */
        public static string RsaEncrypt(string encryptStr, string publicKey)
        {

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);

                var bytes = rsa.Encrypt(Encoding.UTF8.GetBytes(encryptStr), false);
                return Convert.ToBase64String(bytes, 0, bytes.Length);
            }
        }


        /**
         * 
         * RSA 解密
         *  
         */
        public static string RsaDEncrypt(string dencryptStr, string privateKey)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKey);
                var bytes = rsa.Decrypt(Convert.FromBase64String(dencryptStr), false);
                return Encoding.UTF8.GetString(bytes);
            }
        }

        /**
         * 私钥解密
         */
        public static string Decrypt(string base64Input, string privateKey)
        {
            return DecryptWithPrivate(base64Input, privateKey);
        }

        /**
         * 公钥加密
         */
        public static string Encrypt(string base64Input, string publickey)
        {
            return EncryptWithPrivate(base64Input, publickey);
        }

        /**
        * 私钥解密,
        * 需注意的是这里的PEM 私钥文件是PKCS1格式，
        * 而Java中的是PKCS8格式
        */
        public static string DecryptWithPrivate(string base64Input, string privateKey)
        {
            string priXml = RsaKeyConvert.PrivateKeyPkcs8ToXml(privateKey);
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(priXml);
            cipherbytes = rsa.Decrypt(Convert.FromBase64String(base64Input), false);

            return Encoding.UTF8.GetString(cipherbytes);
        }

        /// <summary>
        /// 用私钥给数据进行RSA加密
        /// </summary>
        /// <param name="xmlPrivateKey"> 公钥(XML格式字符串)</param>
        /// <param name="encryptStr"> 要加密的数据 </param>
        /// <returns> 加密后的数据 </returns>
        public static string EncryptWithPrivate(string encryptStr, string publickey)
        {
            string priXml = RsaKeyConvert.PublicKeyPemToXml(publickey);
            //加载公钥
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(priXml);

            var bytes = rsa.Encrypt(Encoding.UTF8.GetBytes(encryptStr), false);
            return Convert.ToBase64String(bytes, 0, bytes.Length);
            //转换密钥
            //AsymmetricCipherKeyPair keyPair = DotNetUtilities.GetKeyPair(rsa);
            //IBufferedCipher c = CipherUtilities.GetCipher("RSA/ECB/PKCS8Padding"); //使用RSA/ECB/PKCS1Padding格式
            //第一个参数为true表示加密，为false表示解密；第二个参数表示密钥
            //c.Init(true, keyPair.Public);
            //byte[] DataToEncrypt = Encoding.UTF8.GetBytes(strEncryptString);
            //byte[] outBytes = c.DoFinal(DataToEncrypt);//加密
            //return Convert.ToBase64String(outBytes);
        }
    }
}
