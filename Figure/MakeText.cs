using System;
using System.Drawing;
using static paint.Form2;

namespace paint
{
    [Serializable()]
    internal class MakeText : Figure
    {
        public MakeText(Point point1, Point point2, String text, Color color, Font font) : base(point1, point2, text, color, font) { }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(color);
            Rectangle rectangle = Rectangle.FromLTRB(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y),
                                                     Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
            g.DrawRectangle(pen, rectangle);
            g.DrawString(text, font, new SolidBrush(color), rectangle);
        }

        public override void DrawDash(Graphics g)
        {
            Pen dashpen = new Pen(Color.Black, 1);
            dashpen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Rectangle rectangle = Rectangle.FromLTRB(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y),
                                                     Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
            g.DrawRectangle(dashpen, rectangle);
        }

        public override void Hide(Graphics g)
        {
            Pen pencl = new Pen(Color.White);
            pencl.Width = lineWidth;
            Rectangle rectangle = Rectangle.FromLTRB(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y),
                                                     Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
            g.DrawRectangle(pencl, rectangle);
        }
    }
}
