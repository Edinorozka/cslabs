using System.Drawing;

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
            text,
            change,
        }

        public static Figures figures = Figures.rectangle;
        public static Figure figure;
        public static int lineWidth = 1, gridDistance = 10;
        public static Color color = Color.Black;
        public static Color background;
        public static Font font = System.Windows.Forms.Control.DefaultFont;
        public static bool snapToGrig = false;
    }
}
