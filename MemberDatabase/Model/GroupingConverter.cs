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
        public object ConvertBool(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
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

        public object ConvertÍnt(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
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
}
