using LibraryModel.Model;
using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp3.Converter
{
    [ValueConversion(typeof(Altezza), typeof(Int16))]
    public class AltezzaToInt : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int width = 0;
            if (value is Altezza altezza)
            {
                switch (altezza)
                {
                    case Altezza.Alto:
                        {
                            width = 75;
                            break;
                        }
                    case Altezza.Basso:
                        { 
                            width = 50;
                            break;
                        }
                }
            }
            return width;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
