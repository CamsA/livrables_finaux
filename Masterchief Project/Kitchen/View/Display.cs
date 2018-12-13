using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRoomConsole.View
{
    class Display
    {
        //Constructeur
        public Display()
        {
        }

        public static void DisplayMsg(string msg, bool middle, bool lineBreak, ConsoleColor consoleclr)
        {
            String mdle = "";
            if(middle) { mdle = "       "; }
            else { mdle = ""; }
            
            if(lineBreak) { Console.WriteLine(); }
            if(consoleclr != ConsoleColor.White) { Console.ForegroundColor = consoleclr; }
            
            Console.Write(DateTime.Now.ToString("mm:ss tt") + " : " + mdle + msg);
            Console.WriteLine();

            if (lineBreak)  { Console.WriteLine(); }

            Console.ResetColor();
        }

        public static void DisplayState()
        {
           
        }
        
        



    }
}