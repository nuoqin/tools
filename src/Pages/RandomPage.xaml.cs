using nuoqin.src.utils;
using System;
using System.Windows;
using System.Windows.Controls;

namespace nuoqin.src.Pages
{
    /// <summary>
    /// RandomPage.xaml 的交互逻辑
    /// </summary>
    public partial class RandomPage : Page
    {
        public RandomPage()
        {
            InitializeComponent();
        }

        private void gen(object sender, RoutedEventArgs e)
        {
            randomStr.Text = RandomUtils.randomUUID();
            randomStrN.Text = RandomUtils.randomNUUID();
            randomNum6.Text = RandomUtils.randomNum(100000, 999999);
            randomNum4.Text = RandomUtils.randomNum(1000, 9999);
            DateTime targetDate = DateTime.Now;
            var date = new DateTimeOffset(targetDate);
            timestampStr.Text = date.ToUnixTimeMilliseconds().ToString();
            dateTimeStr.Text = date.ToString("yyyyMMddHHmmss");
        }

        private void clear()
        {
            randomStr.Text = "";
            randomNum6.Text = "";
            randomStrN.Text = "";
            timestampStr.Text = "";
            randomNum4.Text = "";
            dateTimeStr.Text = "";
        }

        private void clear(object sender, RoutedEventArgs e)
        {
            clear();
        }
    }
}
