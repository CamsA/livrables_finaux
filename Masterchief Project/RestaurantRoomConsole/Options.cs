using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantRoomConsole
{
    public partial class Options : Form
    {
        private int count;

        public Options()
        {
            count = 0;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button1.Enabled = false;
            Conntroller controler = new Conntroller();
        }
        
        private void Options_Load(object sender, EventArgs e)
        {
            listView1.View = System.Windows.Forms.View.Details;
            listView1.Columns.Add("Sec avant apparition");
        }
        

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.BackColor = Color.White;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.BackColor = Color.White;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (numericUpDown1.Text == "0")
            {
                MessageBox.Show("Il ne peut pas y avoir 0 clients dans un seul groupe !");
                numericUpDown1.BackColor = Color.FromArgb(255, 128, 128);
            }
            else if (numericUpDown2.Text == "0")
            {
                MessageBox.Show("Il nepeuvent pas apparaitre 0 secondes avant le début du programme !");
                numericUpDown2.BackColor = Color.FromArgb(255, 128, 128);
            }
            else
            {
                listView1.Items.Add(new ListViewItem(new string[] { "Groupe " + count, numericUpDown1.Text, numericUpDown2.Text }));
                numericUpDown1.BackColor = Color.White;
                numericUpDown2.BackColor = Color.White;
                count++;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView1.SelectedItems)
            {
                listView1.Items.Remove(eachItem);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
