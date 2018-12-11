

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestaurantRoomConsole.Model;

namespace RestaurantRoomConsole.Model
{
    public class Modell
    {

        //default constructor

        public int cntClient;
        private int count;
        public Modell()
        {
            this.count = 0;
            this.cntClient = 0;
            MaitreHotel mh = new MaitreHotel();
            Restaurant restaurant = new Restaurant();

            Console.WriteLine("Nombre de tables : " + Restaurant.listTables.Count);




            // Loop pour générer les clients
            Thread thgcl = new Thread(FirstLoop);
            thgcl.Start();
            Thread lpgenClient = new Thread(LoopGenClient);
            lpgenClient.Start();
        }

        public void FirstLoop()
        {

            while (true)
            {




                foreach (Tables table in Restaurant.listTables)
                {
                    Console.Write("table: " + table.isOccuped + " | ");
                }
                Console.WriteLine();
                Thread.Sleep(2000);



            }
        }

        public void LoopGenClient()
        {
            while (true)
            {
                this.count += 1;
                Random rnd = new Random();
                int nbrClients = rnd.Next(2, 6);


                GroupClient group = new GroupClient("group" + this.count, nbrClients);
                Restaurant.listGroupClient.Add(group);

                // Random entre 10 et 20 sec pour un nouveau groupe de client
                Thread.Sleep(rnd.Next(3000, 6000));
            }
        }
    }
}

