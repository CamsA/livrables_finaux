using RestaurantRoomConsole.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantRoomConsole.Model
{
    public class ChefDeRang
    {
        public int rangAssigned;
        public String name;

        public ChefDeRang(String _name, int _rangAssigned)
        {
            this.rangAssigned = _rangAssigned;
            this.name = _name;

            Thread lpChefDeRang = new Thread(loopChefDeRang);
            lpChefDeRang.Start();

        }

        private bool VerifyTable(GroupClient grp)
        {
            bool OK = false;
            foreach (Tables table in Restaurant.listTables)
            {
                if (grp.assignedTable == table.name)
                {
                    if (table.rang == this.rangAssigned)
                    {
                        // Verifi si la table a une nappe propre et des serviettes
                        ExchangeDesk desk = ExchangeDesk.GetInstance;
                        if (!table.cleanTableClothes && !table.hasTableClothes)
                        {
                            if (desk.CleanTableClothes > 0)
                            {
                                desk.CleanTableClothes--;
                                table.cleanTableClothes = true;
                                table.hasTableClothes = true;
                                Display.DisplayMsg("Le " + this.name + " met 1 nappe propre pour la " + table.name, false, false, ConsoleColor.DarkGray);
                            }
                            else
                            {
                                Display.DisplayMsg("Il n'y a plus de nappe propre dans la salle de restaurant pour " + table.name + " !", true, true, ConsoleColor.Red);
                            }
                        }
                        if (!table.cleanNapkins && table.nbrNapkins == 0)
                        {
                            if (desk.CleanNapkins >= table.size)
                            {
                                desk.CleanNapkins -= grp.size;
                                table.nbrNapkins = grp.size;

                                table.cleanNapkins = true;
                                table.hasNapkins = true;

                                Display.DisplayMsg("Le "+this.name+" met "+table.size+" serviettes propres pour la "+table.name, false, false, ConsoleColor.DarkGray);
                            }
                            else
                            {
                                Display.DisplayMsg("Il n'y a plus de serviette propre dans le restaurant pour" + table.name + " !", true, true, ConsoleColor.Red);
                            }
                        }
                        OK = true;
                    }
                }
            }
            return OK;
        }


        public void loopChefDeRang()
        {
            while (true)
            {
                // DONNER LA CARTE 

                if (Restaurant.listGroupClient.Count != 0)
                {
                    foreach (GroupClient grp in Restaurant.listGroupClient.ToList())
                    {
                        if (VerifyTable(grp))
                        {
                                                        // Si le group n'est pas en train de manger, n'est en attente d'une table (donc est assis),
                            // N'a pas reservé (renforcement), est bien assigné à une table (renforcement) :
                            if (grp.isEating == false && grp.isWaitingATable == false && grp.hasReserved == false && grp.assignedTable != "" && grp.stepMeal == 0)
                            {
                                // Selon l'étape du repas (entrée plat dessert)
                                // S'ils ne sont pas en train de choisir, n'ont pas encore choisi et ne sont pas en train de manger
                                if (!grp.isChoosingMeal && !grp.isEating && !grp.mealChoosen)
                                {
                                    Display.DisplayMsg("Le " + this.name + " donne la carte au " + grp.name, true, true, ConsoleColor.Cyan);
                                    grp.isChoosingMeal = true;
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
