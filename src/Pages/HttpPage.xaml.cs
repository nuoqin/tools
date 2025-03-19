using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YamlDotNet.Core.Tokens;

namespace nuoqin.src.Pages
{
    /// <summary>
    /// HttpPage.xaml 的交互逻辑
    /// </summary>
    public partial class HttpPage : Page
    {
        public HttpPage()
        {
            InitializeComponent();
        }

        private async void SendRequest(object sender, RoutedEventArgs e)
        {
            try
            {
                ComboBoxItem selectedItem = RequestMethod.SelectedItem as ComboBoxItem;
                var method= selectedItem.Content.ToString();
                var url = RequestUrl.Text;
                var headers = HeadersText.Text;
                var HeaderArr = headers.Split("\r\n".ToCharArray());
                List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
                if (HeaderArr.Length > 0) {
                    foreach(string item in HeaderArr) { 
                        var paramArr=item.Split(':');
                        Dictionary<string, string> data = new Dictionary<string, string>();
                        data.Add(paramArr[0], paramArr[1]);
                        list.Add(data);
                    }
                }
                var bodys = BodyText.Text;
                var str = "";
                switch (method)
                {
                    case "GET":
                        str = await HttpUtils.Get(new entity.CutstomHttpEntity(url, list, null, bodys));
                        break;
                    case "POST":
                        str = await HttpUtils.PostJson(new entity.CutstomHttpEntity(url, list, null, bodys));
                        break;
                    case "PUT":
                        str = await HttpUtils.PutAsync(new entity.CutstomHttpEntity(url, list, null, bodys));
                        break;
                    case "DELETE":
                        str = await HttpUtils.DeleteAsync(new entity.CutstomHttpEntity(url, list, null, null));
                        break;
                    default:
                        break;

                }
                ResponseStr.Text = str;
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message);

            }
        }
    }
}
