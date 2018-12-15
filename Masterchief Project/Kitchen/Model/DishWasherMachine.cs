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
        public DishWasherMachine()
        {
            this.DirtyCrockeryStack = 0;
        }

        // Stack where dirty crockery is put waiting to be washed
        private int dirtyCrockeryStack;

        public int DirtyCrockeryStack { get => dirtyCrockeryStack; set => dirtyCrockeryStack = value; }

        // Wash 24 units of dirty crockery, lasts for 15 seconds
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

            View.Display.DisplayMsg("Le lave-vaisselle est lancé avec " + dirtyCrockeryToWash + " plat(s) sale(s)", false, true, ConsoleColor.DarkBlue);

            Thread.Sleep(10000);

            Kitchen kitchen = Kitchen.GetInstance;
            kitchen.CleanCrokeryStack += dirtyCrockeryToWash;

            View.Display.DisplayMsg("Le lave-vaisselle a lavé " + dirtyCrockeryToWash + " plat(s) sale(s) qui ont été ajoutés au stock de la cuisine", false, true, ConsoleColor.DarkBlue);
        }

        public void Run()
        {
            while (true)
            {
                if(this.DirtyCrockeryStack > 0)
                {
                    this.Wash();
                }
                Thread.Sleep(500);
            }
        }
    }
}
