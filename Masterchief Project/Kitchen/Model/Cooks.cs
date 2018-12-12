using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Kitchen.Model
{
    public class Cooks : MovableEntities
    {
        private static ManualResetEvent _doneEvent;

        public Cooks(ManualResetEvent doneEvent)
        {
            _doneEvent = doneEvent;
        }

        public void Cook(Object t)
        {
            UnderTask undertask = (UnderTask)t;
            Thread.Sleep(undertask.TimeNeeded);
            undertask.IsDone = true;
            _doneEvent.Set();
        }
    }
}
