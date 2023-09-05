using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace paint
{
    public partial class Form2 : Form
    {
        public List<Figure> array = new List<Figure>();
        public List<Figure> changeArray = new List<Figure>();
        private string text = "";
        private List<Point> points;
        public bool saveFlag = false, savefilecreate = false, openfile = false, checkflag = false;
        private int x, y, xw = 0, yw = 0, x2, y2;
        Graphics g, g2;
        Bitmap bm;

        public Form2()
        {
            InitializeComponent();
            picture.Width = Width;
            picture.Height = Height;
        }

        public Graphics get_g()
        {
            return g;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            g = picture.CreateGraphics();
            picture.Width = Width;
            picture.Height = Height;
            AutoScrollMinSize = Size;
        }  

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saveFlag == true)
            {
                DialogResult dr = MessageBox.Show("Сохранить изменения?", "Закрытие файла", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    if (savefilecreate == true) ((Form1)ParentForm).save(this);
                    else ((Form1)ParentForm).saveAs(this);
                }
                else if (dr == DialogResult.Cancel) { e.Cancel = true; }
            }
            if (((Form1)ParentForm).MdiChildren.Length == 1 && !e.Cancel)
            {
                ((Form1)ParentForm).saveToolStripMenuItem.Enabled = false;
                ((Form1)ParentForm).saveAsToolStripMenuItem.Enabled = false;
                ((Form1)ParentForm).SaveAsButton.Enabled = false;
                ((Form1)ParentForm).SaveButton.Enabled = false;
                ((Form1)ParentForm).deleteToolStripMenuItem.Enabled = false;
                ((Form1)ParentForm).copyToolStripMenuItem.Enabled = false;
                ((Form1)ParentForm).pasteToolStripMenuItem.Enabled = false;
                ((Form1)ParentForm).cutToolStripMenuItem.Enabled = false;
                ((Form1)ParentForm).copyInMetafileToolStripMenuItem.Enabled = false;
            }
            saveFlag = false;
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            foreach (Figure f in array)
            {
                f.Draw(e.Graphics);
            }

            foreach (Figure f in changeArray)
            {
                f.Hide(e.Graphics);
                f.DrawDash(e.Graphics);
            }

            if (changeArray.Count == 0)
            {
                ((Form1)ParentForm).deleteToolStripMenuItem.Enabled = false;
                ((Form1)ParentForm).copyToolStripMenuItem.Enabled = false;
                ((Form1)ParentForm).pasteToolStripMenuItem.Enabled = false;
                ((Form1)ParentForm).cutToolStripMenuItem.Enabled = false;
                ((Form1)ParentForm).copyInMetafileToolStripMenuItem.Enabled = false;
            }
        }

            private void Form2_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    x = e.X;
                    y = e.Y;

                if (Data.figures == Data.Figures.change)
                {
                    foreach (Figure f in changeArray)
                    {
                        Rectangle r = Rectangle.FromLTRB(x, y, x, y);
                        if (f.Check(r) == true)
                        {
                            checkflag = true;
                        }
                    }
                }
                else checkflag = false;

                if (Data.figures != Data.Figures.change || !checkflag) changeArray.Clear();

                if (!checkflag)
                {
                    switch (Data.figures)
                    {
                        case Data.Figures.rectangle:
                            Data.figure = new MakeRectangle(new Point(x, y), new Point(x, y), Data.color, Data.background, Data.lineWidth);
                            break;
                        case Data.Figures.ellipse:
                            Data.figure = new MakeEllipse(new Point(x, y), new Point(x, y), Data.color, Data.background, Data.lineWidth);
                            break;
                        case Data.Figures.straight:
                            Data.figure = new MakeStraightLine(new Point(x, y), new Point(x, y), Data.color, Data.lineWidth);
                            break;
                        case Data.Figures.line:
                            points = new List<Point>();
                            Data.figure = new MakeLine(points, Data.color, Data.lineWidth);
                            points.Add(new Point(e.X, e.Y));
                            break;
                        case Data.Figures.text:
                            Data.figure = new MakeText(new Point(x, y), new Point(x, y), text, Data.color, Data.font);
                            break;
                        case Data.Figures.change:
                            Data.figure = new MakeRectangle(new Point(x, y), new Point(x, y), Color.Black, Color.Empty, 1);
                            break;
                    }
                } else
                {
                    x2 = x; y2 = y;
                }
                    textBox1.Visible = false;
                }
            }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bm = new Bitmap(Width, Height);
                g2 = Graphics.FromImage(bm);
                foreach (Figure f in array) f.Draw(g2);
                int x1 = e.X, y1 = e.Y;
                if (Data.figures == Data.Figures.line)
                {
                    points.Add(new Point(x1, y1));
                    Data.figure.points = points;
                    Data.figure.Draw(g2);
                }
                else if (Data.figures == Data.Figures.change && checkflag) {
                    int w = x1 - x2, h = y1 - y2;
                    foreach (Figure f in changeArray)
                    {
                        if (f.checkZone(picture.Location, picture.Width, picture.Height))
                        {
                            f.Hide(g2);
                            f.Change(w, h);
                            f.DrawDash(g2);
                        }
                        else
                        {
                            f.Hide(g2);
                            f.Change(-w, -h);
                            f.DrawDash(g2);
                        }
                    }
                    x2 = x1;
                    y2 = y1;
                } else
                {
                    if (xw != 0 && yw != 0)
                    {
                        Data.figure.point2 = new Point(xw, yw);
                        Data.figure.Hide(g2);
                    }
                    Data.figure.point2 = new Point(x1, y1);
                    Data.figure.DrawDash(g2);
                }
                g.DrawImage(bm, 0, 0);
                GC.Collect();
                xw = x1;
                yw = y1;
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                {
                int xf = e.X, yf = e.Y;
                if (Data.figure.checkZone(picture.Location, picture.Width, picture.Height))
                {
                    if (Data.figures == Data.Figures.line)
                    {
                        points.Add(new Point(xf, yf));
                        Data.figure.points = points;
                        Data.figure.Draw(g2);
                        array.Add(Data.figure);
                        g.DrawImage(bm, 0, 0);
                    }
                    else if (Data.figures == Data.Figures.text)
                    {
                        textBox1.Clear();
                        textBox1.Location = new Point(Math.Min(x, xf), Math.Min(y, yf));
                        textBox1.Size = new Size(Math.Max(x, xf) - Math.Min(x, xf), Math.Max(y, yf) - Math.Min(y, yf));
                        textBox1.Font = Data.font;
                        textBox1.Visible = true;
                        textBox1.Focus();
                    }
                    else if (Data.figures == Data.Figures.change)
                    {
                        Rectangle changeZone = new Rectangle();
                        if (!checkflag)
                        {
                            changeZone = Rectangle.FromLTRB(Math.Min(x, xf), Math.Min(y, yf),
                                                            Math.Max(x, xf), Math.Max(y, yf));
                        }
                        if (changeZone.Width < 10 && changeZone.Height < 10)
                        {
                            foreach (Figure f in array)
                            {
                                if (f.Check(changeZone) == true) changeArray = new List<Figure>{ f };
                            }
                        }
                        else
                        {
                            foreach (Figure f in array) if (f.Check(changeZone) == true) changeArray.Add(f);
                        }
                    }
                    else
                    {
                        Data.figure.Draw(g);
                        array.Add(Data.figure);
                        g.DrawImage(bm, 0, 0);
                    }
                    saveFlag = true;
                    checkflag = false;
                }
                xw = 0; yw = 0;
                if (changeArray.Count != 0)
                {
                    ((Form1)ParentForm).deleteToolStripMenuItem.Enabled = true;
                    ((Form1)ParentForm).copyToolStripMenuItem.Enabled = true;
                    ((Form1)ParentForm).pasteToolStripMenuItem.Enabled = true;
                    ((Form1)ParentForm).cutToolStripMenuItem.Enabled = true;
                    ((Form1)ParentForm).copyInMetafileToolStripMenuItem.Enabled = true;
                }
                picture.Invalidate();
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Data.figure.text = textBox1.Text;
                textBox1.Visible = false;
                Data.figure.Draw(g);
                array.Add(Data.figure);
                g.DrawImage(bm, 0, 0);
            }
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    changeArray.Clear();
                    break;
            }
            picture.Invalidate();
        }
    }
}
