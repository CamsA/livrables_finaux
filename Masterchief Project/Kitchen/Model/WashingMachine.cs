using Kitchen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{

    public class WashingMachine : Entities
    {
        private int dirtyNapkinStack;
        private int dirtyTableClothStacks;
        private bool IsRunning;

        public int DirtyNapkinStacks { get => dirtyNapkinStack; set => dirtyNapkinStack = value; }
        public int DirtyTableClothStacks { get => dirtyTableClothStacks; set => dirtyTableClothStacks = value; }
        public bool IsRunning1 { get => IsRunning; set => IsRunning = value; }

        public WashingMachine()
        {
            DirtyNapkinStacks = 0;
            DirtyTableClothStacks = 0;
            IsRunning1 = false;
        }

        public void Wash(int napkin, int tableCloth)
        {
            if (IsRunning1 == false)
            {
                if (napkin ==10 && tableCloth == 10)
                {
                    DirtyNapkinStacks -= 10;
                    DirtyTableClothStacks -= 10;

                    ExchangeDesk exchangeDesk = new ExchangeDesk();
                    exchangeDesk.WaitingDirtyNapkin += 10;
                    exchangeDesk.WaitingDirtyTableClothes += 10;


                    IsRunning1 = true;
                }
            }
        }
    }
}
