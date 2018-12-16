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

        private String choiceStepMeal(int step)
        {
            switch (step)
            {
                case 0:
                    return "l'entrée - ";
                    break;
                case 1:
                    return "le plat - ";
                    break;
                case 2:
                    return "le dessert - ";
                    break;
                default:
                    return "";
                    break;
            }
        }



        private void loopInfos()
        {
            while (true)
            {

                
                String textTables = "";
                String textClients = "";

                foreach (Tables table in Restaurant.listTables)
                {
                    //this.Invoke((MethodInvoker)delegate {
                        String occuped = "";
                        String reserved = "";
                        if (table.isOccuped) { occuped = "Occupé"; } else { occuped = "libre"; }
                        if (table.isReserved) { reserved = "Réservé"; } else { reserved = "Non réservée"; }

                    textTables = textTables + table.name + " ("+table.size+" places) ("+table.rang+", "+table.line+")- ";

                        if (table.isOccuped) { textTables += "Occupée - " ; } else { textTables += "Libre - " ; }
                        if (table.isReserved) { textTables += "Réservée - " ; } else { textTables += "Non réservée - " ; }


                    textTables = textTables + table.groupAssigned + "\r\n";
                    
                }


                foreach(GroupClient grp in Restaurant.listGroupClient)
                {
                    textClients = textClients + grp.name + " ("+grp.size+" clients) - ";
                    textClients = textClients + grp.assignedTable + " - ";
                    if (grp.isWaitingATable)
                        textClients = textClients + "Attend une table";

                    if(grp.isEating)
                        textClients = textClients + "En train de manger " + choiceStepMeal(grp.stepMeal);
                        
                    else if(grp.isChoosingMeal)
                            textClients = textClients + "En train de choisir " + choiceStepMeal(grp.stepMeal);
                      
                    else if(grp.mealChoosen && !grp.isEating) {
                        textClients = textClients + "Attend " + choiceStepMeal(grp.stepMeal);
                        
                    }
                    //public bool hasReserved; {

                    /** public bool isEating;
                     public bool isWaitingATable;
                     public int stepMeal;
                     public bool isChoosingMeal;
                     public bool mealChoosen;

                     public bool isWaitingMeal;

                     public Thread theat;
                     public bool HasFinishedEat;

                     public List<int> startersList;
                     public List<int> mainCoursesList;
                     public List<int> dessertsList;*/
                    textClients += "\r\n";
                }



                this.Invoke((MethodInvoker)delegate
                {
                    if (textTables != richTextBox1.Text)
                    {
                        richTextBox1.Text = textTables;

                        this.CheckKeyword("Occupée", Color.Red, 0, richTextBox1);
                        this.CheckKeyword("Réservée", Color.Red, 0, richTextBox1);
                        this.CheckKeyword("Libre", Color.Green, 0, richTextBox1);
                        this.CheckKeyword("Non réservée", Color.Green, 0, richTextBox1);
                    }

                    if (textClients != richTextBox2.Text)
                    {
                        richTextBox2.Text = textClients;

                        this.CheckKeyword("Attend une table", Color.Red, 0, richTextBox2);
                        this.CheckKeyword("En train de manger l'entrée", Color.Green, 0, richTextBox2);
                        this.CheckKeyword("En train de manger le plat", Color.Green, 0, richTextBox2);
                        this.CheckKeyword("En train de manger le dessert", Color.Green, 0, richTextBox2);
                        this.CheckKeyword("Attend l'entrée", Color.Orange, 0, richTextBox2);
                        this.CheckKeyword("Attend le plat", Color.Orange, 0, richTextBox2);
                        this.CheckKeyword("Attend le dessert", Color.Orange, 0, richTextBox2);

                        /*this.CheckKeyword("Occupée", Color.Red, 0);
                        this.CheckKeyword("Réservée", Color.Red, 0);
                        this.CheckKeyword("Libre", Color.Green, 0);
                        this.CheckKeyword("Non réservée", Color.Green, 0);*/

                    }
                    if(nbrNapkins.Text != ExchangeDesk.GetInstance.CleanNapkins.ToString())
                    {
                        nbrNapkins.Text = (ExchangeDesk.GetInstance.CleanNapkins).ToString();
                    }

                    if (nbrTableclothes.Text != ExchangeDesk.GetInstance.CleanTableClothes.ToString())
                    {
                        nbrTableclothes.Text = (ExchangeDesk.GetInstance.CleanTableClothes).ToString();
                    }
                });
                Thread.Sleep(200);
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

        private void CheckKeyword(string word, Color color, int startIndex, RichTextBox rtb)
        {
            if (rtb.Text.Contains(word))
            {
                int index = -1;
                int selectStart = rtb.SelectionStart;

                while ((index = rtb.Text.IndexOf(word, (index + 1))) != -1)
                {
                    rtb.Select((index + startIndex), word.Length);
                    rtb.SelectionColor = color;
                    rtb.Select(selectStart, 0);
                    rtb.SelectionColor = Color.Black;
                }
            }
        }
    }
}
