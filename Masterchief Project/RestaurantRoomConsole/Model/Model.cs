

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

        //default constructor
        public static int loopCount = 0;

        public Modell()
        {

            MaitreHotel mh = new MaitreHotel();
            Restaurant restaurant = new Restaurant();

            // Création d'un serveur, assigné à la ligne 1

            Waiter waiter = new Waiter("Serveur1", 1);
            Waiter waiter2 = new Waiter("Serveur2", 2);
            Waiter waiter3 = new Waiter("Serveur3", 3);
            Waiter waiter4 = new Waiter("Serveur4", 4);

            // chef de rang
            ChefDeRang CDR = new ChefDeRang("ChefDeRang1", 1);
            
            
            Thread lpgenClient = new Thread(LoopGenClient);
            lpgenClient.Start();
        }



        public void FirstLoop()
        {

            while (true)
            {
                Display.DisplayTables();
                Thread.Sleep(1000);



            }
        }



        // Générer les clients aléatoirement
        public void LoopGenClient()
        {
            //while (true)
           // {
                loopCount += 1;
                Random rnd = new Random();
                int nbrClients = rnd.Next(2, 6);


                GroupClient group = new GroupClient("group" + loopCount, nbrClients, false);
                
                Display.DisplayMsg("*** Nouveau groupe de " + nbrClients + " client ***", false, true, ConsoleColor.Green);
                
                Thread.Sleep(rnd.Next(Parameters.timeSpawnMin, Parameters.timeSpawnMax));
            //}
           
        }
    }
}

