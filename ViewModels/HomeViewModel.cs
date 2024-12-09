using CodeTools.common.model;
using CodeTools.Extensions;
using CodeTools.model;
using CodeTools.utils;
using CodeTools.viewModels;
using ImTools;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace CodeTools.ViewModels
{
    public class HomeViewModel : NavigationViewModel
    {
        public HomeViewModel(IContainerProvider provider) : base(provider){
            menuBars = MenuUtils.menuBars;
            createItem();
            NavigateCommand = new DelegateCommand<Menubar>(Navigate);
            loadCustomizeFunction();
            CustomizeFunctionCommand = new DelegateCommand<CustomizeFunction>(CustomizeFunctionExecute);
            LoadCustomizeFunctionCommand = new DelegateCommand(RefeshCustomizeFunction);
            OpenCustomizeFunctionCommand = new DelegateCommand(openConfigExecute);
            BuildCustomizeFunctionCommand = new DelegateCommand(buildNewFile);
            //从容器中获取
            this.regionManager = provider.Resolve<IRegionManager>();
        }
        //item集合
        private ObservableCollection<Menubar> menuBars;

        public ObservableCollection<Menubar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }
        public DelegateCommand<Menubar> NavigateCommand { get; private set; }

        private readonly IRegionManager regionManager;
        /// <summary>
        ///  中间区域切换，并设置前后操作
        /// </summary>
        /// <param name="menubar"></param>
        private void Navigate(Menubar menubar)
        {
            if (menubar == null || string.IsNullOrEmpty(menubar.Title))
            {
                return;
            }
            if(string.IsNullOrEmpty(menubar.NameSpace))
            {
                executeExe(menubar);
                return;
            }
            open(menubar.NameSpace);
        }
        private void executeExe(Menubar menubar)
        {
            var dir = Environment.CurrentDirectory;
            var exePath = "";
            switch (menubar.Title)
            {
                case "es客户端":
                    exePath = Path.Combine(dir + "\\elasticsearch", "elasticvue.exe");
                    break;
                case "Dism++":
                    exePath = Path.Combine(dir+ "\\Dism++", "Dism++x64.exe");
                    break;
                case "文件搜索":
                    exePath = Path.Combine(dir + "\\Everything", "Everything.exe");
                    break;
            }
            try{
                Process.Start(exePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法执行文件：" + ex.Message);
            }
        }
        /**
         * 
         * 初始化按钮 
         */
        private void createItem()
        {
            menuBars.Add(new Menubar() { Icon = "AlphaECircle", Title = "es客户端", NameSpace = "", Color = "#1565c0" });
            menuBars.Add(new Menubar() { Icon = "CloseCircle", Title = "Dism++", NameSpace = "", Color = "#1565c0" });
            menuBars.Add(new Menubar() { Icon = "TextBoxSearch", Title = "文件搜索", NameSpace = "", Color = "#1565c0" });
        }
        private void open(string path)
        {
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(path);
        }
        //自定义功能
        private ObservableCollection<CustomizeFunction> customizeFunctions;

        public ObservableCollection<CustomizeFunction> CustomizeFunctions
        {
            get { return customizeFunctions; }
            set { customizeFunctions = value; RaisePropertyChanged(); }
        }

        public DelegateCommand<CustomizeFunction> CustomizeFunctionCommand { get; private set; }

        public DelegateCommand LoadCustomizeFunctionCommand { get; private set; }

        public DelegateCommand OpenCustomizeFunctionCommand { get; private set; }

        public DelegateCommand BuildCustomizeFunctionCommand { get; private set; }

        /// <summary>
        ///  中间区域切换，并设置前后操作
        /// </summary>
        /// <param name="customizeFunction"></param>
        private void CustomizeFunctionExecute(CustomizeFunction customizeFunction)
        {
            try {
                Process.Start(customizeFunction.Commond);
            } catch (Exception ex) {
                MessageBox.Show("无法执行文件：" + ex.Message);
            }
        }

        //加载
        private  void loadCustomizeFunction() {
            try
            {
                var customizeFunctionFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                var dirPath = customizeFunctionFolderPath + "\\nuoqin";
                DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                    File.SetAttributes(dirPath, directoryInfo.Attributes | FileAttributes.Hidden);
                }
                var jsonFile = customizeFunctionFolderPath + "\\nuoqin\\tools_customize.json";
                //判断文件是否存在
                if (!File.Exists(jsonFile))
                {
                    File.WriteAllText(jsonFile, "{\r\n  \"list\":[\r\n     { \"title\":\"Navicat2\",\"description\":\"数据库管理软件\",\"commond\":\"E:\\\\tools\\\\Navicat Premium 12\\\\navicat.exe\"}\r\n  ]\r\n}");
                    return;
                }
                string jsonStr = File.ReadAllText(jsonFile, Encoding.UTF8);
                if (string.IsNullOrEmpty(jsonStr))
                {
                    return;
                }
                CustomizeData data = JsonConvert.DeserializeObject<CustomizeData>(jsonStr);
                CustomizeFunctions = data.List;
            }
            catch (Exception ex) {
                MessageBox.Show("加载自定义应用失败：" + ex.Message, "错误");
            }
            
        }


        private void RefeshCustomizeFunction()
        {
            try
            {
                var customizeFunctionFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var jsonFile = customizeFunctionFolderPath + "\\nuoqin\\tools_customize.json";
                //判断文件是否存在
                if (!File.Exists(jsonFile))
                {
                    MessageBox.Show("文件不存在", "错误");
                    return;
                }
                string jsonStr = File.ReadAllText(jsonFile, Encoding.UTF8);
                if (string.IsNullOrEmpty(jsonStr))
                {
                    return;
                }
                CustomizeData data = JsonConvert.DeserializeObject<CustomizeData>(jsonStr);
                CustomizeFunctions.Clear();
                CustomizeFunctions = data.List;
            }
            catch (Exception ex)
            {
                MessageBox.Show("刷新失败：" + ex.Message, "错误");
            }
            
        }


        private void buildNewFile()
        {
            try
            {
                var customizeFunctionFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var jsonFile = customizeFunctionFolderPath + "\\nuoqin\\tools_customize.json";
                File.Delete(jsonFile);
                File.WriteAllText(jsonFile, "{\r\n  \"list\":[\r\n     { \"title\":\"Navicat2\",\"description\":\"数据库管理软件\",\"commond\":\"E:\\\\tools\\\\Navicat Premium 12\\\\navicat.exe\"}\r\n  ]\r\n}");
                openConfigExecute();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法打开文件：{ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void openConfigExecute()
        {
            var customizeFunctionFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var jsonFile = customizeFunctionFolderPath + "\\nuoqin\\tools_customize.json";
            try
            {
                // 使用 Process.Start 打开记事本并加载文件
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "notepad.exe", // 记事本可执行文件
                    Arguments = jsonFile, // 确保文件路径被正确引用
                    UseShellExecute = false, // 不需要使用操作系统外壳
                    CreateNoWindow = false   // 创建一个新窗口
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法打开文件：{ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
