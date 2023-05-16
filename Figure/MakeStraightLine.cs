using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
