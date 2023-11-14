using System;
using System.Windows.Forms;

namespace paint
{
    public partial class lineWidthDialog : Form
    {
        public lineWidthDialog()
        {
            InitializeComponent();
        }

        public int width()
        {
            if (comboBox1.Text == "") return 1;
            else return Convert.ToInt32(comboBox1.Text);
        }
    }
}
