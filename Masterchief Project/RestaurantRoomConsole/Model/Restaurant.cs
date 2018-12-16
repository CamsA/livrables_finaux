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


            // Initialisation des groupes ayant reservés

            if (Parameters.configTables)
            {
                foreach (List<String> listTable in Parameters.listTablesBegin)
                {
                    String name = listTable[0];
                    int size = int.Parse(listTable[1]);
                    int rang = int.Parse(listTable[2]);
                    int line = int.Parse(listTable[3]);

                    listTables.Add(new Tables(size, listTable[0].ToString(), rang, line));
                }
            }
            else
            {
                listTables.Add(new Tables(2, "Table1", 1, 1));
                listTables.Add(new Tables(5, "Table2", 1, 2));
                listTables.Add(new Tables(7, "Table3", 2, 3));
                listTables.Add(new Tables(6, "Table4", 2, 4));

            }

            foreach (List<String> list in Parameters.listGroupClientReserved)
            {
                // Pour chaque tables
                foreach(Tables table in listTables)
                {
                    if(!table.isOccuped && !table.isReserved)
                    {
                        if (table.size >= int.Parse(list[1]))
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

}
