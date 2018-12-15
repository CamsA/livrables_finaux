using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Kitchen.Model
{
    public class Cooks
    {
        private static ManualResetEvent _doneEvent;

        public Cooks(ManualResetEvent doneEvent)
        {
            _doneEvent = doneEvent;
        }

        // The cook takes care of the undertask assigned to him
        public void Cook(Object t)
        {
            // Transforms the object t into an undertask
            UnderTask undertask = (UnderTask)t;
            // Cooks the undertask
            Thread.Sleep(undertask.TimeNeeded);
            //View.Display.DisplayMsg("Une sous-tâche a été effectuée par un cuisinier", false, true, ConsoleColor.White);
            undertask.IsDone = true;
            // Tells the threadpool that the undertask is complete
            _doneEvent.Set();
        }
    }
}
