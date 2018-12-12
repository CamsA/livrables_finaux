using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestaurantRoomConsole.View;
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
                if (Restaurant.listTables.Find(item => item.isOccuped == false) != null)
                {
                    if (Restaurant.listTables.Find(item => item.isReserved == false) != null)
                    {
                        foreach (GroupClient grp in Restaurant.listGroupClient)
                        {
                            if (grp.isWaitingATable)
                            {
                                foreach (Tables table in Restaurant.listTables)
                                {
                                    if (!table.isOccuped && !table.isReserved)
                                    {
                                        table.isOccuped = true;
                                        grp.isWaitingATable = false;
                                        grp.assignedTable = table.name;
                                        table.groupAssigned = grp.name;
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
                

                Thread.Sleep(200);
                }
            }

        }
    }

