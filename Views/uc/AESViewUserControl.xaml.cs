using code_tools.utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using tools;
using tools.utils;

namespace CodeTools.view
{
    /// <summary>
    /// JSONFormatUC.xaml 的交互逻辑
    /// </summary>
    public partial class AESViewUserControl : UserControl
    {
        public AESViewUserControl()
        {
            InitializeComponent();
        }

     

        private void encrypt(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);
                var keyStr = TextUtils.getStr(key);
                var encode = "";
                var modeStr = mode.Text;
                var type= aseType.Text;
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
                else {
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
