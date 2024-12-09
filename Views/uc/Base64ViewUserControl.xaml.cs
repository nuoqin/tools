using code_tools.utils;
using CodeTools.utils;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using tools;
using tools.utils;

namespace CodeTools.view
{
    /// <summary>
    /// JSONFormatUC.xaml 的交互逻辑
    /// </summary>
    public partial class Base64ViewUserControl : UserControl
    {
        public Base64ViewUserControl()
        {
            InitializeComponent();
        }

        private void encode(object sender, RoutedEventArgs e)
        {
            try {
                string text = TextUtils.getStr(sourceCode);
                TextUtils.setStr(newCode,Base64Utils.encode(text));
            } catch (Exception ex){
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
                TextUtils.setStr(newCode,"");
                string type = "jpg";
                var format = "data:image/{0};base64,";
                if (text.StartsWith("data:image")) {
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
    }
}
