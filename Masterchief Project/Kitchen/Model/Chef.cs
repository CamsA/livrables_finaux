using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Kitchen.Model
{
    public class Chef : Entities
    {

        private int waitingOrder;
        private Tasks waitingTask;

        public int WaitingOrder { get => waitingOrder; set => waitingOrder = value; }
        public Tasks WaitingTask { get => waitingTask; set => waitingTask = value; }

        public Chef()
        {
            /*while (true)
            {
                GiveRecipe();

            }*/
        }

        public void GiveRecipe()
        {
            const int CooksNombers = 2;
            var doneEvents = new ManualResetEvent[CooksNombers];
            var CooksArray = new Cooks[CooksNombers];

            for (int i = 0; i < CooksNombers; i++)
            {
                doneEvents[i] = new ManualResetEvent(false);
                var cook = new Cooks(doneEvents[i]);

                if (WaitingTask.IsDone == false)
                {
                    foreach (var undertask in WaitingTask.UnderTasksList)
                    {
                        if (undertask.IsDone == false)
                        {
                            ThreadPool.QueueUserWorkItem(cook.Cook, undertask);
                        }
                        if (WaitingTask.UnderTasksList.All(IsDone => true))
                        {
                            WaitingTask.IsDone = true;
                        }
                    }
                }
            }
            WaitHandle.WaitAny(doneEvents);
        }

        public void OptimizedCommand()
        {
            //todo requete sql
        }

        public void RemoveMeal()
        {
            //todo requete sql
        }

        public void GetOrder()
        {
            //todo socket
        }
    }
}
