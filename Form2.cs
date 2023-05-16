using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paint
{
    public partial class Form2 : Form
    {
        public List<Figure> array = new List<Figure>();
        private MakeRectangle workfield;
        private string text = "";
        private List<Point> points;
        public bool saveFlag = false, savefilecreate = false, openfile = false;
        private int x, y, xw = 0, yw = 0;
        Graphics g, g2;
        Bitmap bm;

        public Form2()
        {
            InitializeComponent();
            picture.Width = Width;
            picture.Height = Height;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            g = picture.CreateGraphics();
            picture.Width = Width;
            picture.Height = Height;
            if (openfile)
            {
                workfield = new MakeRectangle(array[0].point1, array[0].point2, array[0].color, array[0].Cbackground, 0);
                Width = array[0].point2.X;
                Height = array[0].point2.Y;
            }
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
            }
            saveFlag = false;
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            if (array.Count == 0)
            {
                Point pointf1 = new Point(0, 0),
                      pointf2 = new Point(Width, Height);
                workfield = new MakeRectangle(pointf1, pointf2, Color.White, new Color(), 0);
                array.Add(workfield);
            }

            foreach (Figure f in array)
            {
                f.Draw(e.Graphics);
            }
            }

            private void Form2_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    x = e.X;
                    y = e.Y;
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
                if (workfield.point1.X < xf && workfield.point1.Y < yf &&
                        workfield.point2.X > xf && workfield.point2.Y > yf)
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
                    else
                    {
                        Data.figure.Draw(g);
                        array.Add(Data.figure);
                        g.DrawImage(bm, 0, 0);
                    }
                    saveFlag = true;
                    
                }
                xw = 0; yw = 0;
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
                picture.Invalidate();
            }
        }
    }
}
