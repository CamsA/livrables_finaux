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
        private int dirtyNapkinsStack;
        private int dirtyTableClothesStacks;
        private bool IsRunning;

        public int DirtyNapkinsStacks { get => dirtyNapkinsStack; set => dirtyNapkinsStack = value; }
        public int DirtyTableClothesStacks { get => dirtyTableClothesStacks; set => dirtyTableClothesStacks = value; }
        public bool IsRunning1 { get => IsRunning; set => IsRunning = value; }

        public WashingMachine()
        {
            DirtyNapkinsStacks = 0;
            DirtyTableClothesStacks = 0;
            IsRunning1 = false;
        }

        public void Wash(int napkin, int tableCloth)
        {
            if (IsRunning1 == false)
            {
                if (napkin ==10 && tableCloth == 10)
                {
                    DirtyNapkinsStacks -= 10;
                    DirtyTableClothesStacks -= 10;

                    ExchangeDesk exchangeDesk = ExchangeDesk.GetInstance;
                    exchangeDesk.WaitingDirtyNapkins += 10;
                    exchangeDesk.WaitingDirtyTableClothes += 10;


                    IsRunning1 = true;
                }
            }
        }
    }
}
