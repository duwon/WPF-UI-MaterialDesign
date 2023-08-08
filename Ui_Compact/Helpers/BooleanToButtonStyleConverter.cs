// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Globalization;
using System.Windows;
using System.Windows.Data;
using MaterialDesignThemes;

namespace Ui_Compact.Helpers
{
    internal class BooleanToButtonStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            Style style = new();

            if(value is not Boolean IsOn)
            {
                throw new ArgumentException("Exception BooleanToButtonStyleConverter");
            }

            if(IsOn)
            {
                style = (Style)App.Current.FindResource("MaterialDesignRaisedLightButton");
            }
            else
            {
                style = (Style)App.Current.FindResource("MaterialDesignPaperLightButton");
            }

            return style;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // This method is not used for button style static resource converters.
            return null;
        }
    }
}
