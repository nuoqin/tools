using code_tools.model;
using code_tools.view;
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

namespace code_tools
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //记录上一个点击的菜单
        MenuItem lastMenuItem;

        //上一个
        ItemMenu lastItemMenu;

        public MainWindow()
        {
            InitializeComponent();
            var item1 = new ItemMenu("首页", new UserControlCustomers());
            var item2 = new ItemMenu("日期工具", new DateTimeUserControl());
            var item3 = new ItemMenu("JSON工具", new JSONFormatUC());
            var item5 = new ItemMenu("MD5加密", new MD5UC());
            var item6 = new ItemMenu("BASE64编解码", new Base64UC());
            var item7 = new ItemMenu("URL编解码", new UrlUC());
            var item8 = new ItemMenu("websocket", new WebsocketClientUC());
            leftMenu.Children.Add(new UserControlMenuItem(item1, this));
            leftMenu.Children.Add(new UserControlMenuItem(item2, this));
            leftMenu.Children.Add(new UserControlMenuItem(item3, this));
            leftMenu.Children.Add(new UserControlMenuItem(item5, this));
            leftMenu.Children.Add(new UserControlMenuItem(item6, this));
            leftMenu.Children.Add(new UserControlMenuItem(item7, this));
            leftMenu.Children.Add(new UserControlMenuItem(item8, this));
            SwitchScreen(new UserControlCustomers());
        }

        internal void SwitchScreen(object sender){
            var screen = ((UserControl)sender);
            if (screen != null){
                main.Children.Clear();
                //清除菜单样式
                main.Children.Add(screen);
            }
        }

        internal void setLastMenu(object sender)
        {
            var menuItem = ((MenuItem)sender);
            if(menuItem != null)
            {
                lastMenuItem = menuItem;
            }
        }

        internal void clearColor()
        {
            if (lastMenuItem != null)
            {
                lastMenuItem.Background = new SolidColorBrush(Colors.White);
                lastMenuItem.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
    }
}
