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
using System.Threading;

namespace RestaurantRoomConsole
{
    public partial class Options : Form
    {
        private int countGroup;
        private int countTable;

        public Options()
        {
            countGroup = 0;
            countTable = 0;
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

            foreach (ListViewItem tbl in listView2.Items)
            {
                Parameters.listTablesBegin.Add(new List<string>() { tbl.SubItems[0].Text,
                                                                            tbl.SubItems[1].Text,
                                                                            tbl.SubItems[2].Text,
                                                                            tbl.SubItems[3].Text });
                
            }

            ControllerClass controler = new ControllerClass();
            //Thread thinfos = new Thread(new System.Threading.ThreadStart(getInfos));
           // thinfos.Start();
           /* BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(getInfos);
            worker.RunWorkerAsync();*/
        }
        private void getInfos()
        {
            while (true)
            {
                int t = 0;
                /*if (this.InvokeRequired)
                    this.Invoke(new TonDelegate(TaForm.FctionMAJLabel));
                else
                    Options.FctionMAJLabel();
                Console.WriteLine("BONJOUR");
                UDCleanNapkins.Value += 1;*/
                UDCleanNapkins.Invoke(new Action(() =>
                {
                    UDCleanNapkins.Value += 1;
                }));
                Thread.Sleep(500);
            }

        }

        

        private void Options_Load(object sender, EventArgs e)
        {
            listView1.View = System.Windows.Forms.View.Details;
            listView1.Columns.Add("Sec avant apparition");


            listView2.View = System.Windows.Forms.View.Details;
            listView2.Columns.Add("Table");
            listView2.Columns.Add("Nombre");
            listView2.Columns.Add("Rang");
            listView2.Columns.Add("Ligne");
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

                listView1.Items.Add(new ListViewItem(new string[] { "Group" + countGroup, numericUpDown1.Text, numericUpDown2.Text }));
                numericUpDown1.BackColor = Color.White;
                numericUpDown2.BackColor = Color.White;
                countGroup++;
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
            Modell.pauseThread();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Infos form2 = new Infos();
            form2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (numericUpDown3.Value < 1)
            {
                MessageBox.Show("Vous ne pouvez pas choisir rang 0 !");
                numericUpDown3.BackColor = Color.FromArgb(255, 128, 128);
            }
            else if (numericUpDown4.Value < 1)
            {
                MessageBox.Show("Vous ne pouvez pas choisir ligne 0 !");
                numericUpDown4.BackColor = Color.FromArgb(255, 128, 128);
            }
            else if (numericUpDown5.Value < 1)
            {
                MessageBox.Show("Vous ne pouvez pas choisir une taille de 0 places !");
                numericUpDown4.BackColor = Color.FromArgb(255, 128, 128);
            }
            else
            {

                listView2.Items.Add(new ListViewItem(new string[] { "Table" + countTable, numericUpDown5.Text , numericUpDown3.Text, numericUpDown4.Text }));
                numericUpDown3.BackColor = Color.White;
                numericUpDown4.BackColor = Color.White;
                countTable++;
            }
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {

        }
    }
}
