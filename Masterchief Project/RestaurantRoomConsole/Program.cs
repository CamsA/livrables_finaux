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
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Options());

           /* TestsSocketsKitchenToRestaurant();

            Thread.Sleep(3000);

            TestsSocketsRestaurantToKitchen();

            Thread.Sleep(20000);

            RestaurantListenerSocket.CloseSocket();
            RestaurantClientSocket.CloseSocket();*/
        }

        public static void TestsSocketsKitchenToRestaurant()
        {
            Thread rlsTh = new Thread(RestaurantListenerSocket.Initialize);

            rlsTh.Start();
        }

        public static void TestsSocketsRestaurantToKitchen()
        {
            ExchangeDesk eD = ExchangeDesk.GetInstance;

            RestaurantClientSocket.Initialize();

            Thread.Sleep(3000);
            eD.SendDirtyObject("Napkins", 6);
            Thread.Sleep(1000);
            eD.SendDirtyObject("TableClothes", 2);
            Thread.Sleep(1000);
            eD.SendDirtyObject("Crockery", 22);
            Thread.Sleep(1000);
            eD.SendOrder(14);
            Thread.Sleep(3000);

            Console.WriteLine("Serviettes propres :" + eD.CleanNapkins);
            Console.WriteLine("Nappes propres :" + eD.CleanTableClothes);
            Console.WriteLine("Plat(s) prêt(s) : " + eD.PreparedMeals.First());


            Thread th1 = new Thread(SendOverflow);
            Thread th2 = new Thread(SendOverflow);
            Thread th3 = new Thread(SendOverflow);
            Thread th4 = new Thread(SendOverflow);

            th1.Start();
            th2.Start();
            th3.Start();
            th4.Start();

            Thread.Sleep(20000);

            Console.Read();
        }

        public static void SendOverflow()
        {
            ExchangeDesk eD = ExchangeDesk.GetInstance;
            for (int i = 0; i < 500; i++)
            {
                eD.SendDirtyObject("TableClothes", 5);
            }
        }
    }
}
