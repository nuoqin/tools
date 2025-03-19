using CommunityToolkit.Mvvm.ComponentModel;
using nuoqin.src.utils;
using System.Collections.ObjectModel;
using Wpf.Ui;
using Wpf.Ui.Controls;
namespace nuoqin.src.Model
{
    public class MainWindowViewModel : ObservableObject
    {
        private bool isInitialized = false;

        private string applicationTitle;

        public string ApplicationTitle
        {
            get { return applicationTitle; }
            set { applicationTitle = value; }
        }

        private ObservableCollection<object> navigationItems;

        public ObservableCollection<object> NavigationItems
        {
            get { return navigationItems; }
            set { navigationItems = value; }
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Demo")]
        public MainWindowViewModel(INavigationService navigationService)
        {
            if (!isInitialized)
            {
                InitializeViewModel();
            }
        }

        private void InitializeViewModel()
        {
            ApplicationTitle = "nuoqin 工具";
            NavigationItems = SystemMenusUtils.initMenus();
            isInitialized = true;
        }
    }
}
