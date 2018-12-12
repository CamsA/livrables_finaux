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

        public Waiter(String _name, int _lineAssigned)
        {
            this.lineAssigned = _lineAssigned;
            this.name = _name;

            Thread lpWaiter = new Thread(loopWaiter);
            lpWaiter.Start();
            
        }

        private bool VerifyTableLine(GroupClient grp)
        {
            bool OK = false;
            foreach (Tables table in Restaurant.listTables)
            {
                if (grp.assignedTable == table.name)
                {
                    if (table.line == this.lineAssigned)
                    { OK = true;  }
                } 
            }
            return OK;
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
                                // Selon l'étape du repas (entrée plat dessert)
                                switch (grp.stepMeal)
                                {
                                    // Si le groupe :
                                    case 0: // N'a pas commencé à manger
                                        // S'ils ne sont PLUS en train de choisir, n'ont choisi et ne sont pas en train de manger
                                        if (!grp.isChoosingMeal && !grp.isEating && grp.mealChoosen)
                                        {
                                            Display.DisplayMsg("Le " + this.name + " est en train d'apporter l'entrée au " + grp.name + "...", false, false, ConsoleColor.Yellow);
                                            
                                            Thread.Sleep(1000);
                                            grp.stepMeal = 1; // Est rendu à l'entrée
                                            grp.isEating = true; // est en train de manger l'entrée
                                        }

                                        break;
                                    case 1: //  A fini l'entrée
                                        if (!grp.isChoosingMeal && !grp.isEating && grp.mealChoosen)
                                        {
                                            Display.DisplayMsg("Le " + this.name + " est en train d'apporter le plat au " + grp.name + "...", false, false, ConsoleColor.Yellow);
                                            Thread.Sleep(1000);
                                            grp.isEating = true; // est en train de manger l'entrée
                                            grp.stepMeal = 2; // Est rendu à l'entrée
                                        }

                                        break;
                                    case 2: //  A fini le repas principal
                                        if (!grp.isChoosingMeal && !grp.isEating && grp.mealChoosen)
                                        {
                                            Display.DisplayMsg("Le " + this.name + " est en train d'apporter le le dessert au " + grp.name + "...", false, false, ConsoleColor.Yellow);
                                            Thread.Sleep(1000);
                                            grp.isEating = true; // est en train de manger l'entrée
                                            grp.stepMeal = 3; // Est rendu à l'entrée
                                        }

                                        break;
                                    case 3: // A fini le dessert
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
                                            
                                            break;
                                        }
                                        break;
                                    default:
                                        break;


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
