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

        public Waiter(String _name, int _lineAssigned)
        {
            this.lineAssigned = _lineAssigned;
            this.name = _name;

            lpWaiter = new Thread(new ThreadStart(loopWaiter));
            lpWaiter.Start();
            
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
                grp.thmealchoose.Abort();
                grp.theat.Abort();
                
            }
        }

        public void giveMeal(GroupClient grp)
        {
            // Si le groupe de client a fini son dessert, alors on le supprime (  deleteGroupClient()  )
            //if(grp.stepMeal==3) { deleteGroupClient(grp); }
            if (grp.stepMeal != 3) { 
            // Sinon si le groupe n'est pas en train de choisir, n'est pas en train de manger et a bien choisi les menu 
                if (!grp.isChoosingMeal && !grp.isEating && grp.mealChoosen)
                {
                    String meal = null;
                    if (grp.stepMeal == 0) { meal = "l'entrée"; }
                    else if (grp.stepMeal == 1) { meal = "le plat"; }
                    else if (grp.stepMeal == 2) { meal = "le dessert"; }

                    Display.DisplayMsg("Le " + this.name + " est en train d'apporter " + meal + " au " + grp.name + "...", false, false, ConsoleColor.Yellow);
                    
                    Thread.Sleep(5000);

                    grp.stepMeal++; // Est rendu à l'entrée
                    grp.isEating = true; // est en train de manger l'entrée
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
                            // Si le group n'est pas en train de manger, n'est en attente d'une table (donc est assis),
                            // N'a pas reservé (renforcement), est bien assigné à une table (renforcement) :
                            if (grp.isEating == false && grp.isWaitingATable == false && grp.hasReserved == false && grp.assignedTable != "")
                            {
                                giveMeal(grp);
                            }
                        }
                    }
                }
                Thread.Sleep(200);
            }
        }
    }
    
}
