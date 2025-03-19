using nuoqin.src.utils;
using System;
using System.Windows;
using System.Windows.Controls;

namespace nuoqin.src.Pages
{
    /// <summary>
    /// URLPage.xaml 的交互逻辑
    /// </summary>
    public partial class URLPage : Page
    {
        public URLPage()
        {
            InitializeComponent();
        }

        private void encode(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);
                TextUtils.setStr(newCode, HttpUtils.encode(text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void decode(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);
                TextUtils.setStr(newCode, HttpUtils.decode(text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
