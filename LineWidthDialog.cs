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
