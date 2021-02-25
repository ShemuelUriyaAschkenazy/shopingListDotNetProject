using BE;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PL.converters
{
    public class ValuesToBuyingConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0]!=null && values[1] != null && values[2]!=null&&values[3].ToString()!=""&&values[4].ToString()!=""&&values[5]!=null)
            {
                return new Buying(int.Parse(values[1].ToString()),int.Parse(values[0].ToString()), int.Parse(values[3].ToString()), int.Parse(values[4].ToString()), int.Parse(values[2].ToString()), DateTime.Parse(values[5].ToString())); 
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
