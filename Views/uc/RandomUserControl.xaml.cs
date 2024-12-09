using CodeTools.utils;
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

namespace CodeTools.Views.uc
{
    /// <summary>
    /// RandomUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class RandomUserControl : UserControl
    {
        public RandomUserControl()
        {
            InitializeComponent();
            clear();
        }

        private void gen(object sender, RoutedEventArgs e)
        {
            randomStr.Text = RandomUtils.randomUUID();
            randomStrN.Text = RandomUtils.randomNUUID();
            randomNum6.Text = RandomUtils.randomNum(100000,999999);
            randomNum4.Text = RandomUtils.randomNum(1000, 9999);
            DateTime targetDate = DateTime.Now;
            var date = new DateTimeOffset(targetDate);
            datetimeStr.Text = date.ToUnixTimeMilliseconds().ToString();

        }


        private void clear() {
            randomStr.Text = "";
            randomNum6.Text = "";
            randomStrN.Text = "";
            randomNum4.Text = "";
            datetimeStr.Text = "";
        }

        private void clear(object sender, RoutedEventArgs e)
        {
            clear();
        }
    }
}
