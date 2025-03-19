using Microsoft.Win32;
using nuoqin.src.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace nuoqin.src.Pages
{
    /// <summary>
    /// UnicodePage.xaml 的交互逻辑
    /// </summary>
    public partial class IcoPage : Page
    {
        public IcoPage()
        {
            InitializeComponent();
        }

        private void toIco(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = " *.jpg;*.jpeg;*.png";
                openFileDialog.Title = "请选择图片";
                if (openFileDialog.ShowDialog() == true)
                {
                    var fileName = openFileDialog.FileName;
                    string imageBase64 = Base64Utils.encodeImage(fileName);
                    
                    TextUtils.setStr(newCode, "success");
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void ico2Png(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = " *.jpg;*.jpeg;*.png";
                openFileDialog.Title = "请选择ico图标";
                if (openFileDialog.ShowDialog() == true)
                {
                    var fileName = openFileDialog.FileName;
                    string imageBase64 = Base64Utils.encodeImage(fileName);

                    TextUtils.setStr(newCode, "success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ico2Jpg(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = " *.jpg;*.jpeg;*.png";
                openFileDialog.Title = "请选择ico图标";
                if (openFileDialog.ShowDialog() == true)
                {
                    var fileName = openFileDialog.FileName;
                    string imageBase64 = Base64Utils.encodeImage(fileName);

                    TextUtils.setStr(newCode, "success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
