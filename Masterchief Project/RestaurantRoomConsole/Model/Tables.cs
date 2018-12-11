using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRoomConsole.Model
{
    public class Tables
    {
        public bool isOccuped;
        public int size;
        public GroupClient groupAssigned;

        public Tables(int _size)
        {
            this.isOccuped = false;
            this.size = _size;
            //this.groupAssigned = _groupAssigned;

        }
        public void assign(GroupClient _groupAssigned)
        {
            this.groupAssigned = _groupAssigned;
        }
    }

}
