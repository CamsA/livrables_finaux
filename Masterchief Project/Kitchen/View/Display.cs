using Kitchen.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kitchen.View
{
    class Display
    {
        public static string logSavePath;
        public static string filePath;

        //Constructeur
        public Display()
        {
            logSavePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\MasterChiefLogs\\KitchenLogs\\";
            System.IO.Directory.CreateDirectory(logSavePath);
            filePath = logSavePath + "KitchenLog_" + DateTime.Now.ToString("HH-mm-ss") + ".txt";
            //SQLprocess.AddNewScenario(filePath);
        }

        public static void DisplayMsg(string msg, bool middle, bool lineBreak, ConsoleColor consoleclr)
        {
            String mdle = "";
            if (middle) { mdle = "       "; }
            else { mdle = ""; }

            if (lineBreak) { Console.WriteLine(); }
            if (consoleclr != ConsoleColor.White) { Console.ForegroundColor = consoleclr; }

            string formattedMsg = DateTime.Now.ToString("HH:mm:ss") + " :   " + mdle + msg + Environment.NewLine;
            WriteLog(formattedMsg);
            Console.Write(formattedMsg);

            if (lineBreak) { Console.WriteLine(); }

            Console.ResetColor();
        }

        public static void WriteLog(string Line)
        {
            try
            {
                System.IO.File.AppendAllText(filePath, Line);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}