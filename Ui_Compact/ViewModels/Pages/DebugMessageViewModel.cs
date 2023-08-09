using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ui_Compact.Models;
using Wpf.Ui.Controls;

namespace Ui_Compact.ViewModels.Pages
{
    public partial class DebugMessageViewModel : ObservableObject, INavigationAware, IDebugMessageViewModel
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

        public void PrintDebugMsg(DebugMessage message)
        {
            if (message.IsVisible)
            {
                DebugMessage += $"[{message.Name}] {message.Message} \r\n";
            }
        }


        private string? _debugMessage;

        public string? DebugMessage
        {
            get => _debugMessage; 
            set => SetProperty(ref _debugMessage, value); 
        }

        [RelayCommand]
        private void OnDebugMessage()
        {
            DebugMessage += " Z";
        }
    }

    public interface IDebugMessageViewModel
    {
        void PrintDebugMsg(DebugMessage message);
    }
}
