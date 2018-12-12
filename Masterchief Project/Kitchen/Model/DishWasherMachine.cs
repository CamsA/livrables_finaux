using Kitchen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class DishWasherMachine
    {
        private bool isRunning = false;
        private int dirtyCrockeryStack =0;

        public bool IsRunning { get => isRunning; set => isRunning = value; }
        public int DirtyCrockeryStack { get => dirtyCrockeryStack; set => dirtyCrockeryStack = value; }

        public DishWasherMachine()
        {
        }

        public void Wash(int crockeryList)
        {
            if (IsRunning == false)
            {
                if (crockeryList != 0 && crockeryList <= 10)
                {
                    dirtyCrockeryStack -= crockeryList;
                    Kitchen kitchen = Kitchen.GetInstance;
                    kitchen.CleanCrokeryStack += crockeryList;
                    isRunning = true;
                    Console.WriteLine("La machine a laver se lance");
                }
            }
        }
    }
}
