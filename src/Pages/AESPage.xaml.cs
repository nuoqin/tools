using nuoqin.src.utils;
using System;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;

namespace nuoqin.src.Pages
{
    /// <summary>
    /// AESPage.xaml 的交互逻辑
    /// </summary>
    public partial class AESPage : Page
    {
        public AESPage()
        {
            InitializeComponent();
            aseType.Text = "ECB";
            mode.Text = "NoPadding";

        }
        private void encrypt(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);
                var keyStr = TextUtils.getStr(key);
                var encode = "";
                var modeStr = mode.Text;
                var type = aseType.Text;
                if (type == "CBC")
                {
                    var ivStr = iv.Text;
                    if (modeStr == "NoPadding")
                    {
                        encode = EncipherUtils.AESCEncrypt(text, keyStr, ivStr, PaddingMode.Zeros, CipherMode.ECB);
                    }
                    else if (modeStr == "PKCS7")
                    {
                        encode = EncipherUtils.AESCEncrypt(text, keyStr, ivStr, PaddingMode.PKCS7, CipherMode.ECB);
                    }

                }
                else
                {
                    if (modeStr == "NoPadding")
                    {
                        encode = EncipherUtils.AESEncrypt(text, keyStr, PaddingMode.Zeros, CipherMode.ECB);
                    }
                    else if (modeStr == "PKCS7")
                    {
                        encode = EncipherUtils.AESEncrypt(text, keyStr, PaddingMode.PKCS7, CipherMode.ECB);
                    }
                }


                TextUtils.setStr(newCode, encode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void decrypt(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);
                var keyStr = TextUtils.getStr(key);
                var encode = "";
                var modeStr = mode.Text;
                var type = aseType.Text;
                if (type == "CBC")
                {
                    var ivStr = iv.Text;
                    if (modeStr == "NoPadding")
                    {
                        encode = EncipherUtils.AESCDEncrypt(text, keyStr, ivStr, PaddingMode.Zeros, CipherMode.ECB);
                    }
                    else if (modeStr == "PKCS7")
                    {
                        encode = EncipherUtils.AESCDEncrypt(text, keyStr, ivStr, PaddingMode.PKCS7, CipherMode.ECB);
                    }

                }
                else
                {
                    if (modeStr == "NoPadding")
                    {
                        encode = EncipherUtils.AESDEncrypt(text, keyStr, PaddingMode.Zeros, CipherMode.ECB);
                    }
                    else if (modeStr == "PKCS7")
                    {
                        encode = EncipherUtils.AESDEncrypt(text, keyStr, PaddingMode.PKCS7, CipherMode.ECB);
                    }
                }

                TextUtils.setStr(newCode, encode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }
    }
}
