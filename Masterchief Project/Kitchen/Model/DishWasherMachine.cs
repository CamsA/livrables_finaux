using Kitchen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class DishWasherMachine
    {
        private int dirtyCrockeryStack = 0;

        public int DirtyCrockeryStack { get => dirtyCrockeryStack; set => dirtyCrockeryStack = value; }

        public DishWasherMachine()
        {
            this.DirtyCrockeryStack = 0;
        }

        public void Wash()
        {
            int dirtyCrockeryToWash = 0;

            if (this.DirtyCrockeryStack >= 24)
            {
                DirtyCrockeryStack = 24;
                this.DirtyCrockeryStack -= 24;

            }
            else if (this.DirtyCrockeryStack < 24)
            {
                dirtyCrockeryToWash = this.DirtyCrockeryStack;
                this.DirtyCrockeryStack = 0;
            }

            View.Display.DisplayMsg("La machine est lancée avec " + dirtyCrockeryToWash + " plat(s) sale(s)", false, true, ConsoleColor.DarkBlue);

            Thread.Sleep(10000);

            ExchangeDesk exchangeDesk = ExchangeDesk.GetInstance;
            exchangeDesk.SendCleanObject("Crockery", dirtyCrockeryToWash);
        }

        public void Run()
        {
            while (true)
            {
                this.Wash();
            }
        }
    }
}
