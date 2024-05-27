using code_tools.utils;
using Newtonsoft.Json;
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
using System.Xml;
using tools;
using tools.utils;

namespace code_tools.view
{
    /// <summary>
    /// JSONFormatUC.xaml 的交互逻辑
    /// </summary>
    public partial class XMLUC : UserControl
    {
        public XMLUC()
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
    }
}
