using nuoqin.src.utils;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace nuoqin.src.Pages
{
    /// <summary>
    /// DateTimePage.xaml 的交互逻辑
    /// </summary>
    public partial class DateTimePage : Page
    {
        public DateTimePage()
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
        private void format(object sender, RoutedEventArgs e)
        {
            string dateStr = source.Text;
            var checkeds = check.IsChecked.Value;
            //判断是否是16进制的时间
            if (checkeds)
            {
                try
                {
                    // 尝试将字符串转换为整数，基数为16
                    long number = Convert.ToInt64(dateStr, 16);
                    setTime(number + "");
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

        private void time()
        {
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
