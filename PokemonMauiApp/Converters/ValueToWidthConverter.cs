
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonMauiApp.Converters
{
    public class ValueToWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is double baseStats && parameter is double parentWidth)
            {
                // Perform your conversion logic here, e.g., scale the width based on baseStat
                return parentWidth * (baseStats / 100); // Adjust this logic as needed
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
