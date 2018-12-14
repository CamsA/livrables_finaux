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
        private Display display;
        private Model.Kitchen kitchen;
        public ExchangeDesk desk;

        private int countSeconds = 0;


        public ControllerClass()
        {
            Display.DisplayMsg("Démarrage du service en cuisine", false, true, ConsoleColor.Green);
            ExchangeDesk exchangedesk = ExchangeDesk.GetInstance;

            Thread kitchenListenerThread = new Thread(KitchenListenerSocket.Initialize);
            kitchenListenerThread.Start();
            Thread kitchenClientThread = new Thread(KitchenClientSocket.Initialize);
            kitchenClientThread.Start();

            DBConnect.Start("MasterchiefDB");
            SQLprocess.Start();

            Model.Kitchen kitchen = Model.Kitchen.GetInstance;

            this.GetStaffToWork();

            Console.Read();
            
        }

        private void GetStaffToWork()
        {
            Chef JeanPierreCoffe = new Chef();
            Thread JeanPierreCoffeThread = new Thread(JeanPierreCoffe.Work);
            JeanPierreCoffeThread.Start();

            DishWasherEmployee commandantCousteau = new DishWasherEmployee();
            Thread commandantCousteauThread = new Thread(commandantCousteau.Work);
            commandantCousteauThread.Start();


        }
    }
}
