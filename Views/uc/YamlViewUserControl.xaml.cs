using code_tools.utils;
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
using tools;
using tools.utils;

namespace CodeTools.view
{
    /// <summary>
    /// JSONFormatUC.xaml 的交互逻辑
    /// </summary>
    public partial class YamlViewUserControl : UserControl
    {
        public YamlViewUserControl()
        {
            InitializeComponent();
        }

        private void format(object sender, RoutedEventArgs e)
        {
            try {
                string text = TextUtils.getStr(sourceCode);
                TextUtils.setStr(newCode,YamlUtils.toJSONStr(text));
            } catch (Exception ex){
                MessageBox.Show(ex.Message);
            }   
           
        }
        /// <summary>
        /// yml转java的properties文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formatProp(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);
                
                TextUtils.setStr(newCode, YamlUtils.toPropertiesStr(text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formatXml(object sender, RoutedEventArgs e)
        {
            string text = TextUtils.getStr(sourceCode);
            try
            {
                TextUtils.setStr(newCode, YamlUtils.toXmlStr(text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
