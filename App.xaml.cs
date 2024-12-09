using CodeTools.common.config;
using CodeTools.view;
using CodeTools.viewModels;
using CodeTools.ViewModels;
using CodeTools.ViewModels.utils;
using CodeTools.views;
using CodeTools.Views;
using CodeTools.Views.uc;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CodeTools
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        /**
         * 
         * 初始化 
         */
        protected override void OnInitialized()
        {
            var config = App.Current.MainWindow.DataContext as IConfigure;
            if (config != null)
            {
                config.conifg();
            }
            base.OnInitialized();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HomeWindow, HomeViewModel>();
            containerRegistry.RegisterForNavigation<Md5ViewUserControl, BaseViewModel>();
            containerRegistry.RegisterForNavigation<Base64ViewUserControl, BaseViewModel>();
            containerRegistry.RegisterForNavigation<DateTimeViewUserControl, BaseViewModel>();
            containerRegistry.RegisterForNavigation<LocalServiceViewUserControl, BaseViewModel>();
            containerRegistry.RegisterForNavigation<QRCodeViewUserControl, BaseViewModel>();
            containerRegistry.RegisterForNavigation<SystemViewUserControl, BaseViewModel>();
            containerRegistry.RegisterForNavigation<UrlViewUserControl, BaseViewModel>();
            containerRegistry.RegisterForNavigation<WsClientViewUserControl, BaseViewModel>();
            containerRegistry.RegisterForNavigation<YamlViewUserControl, BaseViewModel>();
            containerRegistry.RegisterForNavigation<XmlViewUserControl, BaseViewModel>();
            containerRegistry.RegisterForNavigation<JSONViewUserControl, BaseViewModel>();
            containerRegistry.RegisterForNavigation<AESViewUserControl, BaseViewModel>();
            containerRegistry.RegisterForNavigation<RsaViewUserControl, BaseViewModel>();
            containerRegistry.RegisterForNavigation<WlanViewUserControl, WlanViewModel>();
            containerRegistry.RegisterForNavigation<MemoUserControl, MemoViewModel>();
            containerRegistry.RegisterForNavigation<RandomUserControl, RandomViewMode>();
            containerRegistry.RegisterForNavigation<CodeViewUserControl, RandomViewMode>();
        }

        /// <summary>
        /// 配置规则
        /// </summary>
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
        }
    }

}
