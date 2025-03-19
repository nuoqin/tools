using nuoqin.src.utils;
using System;
using System.Windows;
using System.Windows.Controls;

namespace nuoqin.src.Pages
{
    /// <summary>
    /// RSAPage.xaml 的交互逻辑
    /// </summary>
    public partial class RSAPage : Page
    {
        public RSAPage()
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
