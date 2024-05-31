using code_tools.model;
using code_tools.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace code_tools.utils
{
    public class MenuUtils
    {

        public static void initMenus(StackPanel leftMenu,MainWindow window) { 
            var home = new ItemMenu("首  页", new HomeUC());
            var date = new ItemMenu("日期工具", new DateTimeUserControl());
            var json = new ItemMenu("JSON工具", new JSONFormatUC());
            var yaml = new ItemMenu("YAML工具", new YamlUC());
            var xmlMenu = new ItemMenu("XML工具", new XMLUC());
            var md5 = new ItemMenu("MD5加密", new MD5UC());
            var base64 = new ItemMenu("BASE64编解码", new Base64UC());
            var url = new ItemMenu("URL编解码", new UrlUC());
            var pdf = new ItemMenu("二维码工具", new QRCodeUC());
            var net = new ItemMenu("内网工具", new NetUc());
            var item8 = new ItemMenu("websocket", new WebsocketClientUC());
            leftMenu.Children.Add(new UserControlMenuItem(home, window));
            leftMenu.Children.Add(new UserControlMenuItem(net, window));
            leftMenu.Children.Add(new UserControlMenuItem(date, window));
            leftMenu.Children.Add(new UserControlMenuItem(json, window));
            leftMenu.Children.Add(new UserControlMenuItem(xmlMenu, window));
            leftMenu.Children.Add(new UserControlMenuItem(yaml, window));
            leftMenu.Children.Add(new UserControlMenuItem(md5, window));
            leftMenu.Children.Add(new UserControlMenuItem(base64, window));
            leftMenu.Children.Add(new UserControlMenuItem(url, window));
            leftMenu.Children.Add(new UserControlMenuItem(pdf, window));
            leftMenu.Children.Add(new UserControlMenuItem(item8, window));


        }


    }
}
