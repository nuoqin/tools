using Microsoft.Win32;
using nuoqin.src.utils;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace nuoqin.src.Pages
{
    /// <summary>
    /// BASE64Page.xaml 的交互逻辑
    /// </summary>
    public partial class BASE64Page : Page
    {
        public BASE64Page()
        {
            InitializeComponent();
        }

        private void encode(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);
                TextUtils.setStr(newCode, Base64Utils.encode(text));
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
                TextUtils.setStr(newCode, Base64Utils.decode(text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static string pattern = @"data:image\/([^;]+);base64";

        private void decodeImage(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);
                TextUtils.setStr(newCode, "");
                string type = "jpg";
                var format = "data:image/{0};base64,";
                if (text.StartsWith("data:image"))
                {
                    Match match = Regex.Match(text, pattern);
                    if (match.Success)
                    {
                        string mimeType = match.Groups[1].Value;
                        type = mimeType;
                        text = text.Replace(string.Format(format, mimeType), "");
                    }
                }
                TextUtils.setStr(newCode, Base64Utils.decodeImage(text, type));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void encodeImage(object sender, RoutedEventArgs e)
        {

            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = " *.*|*.bmp;*.jpg;*.jpeg;*.tiff;*.tiff;*.png";
                openFileDialog.Title = "请选择图片";
                if (openFileDialog.ShowDialog() == true)
                {
                    var fileName = openFileDialog.FileName;
                    sourceCode.Text = fileName;
                    string imageBase64 = Base64Utils.encodeImage(fileName);
                    var newStr = "";
                    var format = "data:image/{0};base64,";
                    if (check.IsChecked.Value)
                    {
                        newStr += string.Format(format, FileUtils.getFileType(fileName)) + imageBase64;
                    }
                    else
                    {
                        newStr = imageBase64;
                    }
                    sourceCode.Text = fileName;
                    TextUtils.setStr(newCode, newStr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void copy(object sender, RoutedEventArgs e)
        {
            try
            {
                Clipboard.SetText(TextUtils.getStr(newCode));
                MessageBox.Show("复制成功", "成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
