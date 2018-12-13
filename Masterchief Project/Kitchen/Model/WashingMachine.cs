using Kitchen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kitchen.Model
{

    public class WashingMachine
    {
        // Represents the amounts of dirty napkins and dirty clothes stored next to the washing machine, ready to get washed
        private int dirtyNapkinsStack;
        private int dirtyTableClothesStacks;

        public int DirtyNapkinsStacks { get => dirtyNapkinsStack; set => dirtyNapkinsStack = value; }
        public int DirtyTableClothesStacks { get => dirtyTableClothesStacks; set => dirtyTableClothesStacks = value; }

        public WashingMachine()
        {
            // By default there is no dirty textile in the stacks
            DirtyNapkinsStacks = 0;
            DirtyTableClothesStacks = 0;
        }

        public void Wash()
        {
            int tableClothesToWash = 0;
            int napkinsToWash = 0;

            // If there's more than 10 items waiting to get washed, the dishwasher employee puts only ten in the machine
            if (this.DirtyTableClothesStacks >= 10)
            {
                tableClothesToWash = 10;
                this.DirtyTableClothesStacks -= 10;

            } else if(this.DirtyTableClothesStacks < 10)
            {
                tableClothesToWash = this.DirtyTableClothesStacks;
                this.DirtyTableClothesStacks = 0;
            }

            // If there's less than 10 items waiting to get washed, the dishwasher employee puts all of them in the machine
            if (this.DirtyNapkinsStacks >= 10)
            {
                napkinsToWash = 10;
                this.DirtyNapkinsStacks -= 10;

            }
            else if (this.DirtyNapkinsStacks < 10)
            {
                napkinsToWash = this.DirtyNapkinsStacks;
                this.DirtyNapkinsStacks = 0;
            }

            View.Display.DisplayMsg("La machine à laver est lancée avec " + napkinsToWash + " serviette(s) et " + tableClothesToWash + " nappe(s) de table", false, true, ConsoleColor.DarkBlue);

            // The machine is running for 15 minutes
            Thread.Sleep(15000);

            // Then the dishwasher employee takes the washed textiles and carry them to the exchange desk
            ExchangeDesk exchangeDesk = ExchangeDesk.GetInstance;
            exchangeDesk.SendCleanObject("Napkins", tableClothesToWash);
            exchangeDesk.SendCleanObject("TableClothes", napkinsToWash);

            View.Display.DisplayMsg("La machine à laver a terminé son cycle. " + napkinsToWash + " serviette(s) et " + tableClothesToWash + " nappe(s) de table ont été lavées", false, true, ConsoleColor.DarkBlue);

        }

        public void Run()
        {
            while(true)
            {
                this.Wash();
            }
        }
    }
}
