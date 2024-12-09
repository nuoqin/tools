using CodeTools.common.config;
using CodeTools.common.model;
using CodeTools.Extensions;
using CodeTools.utils;
using CodeTools.view;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace CodeTools.viewModels
{
    public class MainWindowViewModel : BindableBase, IConfigure
    {
        public MainWindowViewModel(IContainerProvider containerProvider, IRegionManager regionManager) {
            MenuBars = MenuUtils.menuBars;
            NavigateCommand = new DelegateCommand<Menubar>(Navigate);
            //初始化后退操作
            GoBackCommand = new DelegateCommand(() =>{
                if (journal!=null && journal.CanGoBack)
                {
                    journal.GoBack();
                }
                else if(journal==null)
                {
                    Navigate(new Menubar() { Title="首页",NameSpace= "HomeWindow" });
                }
            });
            //初始化前进操作
            ForwardCommand = new DelegateCommand(() =>
            {
                if (journal != null && journal.CanGoForward)
                {
                    journal.GoForward();
                }
            });
            this.containerProvider = containerProvider;
            this.regionManager = regionManager;
        }

        /// <summary>
        ///  中间区域切换，并设置前后操作
        /// </summary>
        /// <param name="menubar"></param>
        private void Navigate(Menubar menubar) {
            if(menubar==null || string.IsNullOrEmpty(menubar.Title))
            {
                return;
            }
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(menubar.NameSpace, back => { 
                journal=back.Context.NavigationService.Journal;
            });

        }

        private readonly IContainerProvider containerProvider;

        public DelegateCommand GoBackCommand { get; private set; }

        public DelegateCommand ForwardCommand { get; private set; }

        public DelegateCommand<Menubar> NavigateCommand { get; private set; }

        private readonly IRegionManager regionManager;

        //区域导航日志
        private IRegionNavigationJournal journal;

        private ObservableCollection<Menubar> menuBars;

        public ObservableCollection<Menubar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }
        public void conifg(){
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate("HomeWindow");
        }

        //设置主题颜色
        private bool _isDarkTheme;
        public bool IsDarkTheme
        {
            get => _isDarkTheme;
            set
            {
                if (SetProperty(ref _isDarkTheme, value))
                {
                    ModifyTheme(theme => {
                        theme.SetBaseTheme(value ? BaseTheme.Dark : BaseTheme.Light);
                        theme.SetPrimaryColor(value ? Color.FromRgb(23, 23, 23) : Colors.White);
                    });
                }
            }
        }

        private static void ModifyTheme(Action<Theme> modificationAction)
        {
            var paletteHelper = new PaletteHelper();
            Theme theme = paletteHelper.GetTheme();
            modificationAction?.Invoke(theme);
            paletteHelper.SetTheme(theme);
        }
    }
}
