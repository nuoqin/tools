

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using nuoqin.src.Pages;
using nuoqin.src.Services.Contracts;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Wpf.Ui;
using Wpf.Ui.Appearance;

namespace nuoqin.src.Services
{

    /// <summary>
    /// Managed host of the application.
    /// </summary>
    public class ApplicationHostService : IHostedService
    {
        private readonly IServiceProvider serviceProvider;

        private INavigationWindow navigationWindow;

        public ApplicationHostService(IServiceProvider iServiceProvider)
        {
            serviceProvider = iServiceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return HandleActivationAsync();
        }

        /// <summary>
        /// Triggered when the application host is performing a graceful shutdown.
        /// </summary>
        /// <param name="cancellationToken">Indicates that the shutdown process should no longer be graceful.</param>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Creates main window during activation.
        /// </summary>
        private Task HandleActivationAsync()
        {
            if (Application.Current.Windows.OfType<MainWindow>().Any())
            {
                return Task.CompletedTask;
            }

            IWindow mainWindow = serviceProvider.GetRequiredService<IWindow>();
            mainWindow.Loaded += OnMainWindowLoaded;
            mainWindow?.Show();

            return Task.CompletedTask;
        }

        private void OnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            if (sender is MainWindow mainWindow)
            {
                ApplicationThemeManager.Apply(Wpf.Ui.Appearance.ApplicationTheme.Dark);
                _ = mainWindow.NavigationView.Navigate(typeof(HomePage));
            }
        }
    }
}