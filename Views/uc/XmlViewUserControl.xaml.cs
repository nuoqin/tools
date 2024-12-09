using code_tools.utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;
using tools;
using tools.utils;
using Formatting = System.Xml.Formatting;

namespace CodeTools.view
{
    /// <summary>
    /// JSONFormatUC.xaml 的交互逻辑
    /// </summary>
    public partial class XmlViewUserControl : UserControl
    {
        public XmlViewUserControl()
        {
            InitializeComponent();
        }

        private void format(object sender, RoutedEventArgs e)
        {
            try {
                string text = TextUtils.getStr(sourceCode);
                XmlDocument xmlDocument = new XmlDocument();    
                xmlDocument.LoadXml(text);
                TextUtils.setStr(newCode, JSONUtils.formatJson(JsonConvert.SerializeXmlNode(xmlDocument)));
            } catch (Exception ex){
                MessageBox.Show(ex.Message,"错误");
            }   
           
        }

        private void parse(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(text);
                MemoryStream ms = new MemoryStream();

                XmlTextWriter xmlTextWriter = new XmlTextWriter(ms, Encoding.UTF8);
                xmlTextWriter.Formatting = Formatting.Indented;
                xmlTextWriter.Indentation = 4;
                xmlDocument.WriteContentTo(xmlTextWriter);
                xmlTextWriter.Close();
                TextUtils.setStr(newCode, Encoding.UTF8.GetString(ms.ToArray()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
            
        }


        private void zip(object sender, RoutedEventArgs e)
        {
            try {
                string text = TextUtils.getStr(sourceCode);
                TextUtils.setStr(newCode, text.Replace("\r\n",""));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }
    }
}
