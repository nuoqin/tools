﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using tools.utils;

namespace CodeTools.view
{
    /// <summary>
    /// DateTimeUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class DateTimeViewUserControl : UserControl
    {
        public DateTimeViewUserControl()
        {
            InitializeComponent();
        }

        public static bool IsHexadecimal(string input)
        {
            // 正则表达式匹配十六进制数
            string pattern = @"([^A-Fa-f0-9]|\s+?)+";
            return Regex.IsMatch(input, pattern);
        }



        /**
         *
         * 日期格式化
         * 
         */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string dateStr = source.Text;
            var checkeds = check.IsChecked.Value;
            //判断是否是16进制的时间
            if (checkeds) {
                try{
                    // 尝试将字符串转换为整数，基数为16
                    long number = Convert.ToInt64(dateStr, 16);
                    setTime(number+"");
                    long ms = number * 1000;
                    tsMs.Text = ms + "";
                    tsSs.Text = number + "";
                }
                catch (FormatException)
                {
                    // 转换失败，不是有效的十六进制数
                    MessageBox.Show("转换失败，不是有效的十六进制数");
                }
            }
            else
            {
                try
                {
                    long timestamp = long.Parse(dateStr);
                    setTime(dateStr);
                }
                catch (Exception ex)
                {
                    try
                    {
                        tsMs.Text = DateUtil.toTimeStampMs(dateStr);
                        tsSs.Text = DateUtil.toTimeStampS(dateStr);
                        date();
                    }
                    catch (Exception exce)
                    {
                        MessageBox.Show(exce.Message, "格式化错误");
                    }
                }

            }

            
        }

        private void setTime(string dateStr)
        {
            dateBox.Text = DateUtil.toDateAllStr(dateStr);
            datetimeBox.Text = DateUtil.toDateStr(dateStr);
            timeBox.Text = DateUtil.toTimeStr(dateStr);
            date2Box.Text = DateUtil.toDate2AllStr(dateStr);
            datetime2Box.Text = DateUtil.toDate2Str(dateStr);
            time2Box.Text = DateUtil.toTime2Str(dateStr);
            time();
        }

        private void time() {
            tsMs.Text = "";
            tsSs.Text = "";
        }

        private void date()
        {
            dateBox.Text = "";
            datetimeBox.Text = "";
            timeBox.Text = "";
        }
    }
}
