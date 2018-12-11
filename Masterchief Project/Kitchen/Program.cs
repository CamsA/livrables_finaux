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

            //TestsSocketsKitchenToRestaurant();

            //TestsSocketsRestaurantToKitchen();
            
        }

        public static void TestsSocketsKitchenToRestaurant()
        {
            KitchenClientSocket kcs = new KitchenClientSocket();
            Thread.Sleep(3000);
            kcs.SendMessage("CN:2");
            Thread.Sleep(1000);
            kcs.SendMessage("CTC:4");
            Thread.Sleep(1000);
            kcs.SendMessage("RM:12");
            Thread.Sleep(1000);
            kcs.SendMessage("gloubiboulga");

            Console.Read();
        }

        public static void TestsSocketsRestaurantToKitchen()
        {
            KitchenListenerSocket kls = new KitchenListenerSocket();
            Thread.Sleep(3000);
            kls.StartListening();
        }
    }
}
