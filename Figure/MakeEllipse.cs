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
            Pen pen = new Pen(color);
            pen.Width = lineWidth;
            Rectangle rectangle = Rectangle.FromLTRB(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y),
                                                     Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
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
    }
}
