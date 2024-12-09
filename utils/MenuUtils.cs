using CodeTools.common.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace CodeTools.utils
{
    public class MenuUtils
    {
        public static ObservableCollection<Menubar> menuBars = new ObservableCollection<Menubar>(){

            new Menubar() { Icon = "home", Title = "首页", NameSpace = "HomeWindow" },
            new Menubar() { Icon = "AccountBoxMultiple", Title = "密码管理", NameSpace = "MemoUserControl" },
            new Menubar() { Icon = "AllInclusiveBox", Title = "随机生成", NameSpace = "RandomUserControl" },
            new Menubar() { Icon = "AccessPointNetworkOff", Title = "内网工具", NameSpace = "LocalServiceViewUserControl" },
            new Menubar() { Icon = "Laptop", Title = "系统工具", NameSpace = "SystemViewUserControl" },
            new Menubar() { Icon = "CalendarRange", Title = "日期工具", NameSpace = "DateTimeViewUserControl" },
            new Menubar() { Icon = "CodeJson", Title = "JSON工具", NameSpace = "JSONViewUserControl" },
            new Menubar() { Icon = "Xml", Title = "XML工具", NameSpace = "XmlViewUserControl" },
            new Menubar() { Icon = "Apps", Title = "YAML工具", NameSpace = "YamlViewUserControl" },
            new Menubar() { Icon = "ApplicationExport", Title = "MD5工具", NameSpace = "Md5ViewUserControl" },
            new Menubar() { Icon = "ApplicationExport", Title = "AES加解密", NameSpace = "AESViewUserControl" },
            new Menubar() { Icon = "ApplicationExport", Title = "RSA加解密", NameSpace = "RsaViewUserControl" },
            new Menubar() { Icon = "ArrowCollapseHorizontal", Title = "BASE64工具", NameSpace = "Base64ViewUserControl" },
            new Menubar() { Icon = "MicrosoftInternetExplorer", Title = "URL编解码", NameSpace = "UrlViewUserControl" },
            new Menubar() { Icon = "QrcodeScan", Title = "二维码工具", NameSpace = "QRCodeViewUserControl" },
            new Menubar() { Icon = "WebBox", Title = "websocket", NameSpace = "WsClientViewUserControl" },
            new Menubar() { Icon = "Wifi", Title = "无线连接", NameSpace = "WlanViewUserControl" },
        };

    }
}
