using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace NostrumWPFUI.Converters
{
    public class DataToRowBackgroundColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double amount = (double) values[0];
            double balance = (double)values[1];
            

            if (amount.Equals(balance))                
                return new SolidColorBrush(Colors.Red) { Opacity = 0.7 };                
            else if(balance == 0 || balance.Equals(0))
                return new SolidColorBrush(Colors.Green) { Opacity = 1 };
            else if(balance > 0 && balance <amount )
                return new SolidColorBrush(Colors.Yellow) { Opacity = 0.7 };
            else
                return new SolidColorBrush(Colors.BurlyWood) { Opacity = 0.7 };


            //    if (values[0] == null)
            //    return DependencyProperty.UnsetValue;
            //if (values[0] )
            //    return new SolidColorBrush(Colors.Green) { Opacity = 0.7 };
            //return DependencyProperty.UnsetValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
