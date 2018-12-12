using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kitchen.Model;
using System.Threading;

namespace Kitchen
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new kitchenForm());
            */

            TestsSocketsRestaurantToKitchen();

            Thread.Sleep(3000);

            TestsSocketsKitchenToRestaurant();



            Thread.Sleep(20000);

            KitchenClientSocket.CloseSocket();
            KitchenListenerSocket.CloseSocket();
        }

        public static void TestsSocketsKitchenToRestaurant()
        {
            ExchangeDesk eD = ExchangeDesk.GetInstance;

            KitchenClientSocket.Initialize();

            Thread.Sleep(3000);
            eD.SendCleanObject("Napkins", 12);
            Thread.Sleep(1000);
            eD.SendCleanObject("TableClothes", 5);
            Thread.Sleep(1000);
            eD.SendPreparedMeal(12);
            Thread.Sleep(1000);
            eD.SendCleanObject("gloubiboulga", 5);
            Thread.Sleep(3000);

            Console.WriteLine("Serviettes sales : " + eD.WaitingDirtyNapkins);
            Console.WriteLine("Nappes sales : " + eD.WaitingDirtyTableClothes);
            Console.WriteLine("Vaiselle sale : " + eD.WaitingDirtyCrockery);
            Console.WriteLine("Commande(s) en attente : " + eD.WaitingOrders.First());

            for(int i=0; i < 100; i++)
            {
                eD.SendCleanObject("TableClothes", 5);
            }

            Console.Read();
        }

        public static void TestsSocketsRestaurantToKitchen()
        {

            Thread klsTh = new Thread(KitchenListenerSocket.Initialize);



            klsTh.Start();


        }
    }
}
