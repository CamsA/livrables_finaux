using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class DishWasherEmployee
    {
        public DishWasherEmployee()
        { }

        public void TakeAndDeposite(string type, int number)
        {
            Kitchen kitchen = Kitchen.GetInstance;
            ExchangeDesk exchangeDesk = ExchangeDesk.GetInstance;
            switch (type)
            {
                case "Cockery":
                    {
                        exchangeDesk.WaitingDirtyCrockery -= number;
                        kitchen.DishMachine.DirtyCrockeryStack += number;
                        Console.Write("Le plongeur a pris des plats sale pour les mettre a la machine a laver");
                        break;
                    }
                case "TableCloth":
                    {
                        exchangeDesk.WaitingDirtyTableClothes -= number;
                        kitchen.WashingMachine.DirtyTableClothesStacks += number;
                        Console.Write("Le plongeur a pris des nappes pour les mettre aux lave-linges");
                        break;
                    }
                case "Napkin":
                    {
                        exchangeDesk.WaitingDirtyNapkins -= number;
                        kitchen.WashingMachine.DirtyNapkinsStacks += number;
                        Console.Write("Le plongeur a pris des servitesse pour les mettre aux lave-linges");
                        break;
                    }
            }
        }
    }
}
