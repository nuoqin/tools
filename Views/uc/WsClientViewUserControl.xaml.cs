using code_tools.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Policy;
using System.Text;
using System.Threading;
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

namespace CodeTools.view
{
    /// <summary>
    /// WebsocketClientUC.xaml 的交互逻辑
    /// </summary>
    public partial class WsClientViewUserControl : UserControl
    {

        private static ClientWebSocket client;

        private static CancellationToken token;

        public WsClientViewUserControl()
        {
            InitializeComponent();
            close.IsEnabled = false;
            senderBtn.IsEnabled = false;
        }

        private async void closeConnect(object sender, RoutedEventArgs e)
        {
            if (close.IsEnabled)
            {
                url.IsReadOnly = true;
                connectBtn.IsEnabled = true;
                close.IsEnabled = false;
                senderBtn.IsEnabled = false;
                await client.CloseAsync(WebSocketCloseStatus.NormalClosure, "1", token);
            }
            else {
                MessageBox.Show("请连接到服务器后，在进行关闭", "连接错误");
            }
           
        }

        private void send(object sender, RoutedEventArgs e)
        {
            string msg = sendText.Text;
            if (string.IsNullOrEmpty(msg)) {
                return;
            }
            var result = Encoding.UTF8.GetBytes(msg);
            client.SendAsync(new ArraySegment<byte>(result), WebSocketMessageType.Text, true, token);
            sendText.Text = "";
        }

        private async void connect(object sender, RoutedEventArgs e)
        {
            var ws = url.Text;
            client = new ClientWebSocket();
            url.IsReadOnly = false;
            if (ws == null || !ws.StartsWith("ws")) {
                MessageBox.Show("错误的链接，请输入ws://或者wss://开头的链接", "连接错误");
            }
            try
            {
                token = new CancellationToken();
                await client.ConnectAsync(new Uri(ws), token);
                while (client.State == WebSocketState.Open)
                {
                    close.IsEnabled = true;
                    connectBtn.IsEnabled = false;
                    senderBtn.IsEnabled = true;
                    var result = new byte[1024];
                    await client.ReceiveAsync(new ArraySegment<byte>(result), token);
                    var receiveMsg = Encoding.UTF8.GetString(result, 0, result.Length);
                    TextUtils.appendStr(newCode, receiveMsg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败", "error");
               connectBtn.IsEnabled = true;

            }
        }
    }
}
