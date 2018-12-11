using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantRoomConsole.Model;
using System.Threading;

namespace RestaurantRoomConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Options());
            */

            //TestsSocketsKitchenToRestaurant();

            //TestsSocketsRestaurantToKitchen();
        }

        public static void TestsSocketsKitchenToRestaurant()
        {
            RestaurantListenerSocket rls = new RestaurantListenerSocket();
            Thread.Sleep(3000);
            rls.StartListening();
        }

        public static void TestsSocketsRestaurantToKitchen()
        {
            RestaurantClientSocket rcs = new RestaurantClientSocket();
            Thread.Sleep(3000);
            rcs.SendMessage("DN:2");
            Thread.Sleep(1000);
            rcs.SendMessage("DTC:4");
            Thread.Sleep(1000);
            rcs.SendMessage("NO:12");
            Thread.Sleep(1000);
            rcs.SendMessage("DC:5");
            Thread.Sleep(1000);
            rcs.SendMessage("gloubiboulga");

            Console.Read();
        }
    }
}
