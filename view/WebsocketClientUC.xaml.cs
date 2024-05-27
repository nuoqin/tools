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

namespace code_tools.view
{
    /// <summary>
    /// WebsocketClientUC.xaml 的交互逻辑
    /// </summary>
    public partial class WebsocketClientUC : UserControl
    {

        private static ClientWebSocket client;

        private static CancellationToken token;

        public WebsocketClientUC()
        {
            InitializeComponent();
        }

        private async void closeConnect(object sender, RoutedEventArgs e)
        {
            url.IsReadOnly = true;
            
            connectBtn.IsEnabled = true;
            await client.CloseAsync(WebSocketCloseStatus.NormalClosure, "1", token);
        }

        private void send(object sender, RoutedEventArgs e)
        {
            string msg = sendText.Text;
            var result = Encoding.UTF8.GetBytes(msg);
            client.SendAsync(new ArraySegment<byte>(result), WebSocketMessageType.Text, true, token);
            sendText.Text = "";
        }

        private async void connect(object sender, RoutedEventArgs e)
        {
            var ws = url.Text;
            client = new ClientWebSocket();
            url.IsReadOnly = false;
            
            try
            {
                token = new CancellationToken();
                connectBtn.Background = new SolidColorBrush(Colors.Gray);
                connectBtn.IsEnabled = false;
                await client.ConnectAsync(new Uri(ws), token);
                while (client.State == WebSocketState.Open)
                {
                    connectBtn.IsEnabled = true;
                    senderBtn.IsEnabled = false;
                    var result = new byte[1024];
                    await client.ReceiveAsync(new ArraySegment<byte>(result), token);
                    var receiveMsg = Encoding.UTF8.GetString(result, 0, result.Length);
                    TextUtils.appendStr(newCode, receiveMsg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败", "error");
            }
        }
    }
}
