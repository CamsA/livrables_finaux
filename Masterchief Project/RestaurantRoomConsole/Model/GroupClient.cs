using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestaurantRoomConsole.Controler;
using RestaurantRoomConsole.Model.MealStep;
using RestaurantRoomConsole.View;
namespace RestaurantRoomConsole.Model
{
    public class GroupClient
    {

        public String name;
        public int size;
        public List<Clients> clientList;
        public bool hasReserved;
        public String assignedTable;
        public bool isEating;
        public bool isWaitingATable;
        public int stepMeal;
        public bool isChoosingMeal;
        public bool mealChoosen;
        public Thread thmealchoose;
        public Thread theat;
        public bool HasFinishedEat;
        public GroupClient()
        { }



        public GroupClient(String _name, int _nbrClients, bool _hasReserved)
        {
            this.HasFinishedEat = false;
            // Remplissage des valeurs du constructeur
            this.mealChoosen = false;
            theat = new Thread(loopEat);
            thmealchoose = new Thread(loopChoose);
            thmealchoose.Start();
            theat.Start();
            this.hasReserved = _hasReserved; 
            this.name = _name;
            this.size = _nbrClients;
            this.isWaitingATable = true;
            this.isChoosingMeal = false;
            this.stepMeal = 0;

            
            // Si hasReserved = true, alors il n'attend pas encore de table
            if (_hasReserved) { this.isWaitingATable = false; }
                
            clientList = new List<Clients>();
            Restaurant.listGroupClient.Add(this);

        }

        public void DisplayGroupClient()
        {
            foreach (Clients client in this.clientList)
            {
                //Console.WriteLine("Dans " + this.name + " il y a " + client.name);
            }
        }


        public void loopGen()
        {
            while (true)
            {

                Thread.Sleep(500);
            }
        }
        public void loopEat()
        {
            while (true)
            {
                if (this.isEating)
                {
                    String spmeal = "";
                    if (this.stepMeal == 1) spmeal = "l'entrée";
                    else if (this.stepMeal == 2) spmeal = "le plat";
                    else if (this.stepMeal == 3) spmeal = "le dessert";
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(DateTime.Now.ToString("mm:ss tt") + " :   ****    Le " + this.name + " est en train de manger " + spmeal);
                    Console.ResetColor();
                    Thread.Sleep(5000);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(DateTime.Now.ToString("mm:ss tt") + " :   ****    Le " + this.name + " a fini de manger le " + spmeal);
                    Console.ResetColor();
                    isEating = false;
                } 
            }
        }

        public void loopChoose()
        {
            while (true)
            {
                if (this.isChoosingMeal == true && !this.mealChoosen)
                {
                    Thread.Sleep(Parameters.timeChooseMenu);
                    
                    String spmeal = "";
                    if (this.stepMeal == 0) spmeal = "l'entrée";
                    else if (this.stepMeal == 1) spmeal = "le plat";
                    else if (this.stepMeal == 2) spmeal = "le dessert";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(DateTime.Now.ToString("mm:ss tt") + " : Le " + this.name + " viennent de choisir " + spmeal + " !");
                    Console.ResetColor();


                    // ** Requete bdd des plats dispos
                    // Selon le size du group client (for)

                    // this.starterlist.Add(int)
                    this.isChoosingMeal = false;
                    mealChoosen = true;
                }
                Thread.Sleep(200);
            }
        }
    }

}
