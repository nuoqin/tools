using code_tools.utils;
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

namespace code_tools.view
{
    /// <summary>
    /// NetUc.xaml 的交互逻辑
    /// </summary>
    public partial class NetUc : UserControl
    {
        public NetUc()
        {
            InitializeComponent();
            
        }

        private void search(object sender, RoutedEventArgs e)
        {
            try
            {
                TextUtils.setStr(newCode, SystemUtils.getLocalIP());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void findIPs(object sender, RoutedEventArgs e)
        {
            try
            {
                TextUtils.setStr(newCode, SystemUtils.getCurLocalNetIPs());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ping(object sender, RoutedEventArgs e)
        {
            try{
                var ip = TextUtils.getStr(newCode);
                TextUtils.setStr(newCode, SystemUtils.ping(ip));
            }catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void clear(object sender, RoutedEventArgs e)
        {
            TextUtils.setStr(newCode,"");
        }

        private void exec(object sender, RoutedEventArgs e)
        {
            try
            {
                var process = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        FileName = "dxdiag.exe"
                    }
                };
                process.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
    }
}
