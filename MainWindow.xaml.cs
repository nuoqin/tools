using code_tools.model;
using code_tools.utils;
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

        private static bool isOpen = false;

        public MainWindow()
        {
            InitializeComponent();
            MenuUtils.initMenus(leftMenu, this);
            SwitchScreen(new HomeUC());
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
