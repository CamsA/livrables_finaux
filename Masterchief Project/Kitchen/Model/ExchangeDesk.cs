using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class ExchangeDesk
    {
        // Static instance to create the Singleton
        private static ExchangeDesk instance = null;
        private static readonly object padlock = new object();

        // Various stacks of equipments and orders waiting to be read by the chef
        private int waitingDirtyCrockery = 0;
        private int waitingDirtyNapkins = 0;
        private int waitingDirtyTableClothes = 0;
        private List<int> waitingOrders = new List<int>();

        // Getters and Setters for the stacks
        public int WaitingDirtyCrockery { get => waitingDirtyCrockery; set => waitingDirtyCrockery = value; }
        public int WaitingDirtyNapkins { get => waitingDirtyNapkins; set => waitingDirtyNapkins = value; }
        public int WaitingDirtyTableClothes { get => waitingDirtyTableClothes; set => waitingDirtyTableClothes = value; }
        internal List<int> WaitingOrders { get => waitingOrders; set => waitingOrders = value; }

        // Private constructor
        private ExchangeDesk()
        { }

        // Instanciation and transmission of the instance via a Singleton
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

        // Add an order to the queue
        public void AddWaitingOrder(int idMeal)
        {
            this.WaitingOrders.Add(idMeal);
        }

        // Add a dirty equipment to the stacks
        public void AddDirtyObject(string type, int quantity)
        {
            switch (type)
            {
                case "Crockery":
                    this.WaitingDirtyCrockery += quantity;
                    break;
                case "Napkins":
                    this.WaitingDirtyNapkins += quantity;
                    break;
                case "TableClothes":
                    this.WaitingDirtyTableClothes += quantity;
                    break;
                default:
                    View.Display.DisplayMsg("Erreur lors de l'ajout d'un objet sale au stock : " + type, false, true, ConsoleColor.Red);
                    break;
            }
        }

        // Send clean equipment to the restaurant room
        public void SendCleanObject(string type, int quantity)
        {
            switch (type)
            {
                case "Napkins":
                        KitchenClientSocket.SendMessage("CN:" + quantity);
                    break;
                case "TableClothes":
                        KitchenClientSocket.SendMessage("CTC:" + quantity);
                    break;
                default :
                    View.Display.DisplayMsg("Erreur : objet inconnu à envoyer à la salle : " + type, false, true, ConsoleColor.Red);
                    break;
            }
        }

        // Send a prepared meal to the restaurant room
        public void SendPreparedMeal(int idMeal)
        {
            KitchenClientSocket.SendMessage("RM:" + idMeal);
        }
    }
}
