﻿using code_tools.utils;
using CodeTools.model;
using CodeTools.utils;
using CodeTools.views;
using Microsoft.Win32;
using Newtonsoft.Json;
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
using tools.utils;

namespace CodeTools.view
{
    /// <summary>
    /// JSONFormatUC.xaml 的交互逻辑
    /// </summary>
    public partial class JSONViewUserControl : UserControl
    {
        public JSONViewUserControl()
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

        private void createCSharpClass(object sender, RoutedEventArgs e)
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
                TextUtils.setStr(newCode, JSONUtils.toXmlStr(jObject));
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toProperties(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = TextUtils.getStr(sourceCode);
                var jObject = JObject.Parse(text);
                TextUtils.setStr(newCode, JSONUtils.toProperties(jObject));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void readCsv(object sender, RoutedEventArgs e)
        {
            try
            {
                var flag = check.IsChecked.Value;
                string old = sourceCode.Text;
                if (!string.IsNullOrEmpty(old)) {
                    Dictionary<string, object> p = CsvUtils.readCsv(old,flag);
                    string json = JsonConvert.SerializeObject(p, Formatting.Indented);
                    TextUtils.setStr(newCode, json);
                }
                else
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Title = "选择csv文件";
                    openFileDialog.Filter = "(*.csv)|*.csv";
                    if (openFileDialog.ShowDialog() == true)
                    {
                        var fileName = openFileDialog.FileName;
                        sourceCode.Text = fileName;
                        Dictionary<string, object> p = CsvUtils.readCsv(fileName, flag);
                        string json = JsonConvert.SerializeObject(p, Formatting.Indented);
                        TextUtils.setStr(newCode, json);
                    }

                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void compress(object sender, RoutedEventArgs e)
        {

            try {
                string text = TextUtils.getStr(sourceCode);
                text= text.Replace("\r\n", "");
                text = text.Replace(" ", "");
                TextUtils.setStr(newCode, text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }
    }
}