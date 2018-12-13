using RestaurantRoomConsole.Controler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantRoomConsole.Controler;
using RestaurantRoomConsole.Model;
using RestaurantRoomConsole.View;


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

            // Remplissage des temps dans la classe statique Parameters
            Parameters.timeChooseMenu = Convert.ToInt32(UDTimeChooseMenu.Value) * 1000;
            Parameters.timeEatStarter= Convert.ToInt32(UDTimeChooseMenu.Value) * 1000;
            Parameters.timeEatMainCourse = Convert.ToInt32(UDTimeChooseMenu.Value) * 1000;
            Parameters.timeEatDessert = Convert.ToInt32(UDTimeChooseMenu.Value) * 1000;

            // Temps de spawn
            Parameters.timeSpawnMin = Convert.ToInt32(UDTimeSpawnMin.Value) * 1000;
            Parameters.timeSpawnMax = Convert.ToInt32(UDTimeSpawnMax.Value) * 1000;

            // Nappes et serviettes
            Parameters.nbrCleanNapkins = Convert.ToInt32(UDCleanNapkins.Value);
            Parameters.nbrCleanTableClothes = Convert.ToInt32(UDCleanTableClothes.Value);


            // Remplissage de la liste des groupes ayant reservés (dans la classe Parametres)
            foreach (ListViewItem itm in listView1.Items)
            {
                Parameters.listGroupClientReserved.Add(new List<string>() { itm.SubItems[0].Text,
                                                                            itm.SubItems[1].Text,
                                                                            itm.SubItems[2].Text });
               Modell.loopCount += 1;
            }
            
            // Instanciation du controller
            ControllerClass controler = new ControllerClass();
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
                MessageBox.Show("Il ne peut pas y avoir 0 clients dans un groupe !");
                numericUpDown1.BackColor = Color.FromArgb(255, 128, 128);
            }
            else if (numericUpDown2.Text == "0")
            {
                MessageBox.Show("Ils ne peuvent pas apparaitre 0 secondes avant le début du programme !");
                numericUpDown2.BackColor = Color.FromArgb(255, 128, 128);
            }
            else
            {

                listView1.Items.Add(new ListViewItem(new string[] { "Group" + count, numericUpDown1.Text, numericUpDown2.Text }));
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

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("--------------------------------");
            foreach (GroupClient group in Restaurant.listGroupClient)
            {
                Console.WriteLine("Nom : " + group.name + " A reservé : " + group.hasReserved + "  size : " + group.size + "  Attend une table : " + group.isWaitingATable);
                
            }
            Console.WriteLine("--------------------------------");
            Display.DisplayTables();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
