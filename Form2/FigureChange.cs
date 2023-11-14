using System;
using System.Drawing;
using System.Windows.Forms;

namespace paint
{
    static class FigureChange
    {
        public static MakeRectangle[] Change(Figure f, Form2 F)
        {
            int[] mas = f.ChangeFigure();
            MakeRectangle[] rec = new MakeRectangle[1];
            if (mas.Length == 16)
            {
                rec = new MakeRectangle[8];
                int j = 0;
                for (int i = 0; i < 8; i++)
                {
                    MakeRectangle r = new MakeRectangle(new Point(mas[j], mas[j + 1]), new Point(mas[j] + 6, mas[j + 1] + 6),
                                                        Color.Black, Color.LightGray, 0);
                    rec[i] = r;
                    r.Draw(F.get_g());
                    j += 2;
                }
            } else
            {
                rec = new MakeRectangle[2];
                int j = 0;
                for (int i = 0; i < 2; i++)
                {
                    MakeRectangle r = new MakeRectangle(new Point(mas[j], mas[j + 1]), new Point(mas[j] + 6, mas[j + 1] + 6),
                                                        Color.Black, Color.LightGray, 0);
                    rec[i] = r;
                    r.Draw(F.get_g());
                    j += 2;
                }
            }
            return rec;
        }

        public static void printRectanglies(MakeRectangle[] rec, Graphics g, bool clean)
        {
            foreach(MakeRectangle r in rec)
            {
                if (clean)
                {
                    r.Cbackground = Color.White;
                    r.color = Color.White;
                    r.point1 = new Point(r.point1.X - 1, r.point1.Y - 1);
                    r.point2 = new Point(r.point2.X + 1, r.point2.Y + 1);
                }
                else
                {
                    r.color = Color.Black;
                    r.Cbackground = Color.LightGray;
                    /*r.point1 = new Point(r.point1.X + 1, r.point1.Y + 1);
                    r.point2 = new Point(r.point2.X - 1, r.point2.Y - 1);*/
                }
                r.Draw(g);
                if (clean)
                {
                    r.point1 = new Point(r.point1.X + 1, r.point1.Y + 1);
                    r.point2 = new Point(r.point2.X - 1, r.point2.Y - 1);
                }
            }
        }

        public static void rectangleClick(Form2 F, int x1, int y1, int id)
        {
            if (Data.changeFigure.checkZone(F.get_pb().Location, F.get_pb().Width, F.get_pb().Height))
            {
                switch (id)
                {
                    case 0:
                        Data.changeFigure.Change(x1, y1, Data.changeFigure.point2.X, Data.changeFigure.point2.Y,
                                            Data.changeFigure.color, Data.changeFigure.Cbackground, Data.changeFigure.lineWidth,
                                            Data.changeFigure.text, Data.changeFigure.font);

                        break;
                    case 1:
                        Data.changeFigure.Change(Data.changeFigure.point1.X, Data.changeFigure.point1.Y, x1, y1,
                                            Data.changeFigure.color, Data.changeFigure.Cbackground, Data.changeFigure.lineWidth,
                                            Data.changeFigure.text, Data.changeFigure.font);
                        break;
                    case 2:
                        Data.changeFigure.Change(x1, Data.changeFigure.point1.Y, Data.changeFigure.point2.X, y1,
                                            Data.changeFigure.color, Data.changeFigure.Cbackground, Data.changeFigure.lineWidth,
                                            Data.changeFigure.text, Data.changeFigure.font);
                        break;
                    case 3:
                        Data.changeFigure.Change(Data.changeFigure.point1.X, y1, x1, Data.changeFigure.point2.Y,
                                            Data.changeFigure.color, Data.changeFigure.Cbackground, Data.changeFigure.lineWidth,
                                            Data.changeFigure.text, Data.changeFigure.font);
                        break;
                    case 4:
                        Data.changeFigure.Change(Data.changeFigure.point1.X, y1, Data.changeFigure.point2.X, Data.changeFigure.point2.Y,
                                            Data.changeFigure.color, Data.changeFigure.Cbackground, Data.changeFigure.lineWidth,
                                            Data.changeFigure.text, Data.changeFigure.font);
                        break;
                    case 5:
                        Data.changeFigure.Change(Data.changeFigure.point1.X, Data.changeFigure.point1.Y, Data.changeFigure.point2.X, y1,
                                            Data.changeFigure.color, Data.changeFigure.Cbackground, Data.changeFigure.lineWidth,
                                            Data.changeFigure.text, Data.changeFigure.font);
                        break;
                    case 6:
                        Data.changeFigure.Change(x1, Data.changeFigure.point1.Y, Data.changeFigure.point2.X, Data.changeFigure.point2.Y,
                                            Data.changeFigure.color, Data.changeFigure.Cbackground, Data.changeFigure.lineWidth,
                                            Data.changeFigure.text, Data.changeFigure.font);
                        break;
                    case 7:
                        Data.changeFigure.Change(Data.changeFigure.point1.X, Data.changeFigure.point1.Y, x1, Data.changeFigure.point2.Y,
                                            Data.changeFigure.color, Data.changeFigure.Cbackground, Data.changeFigure.lineWidth,
                                            Data.changeFigure.text, Data.changeFigure.font);
                        break;
                }
            }
        }
    }
}
