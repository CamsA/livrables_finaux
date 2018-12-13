using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class DishWasherEmployee
    {
        public DishWasherEmployee()
        { }

        public void MoveDirtyObjects()
        {
            Kitchen kitchen = Kitchen.GetInstance;
            ExchangeDesk exchangeDesk = ExchangeDesk.GetInstance;
           
            if(exchangeDesk.WaitingDirtyCrockery != 0)
            {
                int quantityMovedCrockery = exchangeDesk.WaitingDirtyCrockery;
                exchangeDesk.WaitingDirtyCrockery = 0;
                kitchen.DishMachine.DirtyCrockeryStack += quantityMovedCrockery;
                Console.Write("Le plongeur a pris des plats sale pour les mettre a la machine a laver");
            }

            if (exchangeDesk.WaitingDirtyTableClothes != 0)
            {

                int quantityMovedTableClothes = exchangeDesk.WaitingDirtyTableClothes;

                exchangeDesk.WaitingDirtyTableClothes = 0;
                kitchen.WashingMachine.DirtyTableClothesStacks += quantityMovedTableClothes;

                Console.Write("Le plongeur a pris des nappes pour les mettre aux lave-linges");
            }

            if (exchangeDesk.WaitingDirtyNapkins != 0)
            {
                int quantityMovedNapkins = exchangeDesk.WaitingDirtyNapkins;

                exchangeDesk.WaitingDirtyNapkins = 0;
                kitchen.WashingMachine.DirtyNapkinsStacks += quantityMovedNapkins;
                Console.Write("Le plongeur a pris des servitesse pour les mettre aux lave-linges");
            }     
        }

        public void Work()
        {
            while(true)
            {
                this.MoveDirtyObjects();

                Thread.Sleep(100);
            }
        }
    }
}
