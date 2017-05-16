using Cells;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
namespace View
{
    public class BuildConverter : IValueConverter
    {
        public Cell<string> BackGroundColor { get; set; }


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(BackGroundColor == null)
            {
                return Brushes.HotPink;
            }
            else
            {
                return Brushes.Khaki;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
