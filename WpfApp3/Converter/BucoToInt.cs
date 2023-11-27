using System;
using LibraryModel.Model;
using System.Globalization;
using System.Windows.Data;
using WpfApp3.ViewModels;

namespace WpfApp3.Converter
{
    [ValueConversion(typeof(Buco), typeof(int))]
    public class BucoToInt : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Buco buco)
                switch (buco)
                {
                    case Buco.Buco:
                        {
                            return 25;
                        }
                    case Buco.NoBuco:
                        {
                            return 0;
                        }
                }
            return 0;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
