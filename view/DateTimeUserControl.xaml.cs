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
using tools.utils;

namespace code_tools.view
{
    /// <summary>
    /// DateTimeUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class DateTimeUserControl : UserControl
    {
        public DateTimeUserControl()
        {
            InitializeComponent();
        }

        /**
         *
         * 日期格式化
         * 
         */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string dateStr = source.Text;
            try {
                long timestamp = long.Parse(dateStr);
                dateBox.Text = DateUtil.toDateAllStr(dateStr);
                datetimeBox.Text = DateUtil.toDateStr(dateStr);
                timeBox.Text = DateUtil.toTimeStr(dateStr);
            }catch(Exception ex) {
                tsMs.Text = DateUtil.toTimeStampMs(dateStr);
                tsSs.Text = DateUtil.toTimeStampS(dateStr);
            }
        }
    }
}
