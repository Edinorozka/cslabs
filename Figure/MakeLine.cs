using System;
using System.Collections.Generic;
using System.Drawing;

namespace paint
{
    [Serializable()]
    internal class MakeLine : Figure
    {
        public MakeLine(List<Point> points, Color color, int lineWidth) : base(points, color, lineWidth) { }

        public override void Draw(Graphics g)  // метод создания фигуры по полученным точкам
        {
            Pen pen = new Pen(color);
            pen.Width = lineWidth;
            Point[] p = new Point[points.Count];
            for (int i = 0; i < p.Length; i++) p[i] = points[i];
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            g.DrawCurve(pen, p);

        }

        public override void DrawDash(Graphics g) // метод создания пунктирной фигуры
        {
            Pen pen = new Pen(color);
            pen.Width = lineWidth;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Point[] p = new Point[points.Count];
            for (int i = 0; i < p.Length; i++) p[i] = points[i];
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            g.DrawCurve(pen, p);
        }

        public override void Hide(Graphics g) // метод стирания фигуры
        {
            Pen pen = new Pen(Color.White);
            pen.Width = lineWidth + 1;
            Point[] p = new Point[points.Count];
            for (int i = 0; i < p.Length; i++) p[i] = points[i];
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            g.DrawCurve(pen, p);
        }

        public override bool Check(Rectangle r)
        {
            bool checkIntersection = false;
            for (int i = 0; i < points.Count - 1; i++)
            {
                Rectangle rectangle = Rectangle.FromLTRB(Math.Min(points[i].X, points[i + 1].X), Math.Min(points[i].Y, points[i + 1].Y),
                                                         Math.Max(points[i].X, points[i + 1].X), Math.Max(points[i].Y, points[i + 1].Y));
                if (r.IntersectsWith(rectangle)) checkIntersection = true;
            }
            if (checkIntersection) return true;
            return false;
        }

        public override void Change(int w, int h)
        {
            for (int i = 0; i <= points.Count - 1; i++) points[i] = new Point(points[i].X + w, points[i].Y + h);
        }

        public override bool checkZone(Point p, int width, int height)
        {
            foreach (Point point in points)
            {
                if (point.X < p.X || point.Y < p.Y || point.X > p.X + width || point.Y > p.Y + height) return false;
            }
            return true;
        }
    }
}
