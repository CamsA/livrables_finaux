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

        //le cuisinier cuisine la sous-tache donnée
        public void Cook(Object t)
        {
            //transforme l'objet en entreé de la fonction en sous-tache
            UnderTask undertask = (UnderTask)t;
            // attend le temps de la tache
            Thread.Sleep(undertask.TimeNeeded);
            //View.Display.DisplayMsg("Une sous-tâche a été effectuée par un cuisinier", false, true, ConsoleColor.White);
            undertask.IsDone = true;
            //avertis le threadpool que la fonction est fini
            _doneEvent.Set();
        }
    }
}
