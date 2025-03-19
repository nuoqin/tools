using nuoqin.src.utils;
using System;
using System.Windows;
using System.Windows.Controls;

namespace nuoqin.src.Pages
{
    /// <summary>
    /// YAMLPage.xaml 的交互逻辑
    /// </summary>
    public partial class YAMLPage : Page
    {
        public YAMLPage()
        {
            InitializeComponent();
        }

        private void format(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);
                TextUtils.setStr(newCode, YamlUtils.toJSONStr(text));
            }
            catch (Exception ex)
            {
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
