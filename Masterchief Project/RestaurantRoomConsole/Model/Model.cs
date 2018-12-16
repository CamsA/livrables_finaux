

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestaurantRoomConsole.Controler;
using RestaurantRoomConsole.Model;
using RestaurantRoomConsole.View;
namespace RestaurantRoomConsole.Model
{
    public class Modell
    {

        public static List<Thread> listThreads;
        private static bool suspend;
        //default constructor
        public static int loopCount = 0;

        public Modell()
        {
            suspend = false;
            listThreads = new List<Thread>();


            // Création du restaurant
            Restaurant restaurant = new Restaurant();


            // Création d'un maitre d'hotel
            MaitreHotel mh = new MaitreHotel("MaitreHotel1");


            // Création de 4 serveurs, assigné à la ligne 1 2 3 et 4
            Waiter waiter = new Waiter("Serveur1", 1);
            Waiter waiter2 = new Waiter("Serveur2", 2);
            Waiter waiter3 = new Waiter("Serveur3", 3);
            Waiter waiter4 = new Waiter("Serveur4", 4);

            // Création d'un chef de rang
            ChefDeRang CDR = new ChefDeRang("ChefDeRang1", 1);
            ChefDeRang CDR2 = new ChefDeRang("ChefDeRang2", 2);

            mh.thmh.Start();

            waiter.lpWaiter.Start();
            waiter2.lpWaiter.Start();
            waiter3.lpWaiter.Start();
            waiter4.lpWaiter.Start();

            CDR.lpChefDeRang.Start();
            CDR2.lpChefDeRang.Start();

            Thread lpgenClient = new Thread(LoopGenClient);
            lpgenClient.Start();

            listThreads.Add(mh.thmh);
            listThreads.Add(waiter.lpWaiter);
            listThreads.Add(waiter2.lpWaiter);
            listThreads.Add(waiter3.lpWaiter);
            listThreads.Add(waiter4.lpWaiter);
            listThreads.Add(CDR.lpChefDeRang);
            listThreads.Add(CDR2.lpChefDeRang);
            listThreads.Add(lpgenClient);
        }

        

        public void FirstLoop()
        {

            while (true)
            {
                Display.DisplayTables();
                Thread.Sleep(1000);
            }
        }
        
        public static void pauseThread()
        {
            if (!suspend)
            {
                /*foreach (Thread th in listThreads)
                {
                    th.Suspend();
                }*/
                suspend = true;
            }
            else
            {
                /*foreach (Thread th in listThreads)
                {
                    th.Resume();
                }*/
                suspend = false;
            }


            
        }

        // Générer les clients aléatoirement
        public void LoopGenClient()
        {
            while (true)
            {
                loopCount ++;
                Random rnd = new Random();
                int nbrClients = rnd.Next(2, 6);



                GroupClient group = new GroupClient("group" + loopCount, nbrClients, false);
                group.theat.Start();
                listThreads.Add(group.theat);

            Display.DisplayMsg("*** Nouveaux clients ! group"+loopCount+" vient d'arriver (" + nbrClients + " clients) ***", false, true, ConsoleColor.Green);
            
            Thread.Sleep(rnd.Next(Parameters.timeSpawnMin, Parameters.timeSpawnMax));
            }
           
        }
    }
}

