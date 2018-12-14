using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class UnderTask
    {
        // Each undertask needs a certain amount of time to get done
        private int timeNeeded;
        private bool isDone;

        public int TimeNeeded { get => timeNeeded; set => timeNeeded = value; }
        public bool IsDone { get => isDone; set => isDone = value; }

        public UnderTask(int timeneeded)
        {
            this.TimeNeeded = timeneeded;
            IsDone = false;
        }
    }
}
