using System;
using System.Collections.Generic;
using System.Data;
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
        
        public bool isWaitingMeal;

        public Thread theat;
        public bool HasFinishedEat;

        public List<int> startersList;
        public List<int> mainCoursesList;
        public List<int> dessertsList;



        public GroupClient(String _name, int _nbrClients, bool _hasReserved)
        {
            this.isWaitingMeal = false;
            startersList = new List<int>();
            mainCoursesList = new List<int>();
            dessertsList = new List<int>();

            this.HasFinishedEat = false;

            // Remplissage des valeurs du constructeur
            this.mealChoosen = false;
            theat = new Thread(loopEat);
            this.hasReserved = _hasReserved; 
            this.name = _name;
            this.size = _nbrClients;
            this.isWaitingATable = true;
            this.isChoosingMeal = false;
            this.stepMeal = 0;
            
            // Si hasReserved = true, alors il n'attend pas encore de table

            if (_hasReserved) {
                this.isWaitingATable = false;
            }
                
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

        public void chooseMeal(int _step)
        {

            DataSet data = new DataSet();
            DataTable dt = new DataTable();

            data = SQLprocess.GetRecipesByType("MasterChiefDB", _step);
            dt = data.Tables["MasterChiefDB"];

            List<List<String>> listRecette = new List<List<String>>();
            List<String> listPerClient = new List<String>();
            List<int> recettesDispos = new List<int>();


            foreach (DataRow dr in dt.Rows)
                recettesDispos.Add(int.Parse(dr["IDRecette"].ToString()));


            Random rnd = new Random();
            for (int i = 0; i < this.size; i++)
            {

                int recetteChoisi = 0;

                switch (_step)
                {
                    case 1:

                        recetteChoisi = rnd.Next(0, recettesDispos.Count());
                        startersList.Add(recettesDispos[recetteChoisi]);
                        break;
                    case 2:

                        recetteChoisi = rnd.Next(0, recettesDispos.Count());
                        mainCoursesList.Add(recettesDispos[recetteChoisi]);
                        break;
                    case 3:

                        recetteChoisi = rnd.Next(0, recettesDispos.Count());
                        dessertsList.Add(recettesDispos[recetteChoisi]);
                        break;
                    default:
                        break;
                }
                    
            }


        }

        public void loopEat()
        {
            while (true)
            {
                if (this.isEating)
                {
                    String spmeal = "";
                    if (this.stepMeal == 0) spmeal = "l'entrée";
                    else if (this.stepMeal == 1) spmeal = "le plat";
                    else if (this.stepMeal == 2) spmeal = "le dessert";

                    Display.DisplayMsg("****    Le " + this.name + " est en train de manger " + spmeal, false, false, ConsoleColor.Green);
                    
                    switch(this.stepMeal)
                    {
                        case 1: Thread.Sleep(Parameters.timeEatStarter); break;
                        case 2: Thread.Sleep(Parameters.timeEatMainCourse); break;
                        case 3: Thread.Sleep(Parameters.timeEatDessert); break;
                        default: Thread.Sleep(5000); break;
                    }

                    Display.DisplayMsg("****    Le " + this.name + " a fini de manger " + spmeal, false, false, ConsoleColor.DarkGreen);
                    this.stepMeal += 1;
                    isEating = false;
                }

                if (this.isChoosingMeal == true && !this.mealChoosen)
                {
                    Thread.Sleep(Parameters.timeChooseMenu);

                    chooseMeal(1);
                    Thread.Sleep(200);
                    chooseMeal(2);
                    Thread.Sleep(200);
                    chooseMeal(3);
                    Thread.Sleep(200);



                    // this.starterlist.Add(int)

                    Display.DisplayMsg("Le " + this.name + " vient de choisir le repas !",false,false,ConsoleColor.Yellow);
                    ExchangeDesk desk = ExchangeDesk.GetInstance;

                   Console.WriteLine("Les clients ont choisi en entrée : ");
                    foreach (int i in startersList)
                    {
                        Console.Write(i + " ");
                    }
                    Console.WriteLine("Les clients ont choisi en plat principal : ");
                    foreach (int i in mainCoursesList)
                    {
                        Console.Write(i + " ");
                    }

                    Console.WriteLine("Les clients ont choisi en dessert : ");
                    foreach (int i in dessertsList)
                    {
                        Console.Write(i + " ");
                    }
                    Console.WriteLine();
                    this.isChoosingMeal = false;
                    mealChoosen = true;
                }
                Thread.Sleep(200);
            }
        }
    }

}
