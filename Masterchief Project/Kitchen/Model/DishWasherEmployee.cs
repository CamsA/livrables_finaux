using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class DishWasherEmployee : MovableEntities
    {
        public DishWasherEmployee()
        { }

        public void TakeAndDeposite(string type, int number)
        {
            switch (type)
            {
                case "Cockery":
                    {
                        ExchangeDesk.GetInstance.WaitingDirtyCrockery -= number;
                        Kitchen.GetInstance.DishMachine.DirtyCrockeryStack += number;
                        break;
                    }
                case "TableCloth":
                    {
                        ExchangeDesk.GetInstance.WaitingDirtyTableClothes -= number;
                        Kitchen.GetInstance.WashingMachine.DirtyTableClothStacks += number;
                        break;
                    }
                case "Napkin":
                    {
                        ExchangeDesk.GetInstance.WaitingDirtyCrockery -= number;
                        Kitchen.GetInstance.WashingMachine.DirtyNapkinStacks += number;
                        break;
                    }
            }
        }
    }
}
