using nuoqin.src.utils;
using QRCoder;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace nuoqin.src.Pages
{
    /// <summary>
    /// QRCodePage.xaml 的交互逻辑
    /// </summary>
    public partial class QRCodePage : Page
    {
        private BitmapImage bitmapImage;
        public QRCodePage()
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
            finally
            {
                this.Cursor = Cursors.AppStarting;
            }


        }

        private void generateWife(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);

                var wifeStr = text.Split(new char[] { ' ', });

                if (wifeStr.Length != 2)
                {
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
