using System.Collections.ObjectModel;
using System.IO.Ports;
using Ui_Compact.Services;
using Wpf.Ui.Controls;

namespace Ui_Compact.ViewModels.Pages
{
    public partial class SerialPortViewModel : ObservableObject, INavigationAware
    {
        public delegate void ReceivedHandler();
        public event ReceivedHandler RceivedEvent;

        private bool _isInitialized = false;
        private System.Collections.Concurrent.ConcurrentQueue<byte> RxBuffer = new System.Collections.Concurrent.ConcurrentQueue<byte>();

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
            _serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.DataReceivedEvent);
        }

        private SerialPort? _serialPort = new();

        /// <summary>
        /// Serial 데이터 수신 인터럽트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataReceivedEvent(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                int iRecivedSize = _serialPort.BytesToRead;

                if (iRecivedSize != 0) // 수신 데이터가 있으면
                {
                    byte[] buff = new byte[iRecivedSize];

                    _serialPort.Read(buff, 0, iRecivedSize);

                    RxByteHexStringBuffer += BitConverter.ToString(buff).Replace("-", " ") + " ";

                    for (int i = 0; i < buff.Length; i++)
                    {
                        RxBuffer.Enqueue(buff[i]);
                    }

                    if (RceivedEvent != null)
                    {
                        RceivedEvent();
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        [ObservableProperty]
        private ObservableCollection<string>? _comPortName;

        [ObservableProperty]
        private string? _selectedComPort;

        [ObservableProperty]
        private int _baudRate = 115200;

        [ObservableProperty]
        private bool _isOpen;

        [ObservableProperty]
        private string _txStringBuffer;

        [ObservableProperty]
        private byte[] _txByteBuffer;

        [ObservableProperty]
        private string _rxByteHexStringBuffer;

        [RelayCommand]
        private void OnComPortConnect()
        {
            if(SelectedComPort != null )
            {
                if (!_serialPort.IsOpen)
                {
                    _serialPort.BaudRate = BaudRate;
                    _serialPort.PortName = SelectedComPort;
                    _serialPort.Open();
                    IsOpen = true;
                }
                else
                {
                    _serialPort.Close();
                    IsOpen = false;
                }
            }
        }

        [RelayCommand]
        private void OnGetPortNames()
        {
            ComPortName = new ObservableCollection<string>(SerialPort.GetPortNames());
        }

        [RelayCommand]
        private void OnSendData()
        {
            if(IsOpen && TxStringBuffer != null)
            {
                _serialPort.Write(TxStringBuffer);
            }
        }
    }
}

