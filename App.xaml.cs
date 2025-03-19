using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using nuoqin.src;
using nuoqin.src.Model;
using nuoqin.src.Pages;
using nuoqin.src.Services;
using nuoqin.src.Services.Contracts;
using System;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using Wpf.Ui;

namespace nuoqin
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App
    {
        private static readonly IHost host = Host.CreateDefaultBuilder().ConfigureAppConfiguration(c =>
        {
            var basePath = Path.GetDirectoryName(AppContext.BaseDirectory)
                ?? throw new DirectoryNotFoundException(
                    "Unable to find the base directory of the application."
                );
            _ = c.SetBasePath(basePath);
        }).ConfigureServices(
          (context, services) =>
          {
              // App Host
              _ = services.AddHostedService<ApplicationHostService>();
              _ = services.AddSingleton<IWindow, MainWindow>();
              _ = services.AddSingleton<MainWindowViewModel>();
              _ = services.AddSingleton<INavigationService, NavigationService>();
              _ = services.AddSingleton<ISnackbarService, SnackbarService>();
              _ = services.AddSingleton<IContentDialogService, ContentDialogService>();
              _ = services.AddSingleton<WindowsProviderService>();

              // Views and ViewModels

              _ = services.AddSingleton<HomePage>();
              _ = services.AddSingleton<HomeViewModel>();

              _ = services.AddSingleton<SettingsPage>();
              _ = services.AddSingleton<SettingsViewModel>();


              _ = services.AddSingleton<JSONPage>();

              _ = services.AddSingleton<XMLPage>();

              _ = services.AddSingleton<YAMLPage>();

              _ = services.AddSingleton<DateTimePage>();

              _ = services.AddSingleton<Md5Page>();

              _ = services.AddSingleton<URLPage>();

              _ = services.AddSingleton<RandomPage>();

              _ = services.AddSingleton<AESPage>();

              _ = services.AddSingleton<RSAPage>();

              _ = services.AddSingleton<QRCodePage>();

              _ = services.AddSingleton<BASE64Page>();

              _ = services.AddSingleton<UnicodePage>();


              _ = services.AddSingleton<WebSockePage>();

              _ = services.AddSingleton<HttpPage>();

              _ = services.AddSingleton<TextPage>();
              _ = services.AddSingleton<TextViewModel>();

              _ = services.AddSingleton<WindowsServicePage>();

              _ = services.AddSingleton<PasswordManagerPage>();

              _ = services.AddSingleton<LocalServicePage>();
          }
      )
      .Build();



        public static T GetService<T>() where T : class
        {
            return host.Services.GetService<T>();
        }


        private void OnStartup(object sender, StartupEventArgs e)
        {
            host.StartAsync();
        }


        private async void OnExit(object sender, ExitEventArgs e)
        {
            await host.StopAsync();
            host.Dispose();
        }


        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
        }


    }
}
