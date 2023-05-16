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
    public partial class FormSize : Form
    {
        public FormSize()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        public int width()
        {
            if (checkBox1.Checked && textBox1.Text != "") return Convert.ToInt32(textBox1.Text);
            else
            {
                if (formVerySmall.Checked) return 320;
                else if (formSmall.Checked) return 640;
                else return 800;
            }
        }

        public int height()
        {
            if (checkBox1.Checked && textBox2.Text != "") return Convert.ToInt32(textBox2.Text);
            else
            {
                if (formVerySmall.Checked) return 240;
                else if (formSmall.Checked) return 480;
                else return 600;
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            } else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            }
        }
    }
}
