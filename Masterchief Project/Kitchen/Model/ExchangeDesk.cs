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

        public void AddWaitingOrder(int idOrder)
        {
            this.WaitingOrders.Add(idOrder);
        }

        public void AddDirtyCrockery(int number)
        {
            this.WaitingDirtyCrockery += number;
        }

        public void AddDirtyNapkins(int number)
        {
            this.WaitingDirtyNapkins += number;
        }

        public void AddDirtyTableClothes(int number)
        {
            this.WaitingDirtyTableClothes += number;
        }

    }
}
