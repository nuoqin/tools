using nuoqin.src.utils;
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

namespace nuoqin.src.Pages
{
    /// <summary>
    /// UnicodePage.xaml 的交互逻辑
    /// </summary>
    public partial class UnicodePage : Page
    {
        public UnicodePage()
        {
            InitializeComponent();
        }

        private void encode(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);
                TextUtils.setStr(newCode, UncodeUtils.encode(text));
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void decode(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);
                TextUtils.setStr(newCode, UncodeUtils.decode(text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
