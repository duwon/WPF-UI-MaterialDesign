using System.Text;
using Ui_Compact.Models;
using Wpf.Ui.Controls;

namespace Ui_Compact.ViewModels.Pages
{
    public partial class SerialPortViewModel : ObservableObject, INavigationAware
    {
        public delegate void ReceivedHandler();
        public event ReceivedHandler RceivedEvent;

        private bool _isInitialized = false;
        private System.Collections.Concurrent.ConcurrentQueue<byte> RxBuffer = new();

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        public void OnNavigatedFrom() { }

        private void InitializeViewModel()
        {
            _isInitialized = true;
            OnGetPortNames();
            Serial.RceivedEvent += new SerialConfig.ReceivedHandler(DataReceivedEvent);
        }

        private readonly IDebugMessageViewModel DebugMessageViewModel;

        public SerialPortViewModel(IDebugMessageViewModel debugMessageViewModel)
        {
            DebugMessageViewModel = debugMessageViewModel;
        }

        private void PrintDebugMsg(string message)
        {
            DebugMessageViewModel?.PrintDebugMsg(new Models.DebugMessage("SERIAL", message));
        }


        private void DataReceivedEvent()
        {
            SerialRxHexString = BitConverter.ToString(Serial.GetData()).Replace("-", " ");
            PrintDebugMsg($"[RX] {SerialRxHexString}");
        }

        [ObservableProperty]
        private SerialConfig _serial = new();

        [ObservableProperty]
        private string _serialTxString;
        [ObservableProperty]
        private string _serialRxHexString;

        [RelayCommand]
        private void OnSerialConnect()
        {
            if (Serial.IsOpen)
            {
                Serial.Close();
            }
            else
            {
                Serial.Open();
            }
        }

        [RelayCommand]
        private void OnGetPortNames()
        {
            Serial.GetPortNames();
        }

        [RelayCommand]
        private void OnSendData()
        {
            if (Serial.Send(SerialTxString))
                PrintDebugMsg($"[TX] {BitConverter.ToString(Encoding.UTF8.GetBytes(SerialTxString)).Replace("-", " ")}");
        }
    }
}

