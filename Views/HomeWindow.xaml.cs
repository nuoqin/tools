using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace CodeTools.Views
{
    /// <summary>
    /// HomeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class HomeWindow : UserControl
    {
        public HomeWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 跳转到我的主页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jumpIndex(object sender, RoutedEventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "https://github.com/nuoqin";
            proc.Start();
        }
        /// <summary>
        /// 
        /// 仓库地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jump(object sender, RoutedEventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "https://github.com/nuoqin/tools";
            proc.Start();
        }

        //private void openConfig(object sender, MouseButtonEventArgs e)
        //{
        //    var customizeFunctionFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        //    var jsonFile = customizeFunctionFolderPath + "\\tools_customize.json";
        //    MessageBox.Show("当前配置文件路径："+ jsonFile+"\r\r"+ "配置信息如下：\r\n {\r\n  \"list\":[\r\n    { \"title\":\"obs客户端\",\"description\":\"obs客户端\",\"commond\":\"E:\\\\Program Files\\\\OBS\\\\obs-browser-plus\\\\obs-browser-plus.exe\"}\r\n  ]\r\n}","配置文件介绍");
        //    try
        //    {
        //        // 使用 Process.Start 打开记事本并加载文件
        //        ProcessStartInfo psi = new ProcessStartInfo
        //        {
        //            FileName = "notepad.exe", // 记事本可执行文件
        //            Arguments = jsonFile, // 确保文件路径被正确引用
        //            UseShellExecute = false, // 不需要使用操作系统外壳
        //            CreateNoWindow = false   // 创建一个新窗口
        //        };
        //        Process.Start(psi);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"无法打开文件：{ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}
    }
}
