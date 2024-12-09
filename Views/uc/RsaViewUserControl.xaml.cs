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
    public partial class RsaViewUserControl : UserControl
    {
        public RsaViewUserControl()
        {
            InitializeComponent();
        }


        private void encrypt(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);
                var keyStr = TextUtils.getStr(publicKey);
                var encode = EncipherUtils.Encrypt(text, keyStr);

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
                var keyStr = TextUtils.getStr(privateKey);
                var encode = EncipherUtils.Decrypt(text, keyStr);
                TextUtils.setStr(newCode, encode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void gen(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);
                var keyStr = TextUtils.getStr(publicKey);
                var encode = EncipherUtils.gen();
                TextUtils.setStr(newCode, encode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }
    }
}
