using Microsoft.Win32;
using nuoqin.src.utils;
using System;
using System.Windows;
using System.Windows.Controls;

namespace nuoqin.src.Pages
{
    /// <summary>
    /// Md5Page.xaml 的交互逻辑
    /// </summary>
    public partial class Md5Page : Page
    {
        public Md5Page()
        {
            InitializeComponent();
        }

        private void format(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);
                TextUtils.setStr(newCode, MD5Util.MD5Str(text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void formatSha1(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);
                TextUtils.setStr(newCode, EncipherUtils.SHA1Encrypt(text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void formatSha256(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);
                TextUtils.setStr(newCode, EncipherUtils.SHA256Encrypt(text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void formatFileMd5(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.Title = "选择文件";
                if (openFileDialog.ShowDialog() == true)
                {
                    var fileName = openFileDialog.FileName;
                    sourceCode.Text = fileName;
                    string fileMd5 = MD5Util.FileMd5(fileName);
                    TextUtils.setStr(newCode, fileMd5);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
