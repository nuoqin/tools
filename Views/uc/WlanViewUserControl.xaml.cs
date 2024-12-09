using CodeTools.utils;
using CodeTools.ViewModels.utils;
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

namespace CodeTools.Views.uc
{
    /// <summary>
    /// WlanViewUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class WlanViewUserControl : UserControl
    {
        public WlanViewUserControl()
        {
            InitializeComponent();
            response.Text = CmdUtils.exec("netsh wlan show interfaces");
        }



        private void showConnect(object sender, RoutedEventArgs e)
        {
            response.Text = CmdUtils.exec("netsh wlan show interfaces");

        }
        /// <summary>
        /// 连接无线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connect(object sender, RoutedEventArgs e)
        {
            var command = "netsh wlan add profile filename=\"{0}\" user=all";
            var ssidValue = ssid.Text;
            string hex = string.Join("", ssidValue.Select(c => ((int)c).ToString("x2")));
            var passwordValue = password.Text;
            var str = "<?xml version=\"1.0\"?>\r\n" +
                "<WLANProfile xmlns=\"http://www.microsoft.com/networking/WLAN/profile/v1\">" +
                "   <name>{0}</name>\r\n\t" +
                "   <SSIDConfig>\r\n\t\t" +
                "       <SSID>\r\n\t\t\t" +
                "           <hex>{3}</hex>\r\n\t\t\t" +
                "           <name>{0}</name>\r\n\t\t" +
                "       </SSID>\r\n\t" +
                "   </SSIDConfig>\r\n\t" +
                "   <connectionType>ESS</connectionType>\r\n\t" +
                "   <connectionMode>auto</connectionMode>\r\n\t" +
                "   <MSM>\r\n\t\t" +
                "       <security>\r\n\t\t\t" +
                "           <authEncryption>\r\n\t\t\t\t" +
                "               <authentication>{1}</authentication>\r\n\t\t\t\t" +
                "               <encryption>AES</encryption>\r\n\t\t\t\t" +
                "               <useOneX>false</useOneX>\r\n\t\t\t" +
                "           </authEncryption>\r\n\t\t\t" +
                "           <sharedKey>\r\n\t\t\t\t" +
                "               <keyType>passPhrase</keyType>\r\n\t\t\t\t" +
                "               <protected>false</protected>\r\n\t\t\t\t" +
                "               <keyMaterial>{2}</keyMaterial>\r\n\t\t\t" +
                "           </sharedKey>\r\n\t\t" +
                "       </security>\r\n\t" +
                "   </MSM>\r\n\t" +
                "   <MacRandomization xmlns=\"http://www.microsoft.com/networking/WLAN/profile/v3\">\r\n\t\t" +
                "       <enableRandomization>false</enableRandomization>\r\n\t" +
                "   </MacRandomization>\r\n" +
                "</WLANProfile>";
            str=string.Format(str, ssidValue,"WPA2PSK", passwordValue, hex);
            try
            {
                XmlDocument document = new XmlDocument();
                document.LoadXml(str);
                document.Save("wifi-profile.xml");
                var dir = Environment.CurrentDirectory;
                command = string.Format(command, dir + "\\wifi-profile.xml");
                response.Text = command;
                response.Text += CmdUtils.exec(command);
                response.Text += CmdUtils.exec("netsh wlan show profiles");
                response.Text += CmdUtils.exec("netsh wlan connect name="+ ssidValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }   
        }

        private void initHeader(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var prop = e.PropertyName;

            switch (prop) { 
                case "Name":
                    e.Column.Header = "无线名称";
                    break;
                case "Ssid":
                    e.Column.Header = "无线Hex";
                    break;
                case "Type":
                    e.Column.Header = "加密方式";
                    break;
                case "Hight":
                    e.Column.Header = "信号强度";
                    break;

            }
        }

        private void refesh(object sender, RoutedEventArgs e)
        {
            var list = WifiUtils.getWifis();
            WlanList.ItemsSource = list;
        }
    }
}
