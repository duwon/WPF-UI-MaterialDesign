using Ui_Compact.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Ui_Compact.Views.Pages
{
    /// <summary>
    /// SerialPortPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SerialPortPage : INavigableView<SerialPortViewModel>
    {
        public SerialPortViewModel ViewModel { get; }

        public SerialPortPage(SerialPortViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}
