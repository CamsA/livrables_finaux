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

            TestsSocketsKitchenToRestaurant();

            Thread.Sleep(3000);

            TestsSocketsRestaurantToKitchen();

            Thread.Sleep(20000);

            RestaurantListenerSocket.CloseSocket();
            RestaurantClientSocket.CloseSocket();
        }

        public static void TestsSocketsKitchenToRestaurant()
        {
            Thread rlsTh = new Thread(RestaurantListenerSocket.Initialize);

            rlsTh.Start();
        }

        public static void TestsSocketsRestaurantToKitchen()
        {
            RestaurantClientSocket.Initialize();

            Thread.Sleep(3000);
            RestaurantClientSocket.SendMessage("DN:2");
            Thread.Sleep(1000);
            RestaurantClientSocket.SendMessage("DTC:4");
            Thread.Sleep(1000);
            RestaurantClientSocket.SendMessage("NO:12");
            Thread.Sleep(1000);
            RestaurantClientSocket.SendMessage("DC:5");
            Thread.Sleep(1000);
            RestaurantClientSocket.SendMessage("gloubiboulga");

            Console.Read();
        }
    }
}
