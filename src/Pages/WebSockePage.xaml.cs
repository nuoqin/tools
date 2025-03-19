using nuoqin.src.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
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
using YamlDotNet.Core.Tokens;

namespace nuoqin.src.Pages
{
    /// <summary>
    /// WebSockePage.xaml 的交互逻辑
    /// </summary>
    public partial class WebSockePage : Page
    {
        private static ClientWebSocket client;

        private static CancellationToken token;

        public WebSockePage()
        {
            InitializeComponent();
            connectStatus(false);
        }

        private async void CloseConnect(object sender, RoutedEventArgs e)
        {
            if (CloseBtn.IsEnabled)
            {
                connectStatus(false);
                await client.CloseAsync(WebSocketCloseStatus.NormalClosure, "1", token);
            }
            else
            {
                MessageBox.Show("请连接到服务器后，在进行关闭", "连接错误");
            }

        }

        private void Send(object sender, RoutedEventArgs e)
        {
            string msg = Message.Text;
            if (string.IsNullOrEmpty(msg))
            {
                MessageBox.Show("发送的消息不能为空！", "消息错误");
                return;
            }
            var result = Encoding.UTF8.GetBytes(msg);
            var responseStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "   你: \r\n" + msg;
            TextUtils.appendStr(Messages, responseStr);
            client.SendAsync(new ArraySegment<byte>(result), WebSocketMessageType.Text, true, token);
            Message.Text = "";
        }

        private async void Connect(object sender, RoutedEventArgs e)
        {
            var ws = WebsocketUrl.Text;
            client = new ClientWebSocket();
            if (ws == null || !ws.StartsWith("ws")){
                MessageBox.Show("错误的链接，请输入ws://或者wss://开头的链接", "连接错误");
                return;
            }
            try
            {
                token = new CancellationToken();
                await client.ConnectAsync(new Uri(ws), token);
                while (client.State == WebSocketState.Open)
                {
                    connectStatus(true);
                    var result = new byte[1024];
                    await client.ReceiveAsync(new ArraySegment<byte>(result), token);
                    var receiveMsg = Encoding.UTF8.GetString(result, 0, result.Length);
                    //消息凭借
                    var responseStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+ "    服务器: \r\n" + receiveMsg;
                    TextUtils.appendStr(Messages, responseStr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败", ex.Message);
            }
        }

        public  void connectStatus(Boolean flag) {
            if (flag)
            {
                CloseBtn.IsEnabled = true;
                ClearBtn.IsEnabled = true;
                SendBtn.IsEnabled = true;
                WebsocketUrl.IsReadOnly = true;
                ConnectBtn.IsEnabled = false;
            }
            else {
                CloseBtn.IsEnabled = false;
                ClearBtn.IsEnabled = false;
                SendBtn.IsEnabled = false;
                WebsocketUrl.IsReadOnly = false;
                ConnectBtn.IsEnabled = true;
            }

        }

        private void ClearMessages(object sender, RoutedEventArgs e)
        {
            TextUtils.setStr(Messages, "");
        }
    }
}
