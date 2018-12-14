using RestaurantRoomConsole.Controler;
using RestaurantRoomConsole.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public static void DisplayTables()
        {
            Console.WriteLine();


            Console.WriteLine("Clients ayant reservés :");
            foreach (List<String> list in Parameters.listGroupClientReserved.ToList())
            {
                Console.WriteLine(" " + list[0] +" " + list[1] +" " + list[2]);
            }
            Console.WriteLine();
            Console.WriteLine();
                foreach (Tables table in Restaurant.listTables)
            {
                String occuped = "";
                String reserved = "";
                if (table.isOccuped) { occuped = "Occupé"; } else { occuped = "libre"; }
                if (table.isReserved) { reserved = "Réservé"; } else { reserved = "Non réservée"; }
                
                Console.Write(DateTime.Now.ToString("mm:ss tt") + " " + table.name + " - ");
                if (occuped == "Occupé") { Console.ForegroundColor = ConsoleColor.Red; }
                Console.Write(occuped + " - ");
                Console.ResetColor();
                if (reserved == "Réservé") { Console.ForegroundColor = ConsoleColor.Red; }
                Console.Write(reserved + " - ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(table.groupAssigned + " | ");
                Console.ResetColor();

                Console.WriteLine();
            }
            // Infos sur les nappes et serviettes
            ExchangeDesk desk = ExchangeDesk.GetInstance;
            Console.WriteLine("Nombre de serviettes dans le desk : " + desk.CleanNapkins);
            Console.WriteLine("Nombre de nappes dans le desk : " + desk.CleanTableClothes);
            Console.WriteLine();
            
        }
        
        public static void WriteLog(string Line)
        {
            //string path = Parametre.logpath;
            //string name = path + "RestaurantLog : " + DateTime.Now + ".txt";
            //System.IO.File.WriteAllText(name, Line);
        }
        
    }
}