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
                //                         taille, nom, carré, rang

                // carré 1
                // rang 1
                listTables.Add(new Tables(2, "Table7", 1, 1));
                listTables.Add(new Tables(2, "Table8", 1, 1));
                listTables.Add(new Tables(4, "Table5", 1, 1));
                listTables.Add(new Tables(4, "Table6", 1, 1));
                listTables.Add(new Tables(6, "Table3", 1, 1));
                listTables.Add(new Tables(6, "Table4", 1, 1));
                listTables.Add(new Tables(8, "Table1", 1, 1));
                listTables.Add(new Tables(8, "Table2", 1, 1));

                // rang 2
                listTables.Add(new Tables(2, "Table14", 1, 2));
                listTables.Add(new Tables(2, "Table15", 1, 2));
                listTables.Add(new Tables(4, "Table9", 1, 2));
                listTables.Add(new Tables(4, "Table10", 1, 2));
                listTables.Add(new Tables(4, "Table11", 1, 2));
                listTables.Add(new Tables(8, "Table13", 1, 2));
                listTables.Add(new Tables(10, "Table12", 1, 2));

                // carré2
                // rang 3
                listTables.Add(new Tables(2, "Table21", 2, 3));
                listTables.Add(new Tables(2, "Table22", 2, 3));
                listTables.Add(new Tables(4, "Table18", 2, 3));
                listTables.Add(new Tables(4, "Table19", 2, 3));
                listTables.Add(new Tables(4, "Table20", 2, 3));
                listTables.Add(new Tables(8, "Table17", 2, 3));
                listTables.Add(new Tables(10, "Table16", 2, 3));

                // rang 4
                listTables.Add(new Tables(2, "Table29", 2, 4));
                listTables.Add(new Tables(2, "Table30", 2, 4));
                listTables.Add(new Tables(4, "Table27", 2, 4));
                listTables.Add(new Tables(4, "Table28", 2, 4));
                listTables.Add(new Tables(6, "Table24", 2, 4));
                listTables.Add(new Tables(6, "Table25", 2, 4));
                listTables.Add(new Tables(6, "Table26", 2, 4));
                listTables.Add(new Tables(8, "Table23", 2, 4));


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
