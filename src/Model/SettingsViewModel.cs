using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wpf.Ui.Controls;

namespace nuoqin.src.Model
{

    public partial class SettingsViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;


        private string appVersion;

        public string AppVersion
        {
            get { return appVersion; }
            set { appVersion = value; }
        }

        private Wpf.Ui.Appearance.ApplicationTheme currentApplicationTheme;

        public Wpf.Ui.Appearance.ApplicationTheme CurrentApplicationTheme
        {
            get { return currentApplicationTheme; }
            set { currentApplicationTheme = value; }
        }

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
            {
                InitializeViewModel();
            }
        }

        public void OnNavigatedFrom() { }

        private void InitializeViewModel()
        {
            CurrentApplicationTheme = Wpf.Ui.Appearance.ApplicationThemeManager.GetAppTheme();
            AppVersion = $"Wpf.Ui.Demo.Mvvm - {GetAssemblyVersion()}";
            _isInitialized = true;
        }

        private static string GetAssemblyVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString()
                ?? string.Empty;
        }

        [RelayCommand]
        private void OnChangeTheme(string parameter)
        {
            switch (parameter)
            {
                case "theme_light":
                    if (CurrentApplicationTheme == Wpf.Ui.Appearance.ApplicationTheme.Light)
                    {
                        break;
                    }
                    Wpf.Ui.Appearance.ApplicationThemeManager.Apply(Wpf.Ui.Appearance.ApplicationTheme.Light);
                    CurrentApplicationTheme = Wpf.Ui.Appearance.ApplicationTheme.Light;
                    break;
                default:
                    if (CurrentApplicationTheme == Wpf.Ui.Appearance.ApplicationTheme.Dark)
                    {
                        break;
                    }
                    Wpf.Ui.Appearance.ApplicationThemeManager.Apply(Wpf.Ui.Appearance.ApplicationTheme.Dark);
                    CurrentApplicationTheme = Wpf.Ui.Appearance.ApplicationTheme.Dark;
                    break;
            }
        }
    }
}