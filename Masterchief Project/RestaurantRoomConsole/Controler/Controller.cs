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

        public Conntroller()
        {
            
            countSecondes = 0;

            display = new Display();
            model = new Modell();
        }

        public void threadLoopController()
        {

        }

        /*public void loopCtr()
        {
            while (true)
            {
                
                foreach(List<String> list in Parameters.listGroupClientReserved)
                {
                    if(countSecondes==int.Parse(list[2]))
                    {
                      //  foreach (Restaurant.listGroupClient
                    }
                }
                Thread.Sleep(1000);
                
                countSecondes++;
            }
        }*/
    }
}