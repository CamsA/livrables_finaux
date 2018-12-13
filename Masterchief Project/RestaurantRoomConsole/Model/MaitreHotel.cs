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
        public MaitreHotel(String _name)
        {
            this.name = _name;
            Thread thmh = new Thread(loopMh);
            thmh.Start();


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
                grp.thmealchoose.Abort();
                grp.theat.Abort();

                Thread.Sleep(1000);
                Display.DisplayMsg("Le " + grp.name + " vient de quitter le restaurant.", true, true, ConsoleColor.White);

            }
        }
        public void loopMh()
        {
            while (true)
            {
                foreach(GroupClient grp in Restaurant.listGroupClient.ToList())
                {
                    if(grp.stepMeal==3)
                    {
                        deleteGroupClient(grp);
                    }
                }

                if (Restaurant.listTables.Find(item => item.isOccuped == false) != null)
                {
                    if (Restaurant.listTables.Find(item => item.isReserved == false) != null)
                    {
                        foreach (GroupClient grp in Restaurant.listGroupClient)
                        {
                            if (grp.isWaitingATable && grp.hasReserved==false)
                            {
                                foreach (Tables table in Restaurant.listTables)
                                {
                                    if (!table.isOccuped && !table.isReserved)
                                    {
                                        table.isOccuped = true;
                                        grp.isWaitingATable = false;
                                        grp.assignedTable = table.name;
                                        table.groupAssigned = grp.name;
                                        break;
                                    }
                                }
                                break;
                            }
                            else if(grp.hasReserved == true)
                            {
                                foreach (Tables table in Restaurant.listTables)
                                {
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

