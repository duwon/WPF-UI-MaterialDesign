﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ui_Compact.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Ui_Compact.Views.Pages
{
    /// <summary>
    /// DebugMessagePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DebugMessagePage : INavigableView<IDebugMessageViewModel>
    {
        public IDebugMessageViewModel ViewModel { get; }

        public DebugMessagePage(IDebugMessageViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}
