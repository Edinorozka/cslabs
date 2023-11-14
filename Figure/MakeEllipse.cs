using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paint
{
    [Serializable()]
    internal class MakeEllipse : Figure
    {
        public MakeEllipse(Point point1, Point point2, Color color, Color Cbackground, int lineWidth) : base(point1, point2, color, Cbackground, lineWidth) { }

        public override void Draw(Graphics g)  // метод создания фигуры по полученным точкам
        {
            Point p1 = point1, p2 = point2;
            point1 = new Point(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y));
            point2 = new Point(Math.Max(p1.X, p2.X), Math.Max(p1.Y, p2.Y));

            Pen pen = new Pen(color);
            pen.Width = lineWidth;
            Rectangle rectangle = Rectangle.FromLTRB(point1.X, point1.Y, point2.X, point2.Y);
            if (Cbackground != Color.Empty)
            {
                SolidBrush solidBrush = new SolidBrush(Cbackground);
                g.FillEllipse(solidBrush, rectangle);
            }
            g.DrawEllipse(pen, rectangle);
        }

        public override void DrawDash(Graphics g) // метод создания пунктирной фигуры
        {
            Pen dashpen = new Pen(color);
            dashpen.Width = lineWidth;
            dashpen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Rectangle rectangle = Rectangle.FromLTRB(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y),
                                                     Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
            if (Cbackground != Color.Empty)
            {
                SolidBrush solidBrush = new SolidBrush(Cbackground);
                g.FillEllipse(solidBrush, rectangle);
            }
            g.DrawEllipse(dashpen, rectangle);
        }

        public override void Hide(Graphics g) // метод стирания фигуры
        {
            Pen pencl = new Pen(Color.White);
            pencl.Width = lineWidth + 1;
            Rectangle rectangle = Rectangle.FromLTRB(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y),
                                                     Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
            if (Cbackground != Color.Empty)
            {
                SolidBrush background = new SolidBrush(Color.White);
                g.FillEllipse(background, rectangle);
            }
            g.DrawEllipse(pencl, rectangle);
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
            if (Math.Min(point1.X, point2.X) >= p.X && Math.Min(point1.Y, point2.Y) >= p.Y &&
                Math.Max(point1.X, point2.X) <= p.X + width && Math.Max(point1.Y, point2.Y) <= p.Y + height) return true;
            else return false;
        }

        public override void ChangeZero()
        {
            point2.X = Math.Max(point1.X, point2.X) - Math.Min(point1.X, point2.X);
            point2.Y = Math.Max(point1.Y, point2.Y) - Math.Min(point1.Y, point2.Y);
            point1.X = 0;
            point1.Y = 0;
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

        public override int[] ChangeFigure()
        {
            int[] mas = {point1.X - 3, point1.Y - 3, point2.X - 3, point2.Y - 3, point1.X - 3, point2.Y - 3, point2.X - 3, point1.Y - 3,
                         point2.X - (point2.X - point1.X) / 2 - 3, point1.Y - 3, point2.X - (point2.X - point1.X) / 2 - 3, point2.Y - 3,
                         point1.X - 3, point1.Y + (point2.Y - point1.Y) / 2 - 3, point2.X - 3, point1.Y + (point2.Y - point1.Y) / 2 - 3};
            return mas;
        }

        public override void Change(int x1, int y1, int x2, int y2, Color color, Color Cbackground, int lineWidth, string text, Font font)
        {
            Point p1, p2;
            p1 = new Point(Math.Min(x1, x2), Math.Min(y1, y2));
            p2 = new Point(Math.Max(x1, x2), Math.Max(y1, y2));

            point1 = p1;
            point2 = p2;

            this.color = color;
            if (Cbackground != Color.Empty)
            {
                this.Cbackground = Cbackground;
            }
            this.lineWidth = lineWidth;
        }
    }
}
