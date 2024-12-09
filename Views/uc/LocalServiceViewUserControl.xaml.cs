using code_tools.utils;
using CodeTools.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeTools.view
{
    /// <summary>
    /// NetUc.xaml 的交互逻辑
    /// </summary>
    public partial class LocalServiceViewUserControl : UserControl
    {
        public LocalServiceViewUserControl()
        {
            InitializeComponent();
            
        }

        private void search(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show("执行查询操作................");
                TextUtils.setStr(newCode, SystemUtils.getLocalIP());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void findIPs(object sender, RoutedEventArgs e)
        {
            try
            {
                TextUtils.setStr(newCode, SystemUtils.getCurLocalNetIPs());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ping(object sender, RoutedEventArgs e)
        {
            try{
                var ip = TextUtils.getStr(newCode);
                TextUtils.setStr(newCode, SystemUtils.ping(ip));
            }catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
        }
        private void clear(object sender, RoutedEventArgs e)
        {
            TextUtils.setStr(newCode,"");
        }

        /// <summary>
        /// 执行telnet命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendTelnet(object sender, RoutedEventArgs e)
        {
            netResponse.Text = "";
            var host=netIp.Text.Trim();
            var port=netPort.Text.Trim();
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(IPAddress.Parse(host), int.Parse(port));
                if (clientSocket.Connected) {
                    netResponse.Text = "Success";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                netResponse.Text = "Error";
            }
            finally {
                clientSocket.Close();
            }
        }

        /// <summary>
        /// 执行telnet命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendTracert(object sender, RoutedEventArgs e)
        {
            trResponse.Text = "";
            var host = trIp.Text.Trim();

            var response =CmdUtils.exec("netstat -ano | findstr " + host);
            
            trResponse.Text = response;
        }
    }
}
