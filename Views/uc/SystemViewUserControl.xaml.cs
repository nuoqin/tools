using model;
using utils;
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
using CodeTools.utils;

namespace CodeTools.view
{
    /// <summary>
    /// SystemView.xaml 的交互逻辑
    /// </summary>
    public partial class SystemViewUserControl : UserControl
    {

        private static List<SystemModel> items;

        public SystemViewUserControl()
        {
            InitializeComponent();
            items = SystemCommondUtils.systemModels;
            item.ItemsSource = items;
        }

        /**
         * 执行命令
         */
        private void execCommond(object sender, RoutedEventArgs e)
        {
            var data=new SystemModel("","");
            try
            {
                var btn = (Button) sender;
                var textBlock=(TextBlock) btn.Content;
                var text = textBlock.Text;
                var item = items.Where(x => x.Text == text).ToList();
                if (item.Count <= 0){
                    MessageBox.Show("未找到相关命令！");
                    return;
                }
                data=item[0];
                var process = new Process(){
                    StartInfo = new ProcessStartInfo(@"C:\Windows\Sysnative\cmd.exe", "/c "+data.Commond)
                    {
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };
                process.Start();
            }catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
        }
    }
}
