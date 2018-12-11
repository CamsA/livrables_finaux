using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestaurantRoomConsole.Model;
using RestaurantRoomConsole.View;

namespace RestaurantRoomConsole
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
        private double moyClients;

        public Conntroller()
        {
            display = new Display();
            model = new Modell();
            moyClients = (display.ClientsPerMinutesMaxSG + display.ClientsPerMinutesMinSG) / 2;

            Console.WriteLine("Client par minutes moyenne : {0}", moyClients);
            Thread lctr = new Thread(loopCtr);
            lctr.Start();
        }

        public void loopCtr()
        {
            Console.WriteLine("zf");
            Thread.Sleep(2000);
        }
    }
}