using System;
using System.Globalization;
using MvvmCross.Forms.Converters;

namespace XamarinPlanet
{
    public class InvertedVisibilityConverter : MvxFormsValueConverter<bool, bool>
    {
        protected override bool Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return !value;
        }
    }
}