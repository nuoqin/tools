using nuoqin.src.Model;
using nuoqin.src.Pages;
using nuoqin.src.Services.Contracts;
using System;
using System.Windows;
using Wpf.Ui;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace nuoqin.src
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : IWindow
    {
        public Model.MainWindowViewModel ViewModel { get; }

        public MainWindow(MainWindowViewModel viewModel,
            INavigationService navigationService,
            IServiceProvider serviceProvider,
            ISnackbarService snackbarService,
            IContentDialogService contentDialogService)
        {
            ViewModel = viewModel;
            DataContext = this;
            SystemThemeWatcher.Watch(this);
            InitializeComponent();
            snackbarService.SetSnackbarPresenter(SnackbarPresenter);
            navigationService.SetNavigationControl(NavigationView);
            //contentDialogService.SetDialogHost(RootContentDialog);
            NavigationView.SetServiceProvider(serviceProvider);
        }


        public INavigationView GetNavigation()
        {
            return NavigationView;
        }

        public bool Navigate(Type pageType)
        {
            return NavigationView.Navigate(pageType);
        }

        public void SetPageService(IPageService pageService)
        {
            NavigationView.SetPageService(pageService);
        }

        public void SetServiceProvider(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }

        public void ShowWindow()
        {
            Show();
        }

        public void CloseWindow()
        {
            Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        private void OnNavigationSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (sender is Wpf.Ui.Controls.NavigationView navigationView)
            {
                NavigationView.SetCurrentValue(
                    NavigationView.HeaderVisibilityProperty,
                    navigationView.SelectedItem?.TargetPageType != typeof(HomePage)
                        ? Visibility.Visible
                        : Visibility.Collapsed
                );
            }
        }

    }

}
