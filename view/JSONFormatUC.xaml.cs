using code_tools.utils;
using Newtonsoft.Json.Linq;
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
using System.Xml.Linq;
using tools;

namespace code_tools.view
{
    /// <summary>
    /// JSONFormatUC.xaml 的交互逻辑
    /// </summary>
    public partial class JSONFormatUC : UserControl
    {
        public JSONFormatUC()
        {
            InitializeComponent();
        }

        private void format(object sender, RoutedEventArgs e)
        {
            try {
                string text = TextUtils.getStr(sourceCode);
                TextUtils.setStr(newCode,JSONUtils.formatJson(text));
            } catch (Exception ex){
                MessageBox.Show(ex.Message);
            }   
           
        }

        private void createJava(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);
                GenerateClass generateClass = new GenerateClass();
                generateClass.setName("JSONObject");
                generateClass.setAuthor("nuoqin");
                TextUtils.setStr(newCode, JSONUtils.generateJavaObjectStr(text, generateClass));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void createXML(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);
                var jObject = JObject.Parse(text);
                var xDocument = new XDocument();
                var rootElement = new XElement("Root");
                ConvertJObjectToXElement(jObject, rootElement);
                xDocument.Add(rootElement);

                TextUtils.setStr(newCode, xDocument.ToString());
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private static XElement ConvertJObjectToXElement(JObject jObject, XElement parent)
        {
            foreach (var property in jObject.Properties())
            {
                var propertyElement = new XElement(property.Name);

                if (property.Value.Type == JTokenType.Object)
                {
                    // 如果是子JObject则递归调用
                    ConvertJObjectToXElement((JObject)property.Value, propertyElement);
                }
                else if (property.Value.Type == JTokenType.Array)
                {
                    // 如果是JArray则递归遍历所有元素
                    foreach (var item in property.Value.Children())
                    {
                        if (item.Type == JTokenType.Object)
                        {
                            var arrayItemElement = new XElement(property.Name);
                            ConvertJObjectToXElement((JObject)item, arrayItemElement);
                            parent.Add(arrayItemElement);
                        }
                        else
                        {
                            var arrayItemElement = new XElement(property.Name, item.ToString());
                            parent.Add(arrayItemElement);
                        }
                    }
                }
                else
                {
                    // 处理基本数据类型
                    propertyElement.Value = property.Value.ToString();
                }

                parent.Add(propertyElement);
            }

            return parent;
        }
    }
}
