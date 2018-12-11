using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class ExchangeDesk : Entities
    {
        private static ExchangeDesk instance = null;
        private static readonly object padlock = new object();

        private int waitingDirtyCrockery;
        private int waitingDirtyNapkins;
        private int waitingDirtyTableClothes;
        private List<int> waitingOrders;

        public int WaitingDirtyCrockery { get => waitingDirtyCrockery; set => waitingDirtyCrockery = value; }
        public int WaitingDirtyNapkins { get => waitingDirtyNapkins; set => waitingDirtyNapkins = value; }
        public int WaitingDirtyTableClothes { get => waitingDirtyTableClothes; set => waitingDirtyTableClothes = value; }
        internal List<int> WaitingOrders { get => waitingOrders; set => waitingOrders = value; }


        private ExchangeDesk()
        { }

        public static ExchangeDesk GetInstance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ExchangeDesk();
                    }
                    return instance;
                }
            }
        }

        public void AddWaitingOrder(int idMeal)
        {
            this.WaitingOrders.Add(idMeal);
        }

        public void AddDirtyObject(string type, int number)
        {
            switch (type)
            {
                case "Crockery":
                    this.WaitingDirtyCrockery += number;
                    break;
                case "Napkins":
                    this.WaitingDirtyNapkins += number;
                    break;
                case "TableClothes":
                    this.WaitingDirtyTableClothes += number;
                    break;
                default:
                    Console.Write("Error on the kitchen exchange desk\n");
                    break;
            }
        }
    }
}
