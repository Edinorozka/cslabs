using System;
using System.Windows.Forms;

namespace paint
{
    public partial class GridDistanceDialog : Form
    {
        public GridDistanceDialog()
        {
            InitializeComponent();
        }

        public int Grid()
        {
            if (comboBox1.Text == "") return 10;
            else return Convert.ToInt32(comboBox1.Text);
        }
    }
}
