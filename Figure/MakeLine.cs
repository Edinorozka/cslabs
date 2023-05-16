using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }

        public override void Hide(Graphics g) // метод стирания фигуры
        {

        }
    }
}
