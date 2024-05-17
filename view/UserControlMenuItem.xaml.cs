using code_tools.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace code_tools.view
{
    /// <summary>
    /// UserControlMenuItem.xaml 的交互逻辑
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {
        MainWindow _context;

        public UserControlMenuItem(ItemMenu itemMenu, MainWindow context)
        {
            InitializeComponent();
            _context = context;
            this.DataContext = itemMenu;
        }

        private void menuClick(object sender, RoutedEventArgs e)
        {
            _context.clearColor();
            var mi = (MenuItem)sender;
            mi.Background = new SolidColorBrush(Color.FromRgb(2, 112, 193));
            mi.Foreground = new SolidColorBrush(Colors.White);
            var currentItemMenu = (ItemMenu)((MenuItem)sender).DataContext;
            _context.SwitchScreen(currentItemMenu.Screen);
            //把当前菜单设置为最后的菜单
            _context.setLastMenu(mi);
        }



    }
}
