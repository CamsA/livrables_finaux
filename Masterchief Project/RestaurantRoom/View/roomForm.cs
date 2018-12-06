using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantRoom
{
    public partial class roomForm : Form
    {
        public roomForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value = trackBar1.Value;
            MessageBox.Show(value.ToString());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
