using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRoomConsole.Model
{
    public class Square
    {
        public static List<Line> listLines = new List<Line>();



        public Square()
        {
            listLines.Add(new Line());
            listLines.Add(new Line());
        }
    }
}
