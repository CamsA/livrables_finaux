using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kitchen.Model;
using Kitchen.View;

namespace Kitchen.Controller
{
    class ControllerClass
    {
        private Model.Kitchen kitchen;
        public ExchangeDesk exchangeDesk;

        public ControllerClass()
        {
            // Connect the Kitchen to the database
            DBConnect.Start("MasterchiefDB");
            SQLprocess.Start();

            // Initialize the kitchen sockets
            Thread kitchenListenerThread = new Thread(KitchenListenerSocket.Initialize);
            kitchenListenerThread.Start();
            KitchenClientSocket.Initialize();

            // Initialize the Kitchen
            Display.DisplayMsg("Démarrage du service en cuisine", false, true, ConsoleColor.Green);
            this.exchangeDesk = ExchangeDesk.GetInstance;
            this.kitchen = Model.Kitchen.GetInstance;

            this.GetStaffToWork();

            for (int i = 1; i < 30; i++)
            {
                this.exchangeDesk.AddWaitingOrder(i);
            }

            


            while(true)
            {
                Thread.Sleep(5000);
            }
        }

        // Launches all the employees comportemental threads
        private void GetStaffToWork()
        {
            // The Chef gets to work
            Chef GordonRamsay = new Chef();
            Thread GordonRamsayThread = new Thread(GordonRamsay.Work);
            GordonRamsayThread.Start();

            // The DishwasherEmployee ("plongeur" in French) gets to work
            DishWasherEmployee commandantCousteau = new DishWasherEmployee();
            Thread commandantCousteauThread = new Thread(commandantCousteau.Work);
            commandantCousteauThread.Start();
        }
    }
}
