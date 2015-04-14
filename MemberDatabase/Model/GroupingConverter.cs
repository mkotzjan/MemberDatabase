using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MemberDatabase.Model
{
    [ValueConversion(typeof(Boolean), typeof(Int32))]
    class GroupingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string para = (string)parameter;
            if (para == "active")
            {
                bool active = (bool)value;
                if (active)
                {
                    return "Aktiv";
                }
                else
                {
                    return "Inaktiv";
                }
            }
            else
            {
                int group = (int)value;
                if (group == 0)
                {
                    return "Erwachsene";
                }
                else
                {
                    return "Kinder";
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return "test";
        }
    }
}
