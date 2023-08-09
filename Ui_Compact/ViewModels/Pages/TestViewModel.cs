using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Ui_Compact.Models;
using Ui_Compact.Services;
using Ui_Compact.ViewModels.Windows;
using Wpf.Ui.Controls;

namespace Ui_Compact.ViewModels.Pages
{
    public partial class TestViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
       

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        public void OnNavigatedFrom() { }

        private void InitializeViewModel()
        {
            _isInitialized = true;
        }

        private readonly IDebugMessageViewModel DebugMessageViewModel;

        public TestViewModel(IDebugMessageViewModel debugMessageViewModel)
        {
            DebugMessageViewModel = debugMessageViewModel;
        }

        private void PrintDebugMsg(string message)
        {
            DebugMessageViewModel?.PrintDebugMsg(new Models.DebugMessage("TEST", message));
        }


        [ObservableProperty]
        private string _pageTitle = "TestPage";

        [ObservableProperty]
        private string _debugMessage;

        [RelayCommand]
        private void OnDebugMessage()
        {
            string msg = "TEST1 ";
            DebugMessage += msg;
            PrintDebugMsg(msg);
        }


    }
}

