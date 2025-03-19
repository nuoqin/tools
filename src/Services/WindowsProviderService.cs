// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace nuoqin.src.Services
{

    public class WindowsProviderService
    {

        private readonly IServiceProvider serviceProvider;

        public WindowsProviderService(IServiceProvider iServiceProvider)
        {
            serviceProvider = iServiceProvider;
        }

        public void Show<T>() where T : class
        {
            if (!typeof(Window).IsAssignableFrom(typeof(T)))
            {
                throw new InvalidOperationException($"The window class should be derived from {typeof(Window)}.");
            }
            Window windowInstance = serviceProvider.GetService<T>() as Window
                ?? throw new InvalidOperationException("Window is not registered as service.");
            windowInstance.Owner = Application.Current.MainWindow;
            windowInstance.Show();
        }
    }
}
