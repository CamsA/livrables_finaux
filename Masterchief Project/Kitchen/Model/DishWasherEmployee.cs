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
        private DishWasherMachine dishwasherMachine;
        private WashingMachine washingMachine;

        public DishWasherEmployee()
        {
            // The employee prepare the two machines at the start of the service
            this.dishwasherMachine = new DishWasherMachine();
            Thread dishwasherMachineThread = new Thread(dishwasherMachine.Run);
            dishwasherMachineThread.Start();

            this.washingMachine = new WashingMachine();
            Thread washingMachineThread = new Thread(washingMachine.Run);
            washingMachineThread.Start();
        }

        // Takes the dirty objects from the exchange desk to take care of them
        public void MoveDirtyObjects()
        {
            Kitchen kitchen = Kitchen.GetInstance;
            ExchangeDesk exchangeDesk = ExchangeDesk.GetInstance;
           
            // Puts dirty crockery in the dishwasher machine
            if(exchangeDesk.WaitingDirtyCrockery > 0)
            {
                int quantityMovedCrockery = exchangeDesk.WaitingDirtyCrockery;

                exchangeDesk.WaitingDirtyCrockery = 0;
                this.dishwasherMachine.DirtyCrockeryStack += quantityMovedCrockery;
                View.Display.DisplayMsg("Le plongeur a pris " + quantityMovedCrockery + " plat(s) sale(s) pour le(s) mettre dans le lave-vaisselle", false, false, ConsoleColor.DarkGray);
            }

            // Puts dirty table clothes in the washing machine
            if (exchangeDesk.WaitingDirtyTableClothes > 0)
            {
                int quantityMovedTableClothes = exchangeDesk.WaitingDirtyTableClothes;

                exchangeDesk.WaitingDirtyTableClothes = 0;
                this.washingMachine.DirtyTableClothesStacks += quantityMovedTableClothes;
                View.Display.DisplayMsg("Le plongeur a pris " + quantityMovedTableClothes + " nappes pour les mettre au lave-linge", false, false, ConsoleColor.Blue);
            }

            // Puts dirty napkins in the washing machine
            if (exchangeDesk.WaitingDirtyNapkins > 0)
            {
                int quantityMovedNapkins = exchangeDesk.WaitingDirtyNapkins;

                exchangeDesk.WaitingDirtyNapkins = 0;
                this.washingMachine.DirtyNapkinsStacks += quantityMovedNapkins;
                View.Display.DisplayMsg("Le plongeur a pris " + quantityMovedNapkins + " serviette pour les mettre au lave-linge", false, false, ConsoleColor.Blue);
            }     
        }

        // Comportemental method
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
