using RestaurantRoomConsole.Controler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRoomConsole.Model
{
    public class Restaurant
    {


        public static List<Tables> listTables = new List<Tables>();
        public static List<GroupClient> listGroupClient = new List<GroupClient>();

        public static List<Square> listSquare = new List<Square>();

        public Restaurant()
        {

            // On créer 5 tables(NOmbreDePlace, NomDeLaTable, RangN°, LineN°)
            listTables.Add(new Tables(5, "Table1", 1, 1));
            listTables.Add(new Tables(5, "Table2", 1, 2));
            listTables.Add(new Tables(5, "Table3", 2, 3));
            listTables.Add(new Tables(6, "Table4", 2, 4));


            // Initialisation des groupes ayant reservés

            foreach (List<String> list in Parameters.listGroupClientReserved)
            {
                // Pour chaque tables
                foreach(Tables table in listTables)
                {
                    if(!table.isOccuped && !table.isReserved)
                    {
                        table.isReserved = true;
                        table.groupAssigned = list[0];
                        break;
                    }
                }

            }
        }
    }

}
