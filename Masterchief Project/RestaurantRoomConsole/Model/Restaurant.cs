using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRoomConsole.Model
{
    public class Restaurant
    {
        public static int cntClient = 0;
        public static List<Tables> listTables = new List<Tables>();
        public static List<GroupClient> listGroupClient = new List<GroupClient>();

        public static List<Square> listSquare = new List<Square>();

        public Restaurant()
        {
            listSquare.Add(new Square());
            listSquare.Add(new Square());

            listTables.Add(new Tables(5));
            listTables.Add(new Tables(6));
            listTables.Add(new Tables(3));
        }
    }

}
