using RestaurantRoomConsole.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantRoomConsole
{
    public partial class Infos : Form
    {
        public Thread thinfos;
        public Infos()
        {
            InitializeComponent();
        }

        private void loopInfos()
        {
            while (true)
            {

                
                String textTables = "";
                foreach (Tables table in Restaurant.listTables)
                {
                    //this.Invoke((MethodInvoker)delegate {
                        String occuped = "";
                        String reserved = "";
                        if (table.isOccuped) { occuped = "Occupé"; } else { occuped = "libre"; }
                        if (table.isReserved) { reserved = "Réservé"; } else { reserved = "Non réservée"; }

                    textTables = textTables + table.name + " - ";

                        if (table.isOccuped) { textTables += "Occupée - " ; } else { textTables += "Libre - " ; }
                        if (table.isReserved) { textTables += "Réservée - " ; } else { textTables += "Non réservée - " ; }


                    textTables = textTables + table.groupAssigned + "\r\n";
                    
                }


                foreach(GroupClient grp in Restaurant.listGroupClient)
                {

                }



                this.Invoke((MethodInvoker)delegate
                {
                    if (textTables != richTextBox1.Text)
                    {
                        richTextBox1.Text = textTables;

                        this.CheckKeyword("Occupée", Color.Red, 0);
                        this.CheckKeyword("Réservée", Color.Red, 0);
                        this.CheckKeyword("Libre", Color.Green, 0);
                        this.CheckKeyword("Non réservée", Color.Green, 0);
                    }
                });
                Thread.Sleep(500);
            }
        }

        private void Infos_Load(object sender, EventArgs e)
        {

            thinfos = new Thread(loopInfos);
            thinfos.Start();
        }

        private void Infos_FormClosing(object sender, FormClosingEventArgs e)
        {
            thinfos.Abort();
        }

        private void richTextBox1_textChanged(object sender, EventArgs e)
        {
        }

        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (this.richTextBox1.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.richTextBox1.SelectionStart;

                while ((index = this.richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox1.Select((index + startIndex), word.Length);
                    this.richTextBox1.SelectionColor = color;
                    this.richTextBox1.Select(selectStart, 0);
                    this.richTextBox1.SelectionColor = Color.Black;
                }
            }
        }
    }
}
