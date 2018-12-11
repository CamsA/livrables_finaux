using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantRoomConsole.Model
{
    class MaitreHotel
    {
        public MaitreHotel()
        {
            Thread thmh = new Thread(loopMh);
            thmh.Start();
        }
        public void loopMh()
        {
            while (true)
            {

                foreach (GroupClient grp in Restaurant.listGroupClient)
                {

                    if (grp.isWaitingATable)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine("                                        Un nouveau group pour le maitre d'hotel !");

                        Console.WriteLine();
                        Console.ResetColor();
                        grp.isWaitingATable = false;
                        foreach (Tables table in Restaurant.listTables)
                        {
                            if (table.isOccuped == false)
                            {
                                table.isOccuped = true;
                                break;
                            }
                        }

                        if (Restaurant.listTables.Find(item => item.isOccuped == false) == null)
                        {
                            Console.WriteLine("                   /!\\ Il n'y a plus de table disponibles ! /!\\)");
                            Console.WriteLine();

                        }
                        break;
                    }
                }

                Thread.Sleep(200);
            }
        }

    }
}
