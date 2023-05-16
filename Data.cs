using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paint
{
    static class Data
    {
        public enum Figures
        {
            rectangle,
            ellipse,
            line,
            straight,
            text
        }

        public static Figures figures = Figures.rectangle;
        public static Figure figure;
        public static int lineWidth = 1;
        public static Color color = Color.Black;
        public static Color background;
        public static Font font = System.Windows.Forms.Control.DefaultFont;
    }
}
