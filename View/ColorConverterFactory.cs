using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace View
{
    public class ColorConverterFactory
    {

        public static object handleColor(String species)
        {
            if (species.Equals("prey"))
            {
                return Brushes.Green;
            }
            else if (species.Equals("hunter"))
            {
                return Brushes.Firebrick;
            }
            else
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString("#AAB8D3");
                return brush;
            }
        }
    }
}
