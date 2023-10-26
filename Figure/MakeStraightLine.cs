using System;
using System.Drawing;

namespace paint
{
    [Serializable()]
    internal class MakeStraightLine : Figure
    {
        public MakeStraightLine(Point point1, Point point2, Color color, int lineWidth) : base(point1, point2, color, lineWidth) { }

        public override void Draw(Graphics g)  // метод создания фигуры по полученным точкам
        {
            Pen pen = new Pen(color);
            pen.Width = lineWidth;
            g.DrawLine(pen, point1, point2);
        }

        public override void DrawDash(Graphics g) // метод создания пунктирной фигуры
        {
            Pen dashpen = new Pen(color);
            dashpen.Width = lineWidth;
            dashpen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            g.DrawLine(dashpen, point1, point2);
        }

        public override void Hide(Graphics g) // метод стирания фигуры
        {
            Pen pencl = new Pen(Color.White);
            pencl.Width = lineWidth + 1;
            g.DrawLine(pencl, point1, point2);
        }

        public override bool Check(Rectangle r)
        {
            Rectangle rectangle = Rectangle.FromLTRB(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y),
                                                     Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
            if (r.IntersectsWith(rectangle)) return true;
            return false;
        }

        public override void Change(int w, int h)
        {
            point1.X += w;
            point1.Y += h;
            point2.X += w;
            point2.Y += h;
        }

        public override bool checkZone(Point p, int width, int height)
        {
            if (Math.Min(point1.X, point2.X) > p.X && Math.Min(point1.Y, point2.Y) > p.Y &&
                Math.Max(point1.X, point2.X) < p.X + width && Math.Max(point1.Y, point2.Y) < p.Y + height) return true;
            else return false;
        }

        public override void ChangeZero()
        {
            int zeroX = Math.Min(point1.X, point2.X) - 1, zeroY = Math.Min(point1.Y, point2.Y) - 1;
            point2.X -= zeroX;
            point2.Y -= zeroY;
            point1.X -= zeroX;
            point1.Y -= zeroY;
        }

        public override void GridChange()
        {
            int i = 0, j = 0;
            Point p1 = new Point(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y)),
                  p2 = new Point(Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
            while ((p1.X + i) % Data.gridDistance != 0) i++;
            while ((p1.X - j) % Data.gridDistance != 0) j++;
            if (i >= j) point1.X -= j;
            else point1.X += i;

            i = 0; j = 0;
            while ((p1.Y + i) % Data.gridDistance != 0) i++;
            while ((p1.Y - j) % Data.gridDistance != 0) j++;
            if (i >= j) point1.Y -= j;
            else point1.Y += i;

            i = 0; j = 0;
            while ((p2.X + i) % Data.gridDistance != 0) i++;
            while ((p2.X - j) % Data.gridDistance != 0) j++;
            if (i >= j) point2.X -= j;
            else point2.X += i;

            i = 0; j = 0;
            while ((p2.Y + i) % Data.gridDistance != 0) i++;
            while ((p2.Y - j) % Data.gridDistance != 0) j++;
            if (i >= j) point2.Y -= j;
            else point2.Y += i;
        }
    }
}
