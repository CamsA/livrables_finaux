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
        private int waitingDirtyNapkin;
        private int waitingDirtyTableClothes;
        private List<Meal> waitingOrders;

        public int WaitingDirtyCrockery { get => waitingDirtyCrockery; set => waitingDirtyCrockery = value; }
        public int WaitingDirtyNapkin { get => waitingDirtyNapkin; set => waitingDirtyNapkin = value; }
        public int WaitingDirtyTableClothes { get => waitingDirtyTableClothes; set => waitingDirtyTableClothes = value; }
        internal List<Meal> WaitingOrders { get => waitingOrders; set => waitingOrders = value; }


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

    }
}
