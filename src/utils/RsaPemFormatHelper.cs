﻿using System;
using System.Collections.Generic;

namespace nuoqin.src.utils
{
    public class RsaPemFormatHelper
    {
        /// Format Pkcs1 format private key
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Pkcs1PrivateKeyFormat(string str)
        {
            if (str.StartsWith("-----BEGIN RSA PRIVATE KEY-----"))
            {
                return str;
            }

            List<string> res = new List<string>();
            res.Add("-----BEGIN RSA PRIVATE KEY-----");

            int pos = 0;

            while (pos < str.Length)
            {
                var count = str.Length - pos < 64 ? str.Length - pos : 64;
                res.Add(str.Substring(pos, count));
                pos += count;
            }

            res.Add("-----END RSA PRIVATE KEY-----");
            var resStr = string.Join(Environment.NewLine, res);
            return resStr;
        }

        /// Remove the Pkcs1 format private key format
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Pkcs1PrivateKeyFormatRemove(string str)
        {
            if (!str.StartsWith("-----BEGIN RSA PRIVATE KEY-----"))
            {
                return str;
            }
            return str.Replace("-----BEGIN RSA PRIVATE KEY-----", "").Replace("-----END RSA PRIVATE KEY-----", "")
                .Replace(Environment.NewLine, "");
        }

        /// Format Pkcs8 format private key
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Pkcs8PrivateKeyFormat(string str)
        {
            if (str.StartsWith("-----BEGIN PRIVATE KEY-----"))
            {
                return str;
            }
            List<string> res = new List<string>();
            res.Add("-----BEGIN PRIVATE KEY-----");

            int pos = 0;

            while (pos < str.Length)
            {
                var count = str.Length - pos < 64 ? str.Length - pos : 64;
                res.Add(str.Substring(pos, count));
                pos += count;
            }

            res.Add("-----END PRIVATE KEY-----");
            var resStr = string.Join(Environment.NewLine, res);
            return resStr;
        }

        /// Remove the Pkcs8 format private key format
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Pkcs8PrivateKeyFormatRemove(string str)
        {
            if (!str.StartsWith("-----BEGIN PRIVATE KEY-----"))
            {
                return str;
            }
            return str.Replace("-----BEGIN PRIVATE KEY-----", "").Replace("-----END PRIVATE KEY-----", "")
                .Replace(Environment.NewLine, "");
        }

        /// Format public key
        /// <param name="str"></param>
        /// <returns></returns>
        public static string PublicKeyFormat(string str)
        {
            if (str.StartsWith("-----BEGIN PUBLIC KEY-----"))
            {
                return str;
            }
            List<string> res = new List<string>();
            res.Add("-----BEGIN PUBLIC KEY-----");
            int pos = 0;

            while (pos < str.Length)
            {
                var count = str.Length - pos < 64 ? str.Length - pos : 64;
                res.Add(str.Substring(pos, count));
                pos += count;
            }
            res.Add("-----END PUBLIC KEY-----");
            var resStr = string.Join(Environment.NewLine, res);
            return resStr;
        }

        /// Public key format removed
        /// <param name="str"></param>
        /// <returns></returns>
        public static string PublicKeyFormatRemove(string str)
        {
            if (!str.StartsWith("-----BEGIN PUBLIC KEY-----"))
            {
                return str;
            }
            return str.Replace("-----BEGIN PUBLIC KEY-----", "").Replace("-----END PUBLIC KEY-----", "")
                .Replace(Environment.NewLine, "");
        }
    }
}
