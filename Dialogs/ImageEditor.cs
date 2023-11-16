using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace paint
{
    public partial class ImageEditor : Form
    {
        private Form2 F;
        private List<Figure> array = new List<Figure>();
        private ListView.SelectedListViewItemCollection coll;
        private int id = -1;
        private ComboBox c1;
        private TextBox t1, t2, t3, t4, t5, t6, t7;

        private void MakeTable()
        {
            int i = 0;
            ListViewItem[] mas = new ListViewItem[array.Count];
            foreach (Figure f in array)
            {
                ListViewItem lvi = new ListViewItem(f.ToString().Remove(0, 10));
                lvi.SubItems.Add(f.point1.ToString());
                lvi.SubItems.Add(f.point2.ToString());
                if (f.points != null) lvi.SubItems.Add(f.points.Count.ToString());
                else lvi.SubItems.Add("0");
                lvi.SubItems.Add(f.color.R.ToString() + f.color.G.ToString() + f.color.B.ToString());
                if (f.Cbackground.IsEmpty) lvi.SubItems.Add("not");
                else lvi.SubItems.Add(f.Cbackground.R.ToString() + f.Cbackground.G.ToString() + f.Cbackground.B.ToString());
                lvi.SubItems.Add(f.lineWidth.ToString());
                if (f.text != null)
                {
                    lvi.SubItems.Add(f.text.ToString());
                    lvi.SubItems.Add(f.font.ToString());
                }
                else
                {
                    lvi.SubItems.Add("");
                    lvi.SubItems.Add("");
                }
                lvi.Tag = i;
                
                mas[i] = lvi;
                i++;
            }
            listView1.Items.AddRange(mas);
        }

        private void SettingsGenerate()
        {
            flowLayoutPanel1.Controls.Clear();
            ListViewItem item = coll[0];
            id = (int)item.Tag;
            Label l1 = new Label();
            l1.Text = "Name";
            c1 = new ComboBox();
            string[] s = new string[5];
            s[0] = "Rectangle";
            s[1] = "Ellipse";
            s[2] = "Line";
            s[3] = "StraightLine";
            s[4] = "Text";
            c1.DropDownStyle = ComboBoxStyle.DropDownList;
            c1.Items.AddRange(s);
            c1.Text = item.SubItems[0].Text;
            c1.SelectedIndexChanged += SelectedIndexChanged;
            Label l2 = new Label();
            l2.Text = "Point1.X";
            t1 = new TextBox();
            t1.Text = array[id].point1.X.ToString();
            t1.TextChanged += TextsChanged;
            Label l3 = new Label();
            l3.Text = "Point1.Y";
            t2 = new TextBox();
            t2.Text = array[id].point1.Y.ToString();
            t2.TextChanged += TextsChanged;
            Label l4 = new Label();
            l4.Text = "Point2.X";
            t3 = new TextBox();
            t3.Text = array[id].point2.X.ToString();
            t3.TextChanged += TextsChanged;
            Label l5 = new Label();
            l5.Text = "Point2.Y";
            t4 = new TextBox();
            t4.Text = array[id].point2.Y.ToString();
            t4.TextChanged += TextsChanged;

            flowLayoutPanel1.Controls.Add(l1);
            flowLayoutPanel1.Controls.Add(c1);
            flowLayoutPanel1.Controls.Add(l2);
            flowLayoutPanel1.Controls.Add(t1);
            flowLayoutPanel1.Controls.Add(l3);
            flowLayoutPanel1.Controls.Add(t2);
            flowLayoutPanel1.Controls.Add(l4);
            flowLayoutPanel1.Controls.Add(t3);
            flowLayoutPanel1.Controls.Add(l5);
            flowLayoutPanel1.Controls.Add(t4);

            if (item.SubItems[3].Text != "0")
            {
                Label l7 = new Label();
                l7.Text = "Points";
                t7 = new TextBox();
                string mas = "";
                for(int i = 0; i < array[id].points.Count; i++)
                {
                    mas += array[id].points[i].ToString() + " ";
                }
                t7.Text = mas;
                t7.TextChanged += TextsChanged;

                flowLayoutPanel1.Controls.Add(l7);
                flowLayoutPanel1.Controls.Add(t7);
            }

            Label l8 = new Label();
            l8.Text = "Color";
            Button b2 = new Button();
            b2.BackColor = array[id].color;
            b2.Click += Color_Click;

            flowLayoutPanel1.Controls.Add(l8);
            flowLayoutPanel1.Controls.Add(b2);

            if (item.SubItems[0].Text == "Rectangle" || item.SubItems[0].Text == "Ellipse")
            {
                Label l9 = new Label();
                l9.Text = "Background";
                Button b3 = new Button();
                if (array[id].Cbackground.IsEmpty) b3.BackColor = System.Drawing.Color.White;
                else b3.BackColor = array[id].Cbackground;
                b3.Click += BackgroundColor_Click;

                flowLayoutPanel1.Controls.Add(l9);
                flowLayoutPanel1.Controls.Add(b3);
            }

            Label l10 = new Label();
            l10.Text = "Line Width";
            t5 = new TextBox();
            t5.Text = array[id].lineWidth.ToString();
            t5.TextChanged += TextsChanged;

            flowLayoutPanel1.Controls.Add(l10);
            flowLayoutPanel1.Controls.Add(t5);

            if (array[id].ToString() == "paint.MakeText")
            {
                Label l11 = new Label();
                l11.Text = "Text";
                t6 = new TextBox();
                t6.Text = array[id].text;
                t6.TextChanged += TextsChanged;
                Label l12 = new Label();
                l12.Text = "Font";
                Button b5 = new Button();
                b5.Text = array[id].font.ToString();
                b5.Click += Font_Click;

                flowLayoutPanel1.Controls.Add(l11);
                flowLayoutPanel1.Controls.Add(t6);
                flowLayoutPanel1.Controls.Add(l12);
                flowLayoutPanel1.Controls.Add(b5);
            }
        }

        public ImageEditor(Form2 F)
        {
            InitializeComponent();
            this.F = F;

            foreach(Figure f in F.array) array.Add(f);
            
            MakeTable();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            coll = listView1.SelectedItems;
            if (coll.Count > 0) SettingsGenerate();
        }

        private void Color_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            if (id != -1)
            {
                array[id].color = colorDialog1.Color;
                SettingsGenerate();
            }
        }

        private void BackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            if (id != -1)
            {
                array[id].Cbackground = colorDialog1.Color;
                SettingsGenerate();
            }
        }

        private void Up_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                if (id != 0)
                {
                    Figure f1 = array[id - 1];
                    array[id - 1] = array[id];
                    array[id] = f1;
                    listView1.Items.Clear();
                    MakeTable();
                    flowLayoutPanel1.Controls.Clear();
                }
            }
        }

        private void Down_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                if (id != array.Count - 1)
                {
                    Figure f1 = array[id + 1];
                    array[id + 1] = array[id];
                    array[id] = f1;
                    listView1.Items.Clear();
                    MakeTable();
                    flowLayoutPanel1.Controls.Clear();
                }
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                if (id != 0)
                {
                    Figure f1 = array[0];
                    array[0] = array[id];
                    array[id] = f1;
                    listView1.Items.Clear();
                    MakeTable();
                    flowLayoutPanel1.Controls.Clear();
                }
            }
        }

        private void Last_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                if (id != array.Count - 1)
                {
                    Figure f1 = array[array.Count - 1];
                    array[array.Count - 1] = array[id];
                    array[id] = f1;
                    listView1.Items.Clear();
                    MakeTable();
                    flowLayoutPanel1.Controls.Clear();
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            comboBox1.DroppedDown = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                Figure f = null;
                switch (comboBox1.Text)
                {
                    case "Rectangle":
                        f = new MakeRectangle(new Point(5, 5), new Point(10, 10), System.Drawing.Color.Black, System.Drawing.Color.Empty, 1);
                        break;
                    case "Ellipse":
                        f = new MakeEllipse(new Point(5, 5), new Point(10, 10), System.Drawing.Color.Black, System.Drawing.Color.Empty, 1);
                        break;
                    case "StraightLine":
                        f = new MakeStraightLine(new Point(5, 5), new Point(10, 10), System.Drawing.Color.Black, 1);
                        break;
                    case "Line":
                        f = new MakeLine(new List<Point> { new Point(5, 5), new Point(10, 10) }, System.Drawing.Color.Black, 1);
                        f.point1 = new Point(5, 5);
                        f.point2 = new Point(10, 10);
                        break;
                    case "Text":
                        f = new MakeText(new Point(5, 5), new Point(10, 10), "Your text", System.Drawing.Color.Black, Font);
                        break;
                }
                array.Add(f);
                listView1.Items.Clear();
                MakeTable();
                flowLayoutPanel1.Controls.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox1.Visible = false;
            }
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) comboBox1.Visible = false;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            F.array.Clear();
            foreach (Figure f in array) F.array.Add(f);
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            if (id != -1)
            {
                Figure f = null;
                switch (c1.Text)
                {
                    case "Rectangle":
                        f = new MakeRectangle(array[id].point1, array[id].point2, array[id].color, array[id].Cbackground, array[id].lineWidth);
                        break;
                    case "Ellipse":
                        f = new MakeEllipse(array[id].point1, array[id].point2, array[id].color, array[id].Cbackground, array[id].lineWidth);
                        break;
                    case "StraightLine":
                        f = new MakeStraightLine(array[id].point1, array[id].point2, array[id].color, array[id].lineWidth);
                        break;
                    case "Line":
                        f = new MakeLine(new List<Point> { array[id].point1, array[id].point2 }, array[id].color, array[id].lineWidth);
                        f.point1 = array[id].point1;
                        f.point2 = array[id].point2;
                        break;
                    case "Text":
                        Font font;
                        if (array[id].font != null) font = array[id].font;
                        else font = Font;
                        f = new MakeText(array[id].point1, array[id].point2, array[id].text, array[id].color, font);
                        break;
                }
                array[id] = f;
                listView1.Items.Clear();
                MakeTable();
                flowLayoutPanel1.Controls.Clear();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                array.RemoveAt(id);
                listView1.Items.Clear();
                MakeTable();
                flowLayoutPanel1.Controls.Clear();
            }
        }

        private void TextsChanged(object sender, EventArgs e)
        {
            if (id != -1)
            {
                if (t1.Text != "" && t2.Text != "" && t3.Text != "" && t4.Text != "" && t5.Text != "")
                {
                    array[id].point1.X = Convert.ToInt32(t1.Text);
                    array[id].point1.Y = Convert.ToInt32(t2.Text);
                    array[id].point2.X = Convert.ToInt32(t3.Text);
                    array[id].point2.Y = Convert.ToInt32(t4.Text);
                    array[id].lineWidth = Convert.ToInt32(t5.Text);
                    if (t6 != null) if (t6.Text != "")array[id].text = t6.Text;
                    if (t7 != null)
                    {
                        if (t7.Text != "")
                        {
                            string[] s = t7.Text.Split(' ');
                            List<Point> points = new List<Point>();

                            for(int j = 0; j < s.Length - 1; j++)
                            {
                                bool flag = false;
                                string[] s1 = new string[2];
                                for (int i = 0; i < s[j].Length; i++)
                                {
                                    if (Char.IsNumber(s[j][i]))
                                    {
                                        if (!flag) s1[0] += s[j][i];
                                        else s1[1] += s[j][i];
                                    }
                                    if (s[j][i] == ',') flag = true;
                                }
                                points.Add(new Point(Convert.ToInt32(s1[0]), Convert.ToInt32(s1[1])));
                            }
                            array[id].points = points;
                        }
                    }
                }

            }
        }

        private void Font_Click(object sender, EventArgs e)
        {
            if(id != -1)
            {
                if (fontDialog1.ShowDialog() == DialogResult.Cancel) return;
                array[id].font = fontDialog1.Font;
            }
        }
    }
}
