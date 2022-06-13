using System;
using System.Globalization;
using MvvmCross.Forms.Converters;

namespace XamarinPlanet
{
    public class DateTimeToStringConverter : MvxFormsValueConverter<DateTime, string>
    {
        private static readonly DateTimeFormatInfo _formatProvider = new DateTimeFormatInfo
        {
            AMDesignator = "am",
            PMDesignator = "pm"
        };

        protected override string Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is string format)
            {
                return value.ToString(format);
            }
            return FullDate(value);
        }

        public static string FullDate(DateTime date)
        {
            return $"{date.Day}{GetDaySuffix(date.Day)} {date.ToString("MMMM yyyy, h:mmtt", _formatProvider)}";
        }
        private static string GetDaySuffix(int day)
        {
            if (day >= 11 && day <= 20)
            {
                return "th";
            }

            return (day % 10) switch
            {
                1 => "st",
                2 => "nd",
                3 => "rd",
                _ => "th"
            };
        }
    }
}
