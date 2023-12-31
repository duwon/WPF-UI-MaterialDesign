﻿// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Collections.ObjectModel;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using CommunityToolkit.Mvvm.Messaging;
using Ui_Compact.Message;

namespace Ui_Compact.ViewModels.Windows
{
    public partial class MainWindowViewModel : ObservableObject
    {
        public MainWindowViewModel()
        {
            // Register a message in some module
            WeakReferenceMessenger.Default.Register<IsRightDrawerChangeMessage>(this, (r, m) =>
            {
                IsRightDrawer = m.Value;
            });
        }

        [ObservableProperty]
        private string _applicationTitle = "WPF Templete";

        [ObservableProperty]
        private ObservableCollection<object> _menuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Home",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
                TargetPageType = typeof(Views.Pages.DashboardPage)
            },
            new NavigationViewItem()
            {
                Content = "Data",
                Icon = new SymbolIcon { Symbol = SymbolRegular.DataHistogram24 },
                TargetPageType = typeof(Views.Pages.DataPage)
            },
            new NavigationViewItem()
            {
                Content = "Test",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Temperature24 },
                TargetPageType = typeof(Views.Pages.TestPage)
            },
            new NavigationViewItem()
            {
                Content = "SerialPort",
                Icon = new SymbolIcon { Symbol = SymbolRegular.SerialPort24 },
                TargetPageType = typeof(Views.Pages.SerialPortPage)
            },
            new NavigationViewItem()
            {
                Content = "DebugMessage",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Calculator24 },
                TargetPageType = typeof(Views.Pages.DebugMessagePage)
            }
        };

        [ObservableProperty]
        private ObservableCollection<object> _footerMenuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Settings",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                TargetPageType = typeof(Views.Pages.SettingsPage)
            }
        };

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems = new()
        {
            new MenuItem { Header = "Home", Tag = "tray_home" }
        };

        [ObservableProperty]
        private bool _isRightDrawer = false;
    }
}
