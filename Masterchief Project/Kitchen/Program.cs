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
            KitchenClientSocket.Initialize();
            Thread.Sleep(3000);
            KitchenClientSocket.SendMessage("CN:2");
            Thread.Sleep(1000);
            KitchenClientSocket.SendMessage("CTC:4");
            Thread.Sleep(3000);
            KitchenClientSocket.SendMessage("RM:12");
            Thread.Sleep(3000);
            KitchenClientSocket.SendMessage("gloubiboulga");

            Console.Read();
        }

        public static void TestsSocketsRestaurantToKitchen()
        {

            Thread klsTh = new Thread(KitchenListenerSocket.Initialize);



            klsTh.Start();


        }
    }
}
