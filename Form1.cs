using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
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
        }

        public void save(Form2 f)
        {
            Console.Write(this.MdiChildren.Length.ToString());
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(ActiveMdiChild.Text, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, f.array);
            f.saveFlag = false;
            stream.Close();
        }

        public bool saveAs(Form2 f)
        {
            saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog1.Filter = "BIN(*.BIN)|*bin|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, f.array);
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
                Form f = new Form2();
                f.MdiParent = this;
                f.Text = openFileDialog1.FileName;
                ((Form2)f).array = (List<Figure>)formatter.Deserialize(stream);
                ((Form2)f).openfile = true;
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
            Data.color = colorDialog1.Color;
            ColorLabel.BackColor = Data.color;
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!backgroundColorToolStripMenuItem.Checked)
            {
                colorDialog1.AllowFullOpen = true;
                colorDialog1.ShowHelp = true;
                if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                Data.background = colorDialog1.Color;
                backgroundColorToolStripMenuItem.Checked = true;
                BackgroundLabel.BackColor = Data.background;
                LineBacgroundButton.CheckState = CheckState.Checked;
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
            Data.lineWidth = lwd.width();
            LineWidthLabel.Text = "Line width - " + Data.lineWidth;
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


        private void textSettingsToolStripMenuItem_Click(object sender, EventArgs e)
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
            background.Visible = true;
            BackgroundLabel.Visible = true;
            FontTextLabel.Visible = false;
            TextWidthLabel.Visible = false;
            RectangleButton.CheckState = CheckState.Checked;
            EllipseButton.CheckState = CheckState.Unchecked;
            StraightLineButton.CheckState = CheckState.Unchecked;
            lineButton.CheckState = CheckState.Unchecked;
            TextButton.CheckState = CheckState.Unchecked;
            LineBacgroundButton.Visible = true;
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.figures = Data.Figures.ellipse;
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
            RectangleButton.CheckState = CheckState.Unchecked;
            EllipseButton.CheckState = CheckState.Checked;
            StraightLineButton.CheckState = CheckState.Unchecked;
            lineButton.CheckState = CheckState.Unchecked;
            TextButton.CheckState = CheckState.Unchecked;
            LineBacgroundButton.Visible = true;
        }

        private void straightLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.figures = Data.Figures.straight;
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
            RectangleButton.CheckState = CheckState.Unchecked;
            EllipseButton.CheckState = CheckState.Unchecked;
            StraightLineButton.CheckState = CheckState.Checked;
            lineButton.CheckState = CheckState.Unchecked;
            TextButton.CheckState = CheckState.Unchecked;
            LineBacgroundButton.Visible = false;
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.figures = Data.Figures.line;
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
            RectangleButton.CheckState = CheckState.Unchecked;
            EllipseButton.CheckState = CheckState.Unchecked;
            StraightLineButton.CheckState = CheckState.Unchecked;
            lineButton.CheckState = CheckState.Checked;
            TextButton.CheckState = CheckState.Unchecked;
            LineBacgroundButton.Visible = false;
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.figures = Data.Figures.text;
            LineWidthLabel.Visible = false;
            backgroundColorToolStripMenuItem.Visible = false;
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
            RectangleButton.CheckState = CheckState.Unchecked;
            EllipseButton.CheckState = CheckState.Unchecked;
            StraightLineButton.CheckState = CheckState.Unchecked;
            lineButton.CheckState = CheckState.Unchecked;
            TextButton.CheckState = CheckState.Checked;
        }

    }
}
