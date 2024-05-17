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
    }
}
