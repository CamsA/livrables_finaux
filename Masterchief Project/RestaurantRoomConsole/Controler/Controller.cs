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
    public class Conntroller
    {
        /// 

        /// The TipCalculatorController class brings together 
        /// the display and the tip or model classes
        /// I use the constructor to instantiate the Display.
        /// Instantiating the Display calls its constructor
        /// which calls the Get input method
        /// Once the input is entered I can instantiate
        /// the Tip class and pass the values from the 
        /// Display class. Notice the dot notation and observe
        /// how the two classes interact
        /// 

        private Modell model;
        private Display display;
        private int countSecondes;
        public ExchangeDesk desk;
        public Conntroller()
        {
            Display.DisplayMsg("Lancement du programme.",false,true,ConsoleColor.White);
            desk = ExchangeDesk.GetInstance;

            countSecondes = 0;

            display = new Display();
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