using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using RestaurantRoomConsole.Model.MealStep;
using RestaurantRoomConsole.View;
using System.Collections;
using System.Xml.Linq;

namespace RestaurantRoomConsole.Model
{
    public class Waiter
    {
        public int lineAssigned;
        public String name;
        public Thread lpWaiter;

        public List<GroupClient> toServe;
        public Waiter(String _name, int _lineAssigned)
        {
            this.toServe = new List<GroupClient>();
            this.lineAssigned = _lineAssigned;
            this.name = _name;

            lpWaiter = new Thread(loopWaiter);
            
            
        }

        private void BringsBreadAndWater(Tables table, GroupClient grp)
        {
            if (table.nbrBreadBaskets == 0 && grp.stepMeal == 0)
            {
                table.nbrBreadBaskets++;
                Display.DisplayMsg("Le " + this.name + " apporte 1 barquette de pain pour " + table.name, false, false, ConsoleColor.DarkGray);
            }
            if (table.nbrWatterBottles == 0 && grp.stepMeal == 0)
            {
                table.nbrWatterBottles++;
                Display.DisplayMsg("Le " + this.name + " apporte 1 bouteille d'eau pour " + table.name, false, false, ConsoleColor.DarkGray);
            }
        }

        private bool VerifyTableLine(GroupClient grp)
        {
            bool OK = false;
            foreach (Tables table in Restaurant.listTables)
            {
                if (grp.assignedTable == table.name)
                {
                    if (table.line == this.lineAssigned)
                    {
                        BringsBreadAndWater(table, grp);
                        OK = true;
                    }
                } 
            }
            return OK;
        }

        public void deleteGroupClient(GroupClient grp)
        {
            if (!grp.isChoosingMeal && !grp.isEating && grp.mealChoosen)
            {
                Display.DisplayMsg("Le " + grp.name + " a fini de manger !", true, true, ConsoleColor.DarkBlue);


                // On trouve la table assigné aux clients qui viennent de finir de manger
                var tbl = Restaurant.listTables.FindIndex(c => c.groupAssigned == grp.name);

                // On met la met à libre et aucun groupe assigné
                Restaurant.listTables[tbl].isOccuped = false;
                Restaurant.listTables[tbl].groupAssigned = "";

                // On supprime le client de la liste des client
                Restaurant.listGroupClient.RemoveAll(c => c.name == grp.name);

                // On arrete les thread de l'objet du groupe pour éviter de manger de la mémoire pour rien
                
                grp.theat.Abort();
                
            }
        }

        public void giveMeal(GroupClient grp)
        {
            // Si le groupe de client a fini son dessert, alors on le supprime (  deleteGroupClient()  )
            //if(grp.stepMeal==3) { deleteGroupClient(grp); }
            if (grp.stepMeal != 3) { 
            // Sinon si le groupe n'est pas en train de choisir, n'est pas en train de manger et a bien choisi les menu 
                if (!grp.isChoosingMeal && !grp.isEating && grp.mealChoosen && !grp.isWaitingMeal)
                {
                    ExchangeDesk desk = ExchangeDesk.GetInstance;
                    
                    String meal = null;
                    if (grp.stepMeal == 0) { meal = "de l'entrée";   desk.SendOrders(grp.startersList); }
                    else if (grp.stepMeal == 1) { meal = "du plat";  desk.SendOrders(grp.mainCoursesList); }
                    else if (grp.stepMeal == 2) { meal = "du dessert";  desk.SendOrders(grp.dessertsList); }

                    this.toServe.Add(grp);
                    
                    Display.DisplayMsg("la commande " + meal + " a été transmise à la cuisine ! ",true,true, ConsoleColor.Gray);
                    grp.isWaitingMeal = true;
                }
            }
        }


        private void loopWaiter()
        {
            while(true)
            {


                if (Restaurant.listGroupClient.Count != 0)
                {
                    foreach (GroupClient grp in Restaurant.listGroupClient.ToList())
                    {
                        

                        if (VerifyTableLine(grp))
                        {

                            ExchangeDesk desk = ExchangeDesk.GetInstance;
                            // Si le group n'est pas en train de manger, n'est en attente d'une table (donc est assis),
                            // N'a pas reservé (renforcement), est bien assigné à une table (renforcement) :
                            if (grp.isWaitingMeal == false && grp.isEating == false && grp.isWaitingATable == false && grp.hasReserved == false && grp.assignedTable != "")
                            {
                                
                                giveMeal(grp);
                                break;
                            }
                            
                            if (grp.isWaitingMeal && desk.PreparedMeals.Count >= grp.size)
                            {
                                List<int> templistdesk = new List<int>();

                                for (int i = 0; i < grp.size; i++)
                                {
                                    templistdesk.Add(desk.PreparedMeals[i]);
                                }

                                /*foreach(int i in grp.startersList)
                                {
                                    Console.WriteLine("starter list : " + i);
                                }
                                foreach (int i in templistdesk)
                                {
                                    Console.WriteLine("temp list desk : " + i);
                                }*/
                                bool result = false;
                                switch (grp.stepMeal)
                                {
                                    case 0:
                                       result = templistdesk.All(s => grp.startersList.Contains(s)) && grp.startersList.All(s => templistdesk.Contains(s));

                                        break;

                                    case 1:
                                        result = templistdesk.All(s => grp.mainCoursesList.Contains(s)) && grp.mainCoursesList.All(s => templistdesk.Contains(s));

                                        break;
                                    case 2:
                                        result = templistdesk.All(s => grp.dessertsList.Contains(s)) && grp.dessertsList.All(s => templistdesk.Contains(s));

                                        break;
                                    default:
                                        result = false;
                                        break;
                                }
                                
                                
                                if (result)
                                {
                                    Console.WriteLine("EQUAAAAAL");

                                    
                                    desk.PreparedMeals.RemoveRange(0, grp.size);
                                      
                                    foreach (int i in desk.PreparedMeals)
                                    {
                                        int ind = desk.PreparedMeals.IndexOf(i);
                                        Console.WriteLine("Prepared MEAL : " + i + "  index : " + ind);
                                    }
                                    grp.isWaitingMeal = false;

                                    String meal = "";
                                    if (grp.stepMeal == 0) { meal = "de l'entrée"; }
                                    else if (grp.stepMeal == 1) { meal = "du plat"; }
                                    else if (grp.stepMeal == 2) { meal = "du dessert"; }
                                    Display.DisplayMsg("la commande "+meal+ " pour le " + grp.name + " est prête !", true, true, ConsoleColor.Cyan);
                                    grp.isEating = true;
                                   
                                }
                            }
                        }
                    }
                }
                Thread.Sleep(200);
            }
        }
    }
    
}
