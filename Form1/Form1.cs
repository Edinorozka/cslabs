﻿using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace paint
{
    public partial class Form1 : Form
    {
        public int xsize = 800, ysize = 600;

        public Form1()
        {
            InitializeComponent();
            FontTextLabel.Text = Data.font.Name;
            TextWidthLabel.Text = "Text width - " + Data.font.Size;
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form f = new Form2();
            f.Width = xsize;
            f.Height = ysize;
            f.MdiParent = this;
            f.Text = "Paint" + this.MdiChildren.Length.ToString();
            f.Show();
            saveAsToolStripMenuItem.Enabled = true;
            SaveAsButton.Enabled = true;
            imageEditorToolStripMenuItem.Enabled = true;
        }

        public void save(Form2 f)
        {
            SaveClass save = new SaveClass();
            save.set_Save(f.array, xsize, ysize);
            Console.Write(MdiChildren.Length.ToString());
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(ActiveMdiChild.Text, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, save);
            f.saveFlag = false;
            stream.Close();
        }

        public bool saveAs(Form2 f)
        {
            SaveClass save = new SaveClass();
            save.set_Save(f.array, xsize, ysize);
            saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog1.Filter = "BIN(*.BIN)|*bin|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, save);
                f.savefilecreate = true;
                f.saveFlag = false;
                f.Text = saveFileDialog1.FileName;
                stream.Close();
            }
            saveToolStripMenuItem.Enabled = true;
            SaveButton.Enabled = true;
            return false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save((Form2)ActiveMdiChild);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAs((Form2)ActiveMdiChild);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.Filter = "BIN(*.BIN)|*bin|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                SaveClass save = (SaveClass)formatter.Deserialize(stream);
                Form f = new Form2();
                f.MdiParent = this;
                f.Text = openFileDialog1.FileName;
                ((Form2)f).array = save.get_Save_mas();
                f.Width = save.get_Save_wight();
                f.Height = save.get_Save_height();
                f.Show();
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                SaveButton.Enabled = true;
                SaveAsButton.Enabled = true;
                stream.Close();
            }
        }

        private void lineColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = true;
            colorDialog1.ShowHelp = true;
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            if (Data.doubleClickflag)
            {
                Data.changeFigure.Change(Data.changeFigure.point1.X, Data.changeFigure.point1.Y, Data.changeFigure.point2.X,
                                         Data.changeFigure.point2.Y, colorDialog1.Color, Data.changeFigure.Cbackground,
                                         Data.changeFigure.lineWidth, Data.changeFigure.text, Data.changeFigure.font);
                ToolsComands.Grid((Form2)ActiveMdiChild);
            }
            else
            {
                Data.color = colorDialog1.Color;
                ColorLabel.BackColor = Data.color;
            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!backgroundColorToolStripMenuItem.Checked)
            {
                colorDialog1.AllowFullOpen = true;
                colorDialog1.ShowHelp = true;
                if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                if (Data.doubleClickflag && Data.changeFigure != null)
                {
                    if (Data.changeFigure.ToString() == "paint.MakeRectangle" || Data.changeFigure.ToString() == "paint.MakeEllipse" ||
                    Data.changeFigure.ToString() == "paint.MakeText")
                    {
                        Data.changeFigure.Change(Data.changeFigure.point1.X, Data.changeFigure.point1.Y, Data.changeFigure.point2.X,
                                                 Data.changeFigure.point2.Y, Data.changeFigure.color, colorDialog1.Color,
                                                 Data.changeFigure.lineWidth, Data.changeFigure.text, Data.changeFigure.font);
                        ToolsComands.Grid((Form2)ActiveMdiChild);
                    }
                }
                else
                {
                    Data.background = colorDialog1.Color;
                    backgroundColorToolStripMenuItem.Checked = true;
                    BackgroundLabel.BackColor = Data.background;
                    LineBacgroundButton.CheckState = CheckState.Checked;
                }
            }
            else
            {
                backgroundColorToolStripMenuItem.Checked = false;
                Data.background = new Color();
                BackgroundLabel.BackColor = Data.background;
                LineBacgroundButton.CheckState = CheckState.Unchecked;
            }
        }

        private void lineWidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineWidthDialog lwd = new lineWidthDialog();
            if (lwd.ShowDialog() == DialogResult.Cancel) return;

            if (Data.doubleClickflag)
            {
                Data.changeFigure.Change(Data.changeFigure.point1.X, Data.changeFigure.point1.Y, Data.changeFigure.point2.X,
                                         Data.changeFigure.point2.Y, Data.changeFigure.color, Data.changeFigure.Cbackground,
                                         lwd.width(), Data.changeFigure.text, Data.changeFigure.font);
                ToolsComands.Grid((Form2)ActiveMdiChild);
            }
            else
            {
                Data.lineWidth = lwd.width();
                LineWidthLabel.Text = "Line width - " + Data.lineWidth;
            }
        }

        private void optionsTool(Form2 f)
        {
            FormSize fs = new FormSize();
            if (fs.ShowDialog() == DialogResult.Cancel) return;
            xsize = fs.width();
            ysize = fs.height();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            optionsTool((Form2)ActiveMdiChild);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolsComands.Delete((Form2)ActiveMdiChild);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolsComands.Copy((Form2)ActiveMdiChild);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolsComands.Paste((Form2)ActiveMdiChild);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolsComands.Cut((Form2)ActiveMdiChild);
        }

        private void copyInMetafileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolsComands.CopyInMetafile((Form2)ActiveMdiChild);
        }

        private void getGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MdiChildren.Length != 0)
            {
                foreach (Form2 f in MdiChildren) ToolsComands.Grid(f);
            }
        }

        private void textSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Data.doubleClickflag && Data.changeFigure != null)
            {
                if(Data.changeFigure.ToString() == "paint.MakeText")
                {
                    if (fontDialog1.ShowDialog() == DialogResult.Cancel) return;
                    Data.changeFigure.Change(Data.changeFigure.point1.X, Data.changeFigure.point1.Y, Data.changeFigure.point2.X,
                                             Data.changeFigure.point2.Y, Data.changeFigure.color, Data.changeFigure.Cbackground,
                                             Data.changeFigure.lineWidth, Data.changeFigure.text, fontDialog1.Font);
                    ToolsComands.Grid((Form2)ActiveMdiChild);
                }
            }
            else
            {
                if (!textSettingsToolStripMenuItem.Checked)
                {
                    if (fontDialog1.ShowDialog() == DialogResult.Cancel) return;
                    Data.font = fontDialog1.Font;
                    textSettingsToolStripMenuItem.Checked = true;
                    TextSettingsButton.CheckState = CheckState.Checked;
                }
                else
                {
                    Data.font = DefaultFont;
                    textSettingsToolStripMenuItem.Checked = false;
                    TextSettingsButton.CheckState = CheckState.Unchecked;
                }

                FontTextLabel.Text = Data.font.Name;
                TextWidthLabel.Text = "Text width - " + Data.font.Size;
            }
        }

        private void gridSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridDistanceDialog gdd = new GridDistanceDialog();
            if (gdd.ShowDialog() == DialogResult.Cancel) return;
            Data.gridDistance = gdd.Grid();
            if (MdiChildren.Length != 0)
            {
                foreach (Form2 f in MdiChildren) ToolsComands.Grid(f);
            }
        }

        private void snapToGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.snapToGrig = snapToGridToolStripMenuItem.Checked;
        }

        private void gridAlignmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MdiChildren.Length != 0)
            {
                ToolsComands.GridAlignment((Form2)ActiveMdiChild);
            }
        }

        private void imageEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageEditor Ie = new ImageEditor((Form2)ActiveMdiChild);
            if (Ie.ShowDialog() == DialogResult.OK)
            {
                ToolsComands.Grid((Form2)ActiveMdiChild);
                return;
            }
            }

            private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.figures = Data.Figures.rectangle;
            backgroundColorToolStripMenuItem.Visible = true;
            rectangleToolStripMenuItem.Checked = true;
            ellipseToolStripMenuItem.Checked = false;
            straightLineToolStripMenuItem.Checked = false;
            lineToolStripMenuItem.Checked = false;
            textToolStripMenuItem.Checked = false;
            ActiveFigureLabel.Text = "Rectangle";
            ColorIs.Visible = true;
            ColorLabel.Visible = true;
            background.Visible = true;
            BackgroundLabel.Visible = true;
            FontTextLabel.Visible = false;
            TextWidthLabel.Visible = false;
            LineWidthLabel.Visible = true;
            ChangeButton.CheckState = CheckState.Unchecked;
            RectangleButton.CheckState = CheckState.Checked;
            EllipseButton.CheckState = CheckState.Unchecked;
            StraightLineButton.CheckState = CheckState.Unchecked;
            lineButton.CheckState = CheckState.Unchecked;
            TextButton.CheckState = CheckState.Unchecked;
            LineBacgroundButton.Visible = true;
            changeToolStripMenuItem.Checked = false;
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.figures = Data.Figures.ellipse;
            ColorIs.Visible = true;
            ColorLabel.Visible = true;
            LineWidthLabel.Visible = true;
            backgroundColorToolStripMenuItem.Visible = true;
            rectangleToolStripMenuItem.Checked = false;
            ellipseToolStripMenuItem.Checked = true;
            straightLineToolStripMenuItem.Checked = false;
            lineToolStripMenuItem.Checked = false;
            textToolStripMenuItem.Checked = false;
            ActiveFigureLabel.Text = "Ellipse";
            background.Visible = true;
            BackgroundLabel.Visible = true;
            FontTextLabel.Visible = false;
            TextWidthLabel.Visible = false;
            ChangeButton.CheckState = CheckState.Unchecked;
            RectangleButton.CheckState = CheckState.Unchecked;
            EllipseButton.CheckState = CheckState.Checked;
            StraightLineButton.CheckState = CheckState.Unchecked;
            lineButton.CheckState = CheckState.Unchecked;
            TextButton.CheckState = CheckState.Unchecked;
            LineBacgroundButton.Visible = true;
            changeToolStripMenuItem.Checked = false;
        }

        private void straightLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.figures = Data.Figures.straight;
            ColorIs.Visible = true;
            ColorLabel.Visible = true;
            LineWidthLabel.Visible = true;
            backgroundColorToolStripMenuItem.Visible = false;
            rectangleToolStripMenuItem.Checked = false;
            ellipseToolStripMenuItem.Checked = false;
            straightLineToolStripMenuItem.Checked = true;
            lineToolStripMenuItem.Checked = false;
            textToolStripMenuItem.Checked = false;
            ActiveFigureLabel.Text = "Straight Line";
            background.Visible = false;
            BackgroundLabel.Visible = false;
            FontTextLabel.Visible = false;
            TextWidthLabel.Visible = false;
            ChangeButton.CheckState = CheckState.Unchecked;
            RectangleButton.CheckState = CheckState.Unchecked;
            EllipseButton.CheckState = CheckState.Unchecked;
            StraightLineButton.CheckState = CheckState.Checked;
            lineButton.CheckState = CheckState.Unchecked;
            TextButton.CheckState = CheckState.Unchecked;
            LineBacgroundButton.Visible = false;
            changeToolStripMenuItem.Checked = false;
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.figures = Data.Figures.line;
            ColorIs.Visible = true;
            ColorLabel.Visible = true;
            LineWidthLabel.Visible = true;
            backgroundColorToolStripMenuItem.Visible = false;
            rectangleToolStripMenuItem.Checked = false;
            ellipseToolStripMenuItem.Checked = false;
            straightLineToolStripMenuItem.Checked = false;
            lineToolStripMenuItem.Checked = true;
            textToolStripMenuItem.Checked = false;
            ActiveFigureLabel.Text = "Line";
            background.Visible = false;
            BackgroundLabel.Visible = false;
            FontTextLabel.Visible = false;
            TextWidthLabel.Visible = false;
            ChangeButton.CheckState = CheckState.Unchecked;
            RectangleButton.CheckState = CheckState.Unchecked;
            EllipseButton.CheckState = CheckState.Unchecked;
            StraightLineButton.CheckState = CheckState.Unchecked;
            lineButton.CheckState = CheckState.Checked;
            TextButton.CheckState = CheckState.Unchecked;
            LineBacgroundButton.Visible = false;
            changeToolStripMenuItem.Checked = false;
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            Data.figures = Data.Figures.change;
            ChangeButton.CheckState = CheckState.Checked;
            RectangleButton.CheckState = CheckState.Unchecked;
            EllipseButton.CheckState = CheckState.Unchecked;
            StraightLineButton.CheckState = CheckState.Unchecked;
            lineButton.CheckState = CheckState.Unchecked;
            TextButton.CheckState = CheckState.Unchecked;
            ActiveFigureLabel.Text = "Change";
            ColorIs.Visible = false;
            ColorLabel.Visible = false;
            background.Visible = false;
            BackgroundLabel.Visible = false;
            FontTextLabel.Visible = false;
            TextWidthLabel.Visible = false;
            LineWidthLabel.Visible = false;
            rectangleToolStripMenuItem.Checked = false;
            ellipseToolStripMenuItem.Checked = false;
            straightLineToolStripMenuItem.Checked = false;
            lineToolStripMenuItem.Checked = false;
            textToolStripMenuItem.Checked = false;
            changeToolStripMenuItem.Checked = true;
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.figures = Data.Figures.text;
            ColorIs.Visible = true;
            ColorLabel.Visible = true;
            LineWidthLabel.Visible = false;
            LineWidthLabel.Visible = true;
            backgroundColorToolStripMenuItem.Visible = false;
            changeToolStripMenuItem.Checked = false;
            LineBacgroundButton.Visible = false;
            background.Visible = false;
            BackgroundLabel.Visible = false;
            rectangleToolStripMenuItem.Checked = false;
            ellipseToolStripMenuItem.Checked = false;
            straightLineToolStripMenuItem.Checked = false;
            lineToolStripMenuItem.Checked = false;
            textToolStripMenuItem.Checked = true;
            FontTextLabel.Visible = true;
            TextWidthLabel.Visible = true;
            ActiveFigureLabel.Text = "Text";
            ChangeButton.CheckState = CheckState.Unchecked;
            RectangleButton.CheckState = CheckState.Unchecked;
            EllipseButton.CheckState = CheckState.Unchecked;
            StraightLineButton.CheckState = CheckState.Unchecked;
            lineButton.CheckState = CheckState.Unchecked;
            TextButton.CheckState = CheckState.Checked;
        }

    }
}
