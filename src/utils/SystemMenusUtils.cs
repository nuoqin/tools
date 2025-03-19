using nuoqin.src.Pages;
using System.Collections.ObjectModel;
using Wpf.Ui.Controls;

namespace nuoqin.src.utils
{
    public class SystemMenusUtils
    {
        public static ObservableCollection<object> initMenus()
        {
            ObservableCollection<object> items = new ObservableCollection<object>() {
                    new NavigationViewItem("首页",SymbolRegular.Home24,typeof(HomePage)),
                    new NavigationViewItem("JSON",SymbolRegular.CodeJsRectangle16,typeof(JSONPage)),
                    new NavigationViewItem("XML",SymbolRegular.CodeBlock16,typeof(XMLPage)),
                    new NavigationViewItem("YAML",SymbolRegular.Layer24,typeof(YAMLPage)),
                    new NavigationViewItem("时间",SymbolRegular.Timer32,typeof(DateTimePage)),
                    new NavigationViewItem("二维码",SymbolRegular.QrCode20,typeof(QRCodePage)),
                    new NavigationViewItem("ico",SymbolRegular.Icons20,typeof(QRCodePage)),
                    new NavigationViewItemSeparator(),
                    new NavigationViewItem("Md5",SymbolRegular.CircleHalfFill12,typeof(Md5Page)),
                    new NavigationViewItem("URL",SymbolRegular.Globe16,typeof(URLPage)),
                    new NavigationViewItem("AES",SymbolRegular.PhoneSpanIn16,typeof(AESPage)),
                    new NavigationViewItem("RSA",SymbolRegular.Ram16,typeof(RSAPage)),
                    new NavigationViewItem("Random",SymbolRegular.ExtendedDock24,typeof(RandomPage)),
                    new NavigationViewItemSeparator(),
                    new NavigationViewItem("BASE64",SymbolRegular.DatabaseStack16,typeof(BASE64Page)),
                    new NavigationViewItem("Unicode",SymbolRegular.EmojiHand48,typeof(UnicodePage)),
                    new NavigationViewItemSeparator(),
                    new NavigationViewItem("websocket",SymbolRegular.Apps24,typeof(WebSockePage)),
                    //new NavigationViewItem("Http工具",SymbolRegular.BeakerEmpty16,typeof(HttpPage)),
                    new NavigationViewItem("windows服务",SymbolRegular.WindowDevTools24,typeof(WindowsServicePage)),
                    new NavigationViewItem("网络工具",SymbolRegular.Archive16,typeof(LocalServicePage)),
            };
            return items;
        }

    }
}
