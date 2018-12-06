using Kitchen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen
{
    public class DishWasherMachine : Entities
    {
        private bool isRunning;
        private int dirtyCrokeryStack;

        public bool IsRunning { get => isRunning; set => isRunning = value; }
        public int DirtyCrokeryStack { get => dirtyCrokeryStack; set => dirtyCrokeryStack = value; }

        public DishWasherMachine()
        {
            IsRunning = false;
            DirtyCrokeryStack = 0;
        }

        public void Wash(int crokeryList)
        {
            DirtyCrokeryStack = crokeryList;
            if (this.IsRunning == false)
            {
                if (crokeryList != 0 && crokeryList <= 10)
                {
                    dirtyCrokeryStack -= 10;
                    
                }
                
            }
            this.isRunning = true;
        }
    }
}
