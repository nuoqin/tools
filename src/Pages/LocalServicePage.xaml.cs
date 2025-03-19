using code_tools.utils;
using nuoqin.src.utils;
using System.Net.Sockets;
using System.Windows;
using System;
using System.Windows.Controls;
using System.Net;

namespace nuoqin.src.Pages
{
    /// <summary>
    /// LocalServicePage.xaml 的交互逻辑
    /// </summary>
    public partial class LocalServicePage : Page
    {
        public LocalServicePage()
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
            try
            {
                var ip = TextUtils.getStr(newCode);
                TextUtils.setStr(newCode, SystemUtils.ping(ip));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void clear(object sender, RoutedEventArgs e)
        {
            TextUtils.setStr(newCode, "");
        }

        /// <summary>
        /// 执行telnet命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendTelnet(object sender, RoutedEventArgs e)
        {
            netResponse.Text = "";
            var host = netIp.Text.Trim();
            var port = netPort.Text.Trim();
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(IPAddress.Parse(host), int.Parse(port));
                if (clientSocket.Connected)
                {
                    netResponse.Text = "Success";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                netResponse.Text = "Error";
            }
            finally
            {
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
            try
            {
                trResponse.Text = "";
                var host = trIp.Text.Trim();
                var response = CmdUtils.exec("netstat -ano | findstr " + host);
                trResponse.Text = response;
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message,"查找失败");
            }
            
        }
    }
}
