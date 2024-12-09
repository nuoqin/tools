using CodeTools.viewModels;
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
using System.Windows.Shapes;

namespace CodeTools.views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            minBtn.Click += (s, e) =>{
                this.WindowState = WindowState.Minimized;
            };

            maxBtn.Click += (s, e) =>{
                if (this.WindowState == WindowState.Maximized)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Maximized;
            };

            closeBtn.Click += (s, e) =>{
                this.Close();
            };

            moveZone.MouseMove += (s, e) =>{
                if (e.LeftButton == MouseButtonState.Pressed)
                    this.DragMove();

            };

            moveZone.MouseDoubleClick += (s, e) =>{
                if (this.WindowState == WindowState.Normal)
                    this.WindowState = WindowState.Maximized;
                else
                    this.WindowState = WindowState.Normal;
            };
            //菜单点击收缩
            menuBar.SelectionChanged += (s, e) =>{
                drawerHost.IsLeftDrawerOpen = false;
            };
        }
    }
}
