using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantRoomConsole.Model
{
    public class GroupClient
    {

        public String name;
        public int size;
        public List<Clients> clientList;
        public bool hasReserved;
        public int assignedTable;
        public bool isEating;
        public bool isWaitingATable;


        public GroupClient()
        { }



        public GroupClient(String _name, int _nbrClients)
        {
            this.isWaitingATable = true;
            this.name = _name;
            clientList = new List<Clients>();

            for (int i = 0; i < _nbrClients; i++)
            {
                Clients client = new Clients("Client" + Restaurant.cntClient);
                clientList.Add(client);
                Restaurant.cntClient += 1;
            }

            Console.WriteLine();
            Console.WriteLine(" *** Nouveau groupe de " + _nbrClients + " client *** ");
            Console.WriteLine();

        }

        public void DisplayGroupClient()
        {
            foreach (Clients client in this.clientList)
            {
                //Console.WriteLine("Dans " + this.name + " il y a " + client.name);
            }
        }


        public void loopGen()
        {
            while (true)
            {

                Thread.Sleep(500);
            }
        }
    }

}
