using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using WpfApp3.Library;

namespace WpfApp3.Converter
{
    [ValueConversion(typeof(Esito), typeof(Visibility))]
    public class EsitoToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object visibilità = Visibility.Collapsed;

            if (value is Esito esito)
            {
                switch (esito)
                {
                    case Esito.Win:
                        {
                            visibilità = Visibility.Visible;
                            break;
                        }
                    default:
                        {
                            visibilità = Visibility.Hidden;
                            break;
                        }
                }
            }
            return visibilità;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
