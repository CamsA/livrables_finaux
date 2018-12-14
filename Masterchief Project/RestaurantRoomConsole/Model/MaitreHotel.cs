using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestaurantRoomConsole.View;
namespace RestaurantRoomConsole.Model
{
    public class MaitreHotel
    {
        public String name;
        public Thread thmh;
        public MaitreHotel(String _name)
        {
            this.name = _name;
            thmh = new Thread(loopMh);
            


        }

        private void deleteGroupClient(GroupClient grp)
        {
            if (!grp.isChoosingMeal && !grp.isEating && grp.mealChoosen)
            {
                Display.DisplayMsg("Le " + grp.name + " a fini de manger !", true, true, ConsoleColor.DarkBlue);
                Display.DisplayMsg("Le " + grp.name + " est en train de payer avec le " + this.name + " !", true, true, ConsoleColor.Magenta);
                

                // On trouve la table assigné aux clients qui viennent de finir de manger
                var tbl = Restaurant.listTables.FindIndex(c => c.groupAssigned == grp.name);

                // On met la met à libre et aucun groupe assigné
                Restaurant.listTables[tbl].isOccuped = false;
                Restaurant.listTables[tbl].groupAssigned = "";

                // On supprime le client de la liste des client
                Restaurant.listGroupClient.RemoveAll(c => c.name == grp.name);

                // On arrete les thread de l'objet du groupe pour éviter de manger de la mémoire pour rien
                
                grp.theat.Abort();

                Thread.Sleep(1000);
                Display.DisplayMsg("Le " + grp.name + " vient de quitter le restaurant.", true, true, ConsoleColor.White);

            }
        }
        public void loopMh()
        {
            while (true)
            {
                // Pour chaque groupes de client du restaurant
                foreach(GroupClient grp in Restaurant.listGroupClient.ToList())
                {
                    // Si un groupe a fini de manger
                    if(grp.stepMeal==3)
                    {
                        // On le supprime
                        deleteGroupClient(grp);
                    }
                }

                // Si au moins un table n'est pas occupée
                if (Restaurant.listTables.Find(item => item.isOccuped == false) != null)
                {
                    // Si au moins un table n'est pas reservée
                    if (Restaurant.listTables.Find(item => item.isReserved == false) != null)
                    {
                        // Pour chaque groupe de client
                        foreach (GroupClient grp in Restaurant.listGroupClient)
                        {
                            // Si ce groupe n'a pas réservé et attends une table
                            if (grp.isWaitingATable && grp.hasReserved==false)
                            {
                                foreach (Tables table in Restaurant.listTables)
                                {
                                    // Si parmis les tables, une n'est pas occupée ni reservée
                                    if (!table.isOccuped && !table.isReserved)
                                    {
                                        // On assigne ce groupe à la table correspondante
                                        table.isOccuped = true;
                                        grp.isWaitingATable = false;
                                        grp.assignedTable = table.name;
                                        table.groupAssigned = grp.name;
                                        break;
                                    }
                                }
                                break;
                            }
                            // Sinon si le groupe a réservé à l'avance
                            else if(grp.hasReserved == true)
                            {
                                foreach (Tables table in Restaurant.listTables)
                                {
                                    // On assigne ce groupe a une des tables 
                                    if (table.isReserved)
                                    {
                                        table.isReserved = false;
                                        table.isOccuped = true;
                                        grp.isWaitingATable = false;
                                        grp.hasReserved = false;
                                        grp.assignedTable = table.name;
                                        table.groupAssigned = grp.name;
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
                

                Thread.Sleep(200);
                }
            }

        }
    }

