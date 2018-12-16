using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestaurantRoomConsole.Model;
using RestaurantRoomConsole.View;

namespace RestaurantRoomConsole.Controler
{
    public class ControllerClass
    {
        private Modell model;
        private Display display;
        private int countSecondes;
        public ExchangeDesk desk;
        public ControllerClass()
        {
            display = new Display();

            Display.DisplayMsg("Lancement du programme.",false,true,ConsoleColor.White);

            DBConnect.Start("MasterChiefDB");
            SQLprocess.Start();

            // Initialize the restaurant room sockets
            Thread restaurantListenerThread = new Thread(RestaurantListenerSocket.Initialize);
            restaurantListenerThread.Start();
            RestaurantClientSocket.Initialize();
            
            desk = ExchangeDesk.GetInstance;

            countSecondes = 0;

            model = new Modell();

            Thread thlp = new Thread(loopCtr);
            thlp.Start();
        }

        public void threadLoopController()
        {

        }

        public void loopCtr()
        {
            while (true)
            {

                if (Parameters.listGroupClientReserved.Count != 0)
                {
                    foreach (List<String> list in Parameters.listGroupClientReserved.ToList())
                    {
                        if (Parameters.listGroupClientReserved.Count != 0)
                        {
                            if (countSecondes == int.Parse(list[2]))
                            {
                                Display.DisplayMsg("Le " + list[0] + " qui avait réservé vient d'arriver ! (au bout de "+list[2]+" secondes) !", true, true, ConsoleColor.DarkCyan);
                                

                                foreach (Tables table in Restaurant.listTables)
                                {
                                    if (table.isReserved == true)
                                    {
                                        GroupClient group = new GroupClient(list[0], int.Parse(list[1]), true);
                                        group.theat.Start();
                                        Modell.listThreads.Add(group.theat);
                                        //list.RemoveAll(c => list[0] == list[0]);
                                        break;
                                    }
                                }
                            }
                        }
                        else { break; }
                    }
                }
                Thread.Sleep(1000);
                
                countSecondes++;
            }
        }
    }
}