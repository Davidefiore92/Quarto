using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using LibraryModel.Model;

namespace WpfApp3.Converter
{
    [ValueConversion(typeof(Colore), typeof(Brushes))]
    public class ColorToBrush : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object color = Brushes.Transparent;

            if (value is Colore colore)
            {
                switch (colore)
                {
                    case Colore.Bianco:
                        {
                            color = Brushes.SandyBrown;
                            break;
                        }
                    case Colore.Nero:
                        {
                            color = Brushes.SaddleBrown;
                            break;
                        }
                    default:
                        {
                            color = Brushes.Purple; //un colore a caso per capirmi
                            break;
                        }
                }
            }

            return color;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
