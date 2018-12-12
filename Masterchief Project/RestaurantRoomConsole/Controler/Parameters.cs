using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRoomConsole.Controler
{
    public class Parameters
    {
        public static List<List<String>> listGroupClientReserved = new List<List<string>>();

        public static int timeEatStarter = 10000;
        public static int timeEatMainCourse = 10000;
        public static int timeEatDessert = 7000;
        public static int timeChooseMenu = 5000;

        public static int timeSpawnMin = 7000;
        public static int timeSpawnMax = 15000;

        //public static List<String> listGroupClientReserved = new List<String>();
    }
}
