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
        private int countCdr;
        private int countWaiter;

        public Options()
        {
            countGroup = 0;
            countTable = 0;
            countCdr = 0;
            countWaiter = 0;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //listView1.Items..Add(new System.ComponentModel.SortDescription("NomColonne", System.ComponentModel.ListSortDirection.Descending));
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

            foreach (ListViewItem cdr in listView3.Items)
            {
                Parameters.listCdrBegin.Add(new List<string>() { cdr.SubItems[0].Text,
                                                                            cdr.SubItems[1].Text });
            }


            foreach (ListViewItem wtr in listView4.Items)
            {
                Parameters.listWaitersBegin.Add(new List<string>() { wtr.SubItems[0].Text,
                                                                            wtr.SubItems[1].Text });
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

            listView3.View = System.Windows.Forms.View.Details;
            listView3.Columns.Add("Serveur");
            listView3.Columns.Add("Ligne assignée");


            listView4.View = System.Windows.Forms.View.Details;
            listView4.Columns.Add("Chef de rang");
            listView4.Columns.Add("Rang assigné");
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

                bool OK = false;
                foreach(var listBoxItem in listBox1.Items)
                {
                    if(listBoxItem.ToString() == numericUpDown3.Text)
                    {
                        OK = true;
                        break;
                    }
                }

                if(OK == false)
                    listBox1.Items.Add(numericUpDown3.Text);
                


                bool OK2 = false;
                foreach (var listBoxItem in listBox2.Items)
                {
                    if (listBoxItem.ToString() == numericUpDown4.Text)
                    {
                        OK2 = true;
                        break;
                    }
                }

                if(OK2 == false)
                {
                    listBox2.Items.Add(numericUpDown4.Text);
                }

                numericUpDown3.BackColor = Color.White;
                numericUpDown4.BackColor = Color.White;
                countTable++;
            }
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string rang = listBox1.GetItemText(listBox1.SelectedItem);
            listView3.Items.Add(new ListViewItem(new string[] { "cdr" + countCdr, rang }));
            countCdr++;
        }

        private void button10_Click(object sender, EventArgs e)
        {

            string line = listBox2.GetItemText(listBox2.SelectedItem);
            listView4.Items.Add(new ListViewItem(new string[] { "cdr" + countWaiter, line }));
            countWaiter++;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView3.SelectedItems)
            {
                listView3.Items.Remove(eachItem);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView4.SelectedItems)
            {
                listView4.Items.Remove(eachItem);
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox6.Checked == true)
            {
                MessageBox.Show("Si vous configurez les tables, n'oubliez pas de configurer le personnel ! Sinon, les tables n'aurons aucun chef de rang / serveur d'assigné. (Onglet 'Config du personnel')");
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = true;
                numericUpDown5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                Parameters.configTables = true;
                listView2.Enabled = true;
                label12.Enabled = true;
                label13.Enabled = true;
                label14.Enabled = true;
            }
            else
            {
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                Parameters.configTables = false;
                listView2.Enabled = false;

                label12.Enabled = false;
                label13.Enabled = false;
                label14.Enabled = false;
            }

        }
    }
}
