using LibraryModel.Model;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using WpfApp3.ViewModels;

namespace WpfApp3.Converter
{
    [ValueConversion(typeof(Forma), typeof(CornerRadius))]
    public class FormaToCornerRadius : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CornerRadius cornerRadius = new CornerRadius(0);
            Forma forma=Forma.Tondo;

            if (value is VM_Pedina pedina)
                forma = pedina.Forma;
            else if (value is VM_Casella casella)
            {
                if (casella.Pedina == null)
                    return null;
                forma = casella.Pedina.Forma;
            }            

            switch (forma)
                {
                    case Forma.Tondo:
                        return new CornerRadius(50);
                    case Forma.Quadrato:
                        return new CornerRadius(5);
                }
            return cornerRadius;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
