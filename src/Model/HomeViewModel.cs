using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using nuoqin.src.entity;
using nuoqin.src.utils;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui;

namespace nuoqin.src.Model
{
    public class HomeViewModel : ObservableObject
    {
        private bool _isInitialized = false;

        public HomeViewModel()
        {
            if (!_isInitialized)
            {
                InitializeViewModel();
            }
            ProcessFunctionCommand = new RelayCommand<CustomizeFunction>(processFunction);
            ConfigProcessCommand = new RelayCommand<string>(ConfigProcess);
            ProcessSystemToolCommand = new RelayCommand<SystemTool>(processCurrentSystem);
        }

        public RelayCommand<CustomizeFunction> ProcessFunctionCommand { get; private set; }

        private void processFunction(CustomizeFunction function)
        {
            if (function != null)
            {
                try
                {
                    Process.Start(function.Commond);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无法执行文件：" + ex.Message);
                }
            }
        }

        public RelayCommand<string> ConfigProcessCommand { get; private set; }

        private void ConfigProcess(string clickStr)
        {
            if (clickStr != null)
            {
                switch (clickStr)
                {
                    case "edit":
                        CustomToolsUtils.OpenConfigExecute();
                        break;
                    case "refresh":
                        CustomizeData customizeData = CustomToolsUtils.LoadCustomizeFunction();
                        CustomizeFunctions = customizeData.List;
                        break;
                    case "init":
                        CustomToolsUtils.BuildNewFile();
                        break;
                    default:
                        break;
                }
            }
        }
        private readonly INavigationService _navigationService;
        //自定义功能
        private ObservableCollection<CustomizeFunction> customizeFunctions;

        public ObservableCollection<CustomizeFunction> CustomizeFunctions
        {
            get => customizeFunctions;
            set => SetProperty(ref customizeFunctions, value);
        }

        private void InitializeViewModel()
        {
            CustomizeData customizeData = CustomToolsUtils.LoadCustomizeFunction();
            CustomizeFunctions = customizeData.List;
            //系统整理工具，小工具，不建议太大
            SystemTools = SystemToolsUtils.init();
        }


        //系统功能
        //自定义功能
        private ObservableCollection<SystemTool> systemTools;

        public ObservableCollection<SystemTool> SystemTools
        {
            get => systemTools;
            set => SetProperty(ref systemTools, value);
        }


        public RelayCommand<SystemTool> ProcessSystemToolCommand { get; private set; }

        private void processCurrentSystem(SystemTool systemTool)
        {
            var dir = Environment.CurrentDirectory;
            var exePath = "";
            if (systemTool != null)
            {
                try
                {
                    exePath = dir+systemTool.Commond;
                    Process.Start(exePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "执行失败");
                }
            }
        }

    }
}
