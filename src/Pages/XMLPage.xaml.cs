using Newtonsoft.Json;
using nuoqin.src.utils;
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace nuoqin.src.Pages
{
    /// <summary>
    /// XMLPage.xaml 的交互逻辑
    /// </summary>
    public partial class XMLPage : Page
    {
        public XMLPage()
        {
            InitializeComponent();
        }

        private void format(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(text);
                TextUtils.setStr(newCode, JSONUtils.formatJson(JsonConvert.SerializeXmlNode(xmlDocument)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
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
                xmlTextWriter.Formatting = System.Xml.Formatting.Indented;
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
            try
            {
                string text = TextUtils.getStr(sourceCode);
                TextUtils.setStr(newCode, text.Replace("\r\n", ""));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }
    }
}
