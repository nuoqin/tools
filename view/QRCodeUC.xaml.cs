using code_tools.utils;
using Microsoft.Win32;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace code_tools.view
{
    /// <summary>
    /// PDFUC.xaml 的交互逻辑
    /// </summary>
    public partial class QRCodeUC : UserControl
    {
        private BitmapImage bitmapImage;

        public QRCodeUC()
        {
            InitializeComponent();
        }

        private void generate(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);
                generateQRCode(text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }


        }

        private void generateQRCode(string text)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);

            var bytes = qrCode.GetGraphic(120);

            bitmapImage = new BitmapImage();

            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(bytes);
            bitmapImage.EndInit();

            qrCodeImage.Source = bitmapImage;
        }

        private void print(object sender, RoutedEventArgs e)
        {
            try
            {

                if (bitmapImage != null)
                {
                    this.Cursor = Cursors.Wait;
                    
                    var pl = new PrintDialog();
                    if (pl.ShowDialog() == true)
                    {
                        pl.PrintVisual(qrCodeImage, "生成二维码");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
            finally {
                this.Cursor = Cursors.AppStarting;
            }


        }

        private void generateWife(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);

                var wifeStr= text.Split(new char[] { ' ', });

                if (wifeStr.Length != 2) {
                    MessageBox.Show("请输入wife名称和密码，用空格隔开", "错误");
                    return;
                }
                var str = "WIFI:S:";
                str += wifeStr[0];
                str += ";T:WPA;P:";
                str += wifeStr[1];
                str += ";";
                generateQRCode(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }
    }
}
