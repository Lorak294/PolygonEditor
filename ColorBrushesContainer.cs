using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektNaGK
{
    internal static class ColorBrushesContainer
    {
        private static Brush[] _brushes = {
            Brushes.Blue,
            Brushes.Lime,
            Brushes.Orange,
            Brushes.ForestGreen,
            Brushes.Turquoise,
            Brushes.Magenta,
            Brushes.DodgerBlue,
        };
        private static int _index = 0;

        public static Brush GetBrush()
        {
            return _brushes[(++_index)%_brushes.Length];
        }
    }
}
