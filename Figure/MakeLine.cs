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
            foreach (PointF point in points)
            {
                if (point.X <= p.X || point.Y <= p.Y || point.X >= p.X + width || point.Y >= p.Y + height) return false;
            }
            return true;
        }

        public override void ChangeZero()
        {
            int ZeroX = 1000000000, ZeroY = 1000000000;
            foreach (PointF point in points)
            {
                ZeroX = (int)Math.Min(ZeroX, point.X);
                ZeroY = (int)Math.Min(ZeroY, point.Y);
            }
            
            for (int i = 0; i < points.Count; i++)
            {
                points[i] = new Point(points[i].X - ZeroX, points[i].Y - ZeroY);
            }
        }

        public override void GridChange()
        {
            Point startPoint = points[0];

            int i = 0, j = 0, z, x, y;
            while ((points[0].X + i) % Data.gridDistance != 0) i++;
            while ((points[0].X - j) % Data.gridDistance != 0) j++;
            if (i >= j) z = points[0].X - j;
            else z = points[0].X + i;

            i = 0; j = 0;
            while ((points[0].Y + i) % Data.gridDistance != 0) i++;
            while ((points[0].Y - j) % Data.gridDistance != 0) j++;
            points[0] = i >= j ? new Point(z, points[0].Y - j) : new Point(z, points[0].Y + i);

            x = startPoint.X - points[0].X;
            y = startPoint.Y - points[0].Y;

            for (int k = 1; k < points.Count; k++)
            {
                points[k] = new Point(points[k].X + x, points[k].Y + y);
            }
        }
    }
}
