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
            int amount = (int) values[0];
            int balance = (int)values[1];
            
            if (balance == 0)
                return new SolidColorBrush(Colors.LightGreen) { Opacity = 1 };
            else if (amount == balance)                
                return new SolidColorBrush(Colors.LightPink) { Opacity = 1 };                
            else if(balance > 0 && balance < amount )
                return new SolidColorBrush(Colors.PaleGoldenrod) { Opacity = 1 };
            else
                return new SolidColorBrush(Colors.BurlyWood) { Opacity = 0.7 };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
//https://stackoverflow.com/questions/2109756/how-do-i-get-the-color-from-a-hexadecimal-color-code-using-net