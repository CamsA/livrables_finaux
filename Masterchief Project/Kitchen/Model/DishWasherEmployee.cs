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
        {
            DishWasherMachine dishwasherMachine = new DishWasherMachine();
            Thread dishwasherMachineThread = new Thread(dishwasherMachine.Run);
            dishwasherMachineThread.Start();

            WashingMachine washingMachine = new WashingMachine();
            Thread washingMachineThread = new Thread(washingMachine.Run);
            washingMachineThread.Start();
        }

        // prend les objets du comptoire d'échange pour les mettre dans la cuisine
        // les objets sont a nettoyers
        public void MoveDirtyObjects()
        {
            Kitchen kitchen = Kitchen.GetInstance;
            ExchangeDesk exchangeDesk = ExchangeDesk.GetInstance;
           
            //lave-vaiselle
            if(exchangeDesk.WaitingDirtyCrockery != 0)
            {
                int quantityMovedCrockery = exchangeDesk.WaitingDirtyCrockery;

                exchangeDesk.WaitingDirtyCrockery = 0;
                kitchen.DishwasherMachine.DirtyCrockeryStack += quantityMovedCrockery;
                View.Display.DisplayMsg("Le plongeur a pris " + quantityMovedCrockery + " plat(s) sale(s) pour le(s) mettre dans le lave-vaisselle", false, true, ConsoleColor.White);
            }

            //lave-linge des nappes
            if (exchangeDesk.WaitingDirtyTableClothes != 0)
            {
                int quantityMovedTableClothes = exchangeDesk.WaitingDirtyTableClothes;

                exchangeDesk.WaitingDirtyTableClothes = 0;
                kitchen.WashingMachine.DirtyTableClothesStacks += quantityMovedTableClothes;
                View.Display.DisplayMsg("Le plongeur a pris " + quantityMovedTableClothes + " nappes pour les mettre au lave-linge", false, true, ConsoleColor.White);
            }

            //lave-linge des serviettes
            if (exchangeDesk.WaitingDirtyNapkins != 0)
            {
                int quantityMovedNapkins = exchangeDesk.WaitingDirtyNapkins;

                exchangeDesk.WaitingDirtyNapkins = 0;
                kitchen.WashingMachine.DirtyNapkinsStacks += quantityMovedNapkins;
                View.Display.DisplayMsg("Le plongeur a pris " + quantityMovedNapkins + " serviette pour les mettre au lave-linge", false, true, ConsoleColor.White);
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
