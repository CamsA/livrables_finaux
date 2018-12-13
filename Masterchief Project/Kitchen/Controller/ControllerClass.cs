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
        private View.Display display;
        private int countSeconds;
        public ExchangeDesk desk;

        public ControllerClass()
        {
            Display.DisplayMsg("Lancement de la cuisine", false, true, ConsoleColor.Green);
            desk = ExchangeDesk.GetInstance;

            countSeconds = 0;

            Display display = new Display();
            Model.Kitchen kitchen = Model.Kitchen.GetInstance;

            //Thread thlp = new Thread(loopCtr);
            //thlp.Start();
        }
    }
}
