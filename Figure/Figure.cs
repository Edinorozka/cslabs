using System;
using System.Collections.Generic;
using System.Drawing;

namespace paint
{
    [Serializable()]
    public abstract class Figure
    {
        public Point point1, point2;
        public List<Point> points;
        public string text;
        public Font font;
        public Color color;
        public Color Cbackground;
        public int lineWidth;

        public Figure(Point point1, Point point2, Color color, Color Cbackground, int lineWidth)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.color = color;
            this.Cbackground = Cbackground;
            this.lineWidth = lineWidth;
        }

        public Figure(Point point1, Point point2, Color color, int lineWidth)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.color = color;
            this.lineWidth = lineWidth;
        }

        public Figure(List<Point> points, Color color, int lineWidth)
        {
            this.points = points;
            this.color = color;
            this.lineWidth = lineWidth;
        }

        public Figure(Point point1, Point point2, string text, Color color, Font font)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.text = text;
            this.color = color;
            this.font = font;
        }

        public abstract void Draw(Graphics g);
        public abstract void DrawDash(Graphics g);
        public abstract void Hide(Graphics g);
        public abstract bool Check(Rectangle r);
        public abstract void Change(int width, int height);
        public abstract bool checkZone(Point p,int width, int height);
        public abstract void ChangeZero();
        public abstract void GridChange();
        public abstract int[] ChangeFigure();
        public abstract void Change(int x1, int y1, int x2, int y2, Color color, Color Cbackground, int lineWidth, string text, Font font);
    }
}
