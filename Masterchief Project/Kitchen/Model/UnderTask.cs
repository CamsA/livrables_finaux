using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class UnderTask
    {
        private int timeNeeded;
        private bool isDone;

        public int TimeNeeded { get => timeNeeded; set => timeNeeded = value; }
        public bool IsDone { get => isDone; set => isDone = value; }

        public UnderTask()
        {
            IsDone = false;
        }


    }
}
