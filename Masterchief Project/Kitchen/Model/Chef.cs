using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;


namespace Kitchen.Model
{
    public class Chef
    {
        // Next order the Chef has to take care of
        private int waitingOrder = -1;

        private ExchangeDesk exchangeDesk;
        private Kitchen kitchen;
        private string databaseName = "MasterChiefDB";
        private KitchenClerk flavien = new KitchenClerk();

        // Accessors
        public int WaitingOrder { get => waitingOrder; set => waitingOrder = value; }
        public ExchangeDesk ExchangeDesk { get => exchangeDesk; set => exchangeDesk = value; }
        public Kitchen Kitchen { get => kitchen; set => kitchen = value; }
        public string DatabaseName { get => databaseName; private set => databaseName = value; }
        public KitchenClerk Flavien { get => flavien; set => flavien = value; }

        public Chef()
        {
            this.exchangeDesk = ExchangeDesk.GetInstance;
        }

        // The Chef give to the cooks the order of cooking the meal
        private int GiveToCooks(Tasks task)
        {
            // Threadpool Parameters
            const int CooksAmount = 2;
            var doneEvents = new ManualResetEvent[CooksAmount];
            var CooksArray = new Cooks[CooksAmount];

            // The Chef gives the task undertasks to the Cooks until they've completed them all
            for (int i = 0; i < CooksAmount; i++)
            {
                // Threadpool Parameters
                doneEvents[i] = new ManualResetEvent(false);
                var cook = new Cooks(doneEvents[i]);

                // Send each undertask in the task to the Cooks
                if (task.IsDone == false)
                {
                    foreach (var undertask in task.UnderTasksList)
                    {
                        if (undertask.IsDone == false)
                        {
                            ThreadPool.QueueUserWorkItem(cook.Cook, undertask);
                        }
                        // Completes the task if every of it's undertasks are completed
                        if (task.UnderTasksList.All(IsDone => true))
                        {
                            task.IsDone = true;
                        }
                    }
                }
            }

            // Tells the Chef a task has been completed
            WaitHandle.WaitAny(doneEvents);

            int orderReady = this.WaitingOrder;
            this.WaitingOrder = -1;
            return orderReady;
        }

        // The Chef read the recipe matching the meal ID from the database,
        // then transform it in a task to be taken care of by the cooks
        public Tasks ReadRecipe()
        {
            Tasks task = new Tasks();
            DataSet dataSet = SQLprocess.GetTimeTasksByRecipes(this.DatabaseName, this.WaitingOrder);

            DataTable dataTable = dataSet.Tables[this.DatabaseName];

            foreach (DataRow dataRow in dataTable.Rows)
                task.UnderTasksList.Add(new UnderTask(int.Parse(dataRow["DureeTache"].ToString()) * 1000));

            return task;
        }
        
        /*
        // Regroups the orders to optimize the cooking
        public void OptimizeCommand(int idMeal)
        {
            //todo requete sql
        }
        */

        /*
        // Remove the meal from the menu if there's not enough ingredients
        public void RemoveMeal()
        {
            //todo requete sql
        }
        */

        // Get the first order that has arrived in the kitchen from the restaurant room
        public void GetLastOrder()
        {
            this.WaitingOrder = this.ExchangeDesk.WaitingOrders.First();
            this.ExchangeDesk.WaitingOrders.RemoveAt(0);
            View.Display.DisplayMsg("Le chef récupère une commande du comptoir", false, true, ConsoleColor.Blue);
        }

        public void Work()
        {
            while (true)
            {
                try
                {
                    this.GetLastOrder();
                }
                catch (Exception e)
                {
                    // View.Display.DisplayMsg("Aucune commande n'est présente au comptoir : " + e.ToString(), false, true, ConsoleColor.Red);
                }


                if (this.WaitingOrder != -1)
                {
                    // When the order is going to be treated, decrement the stocks
                    // SQLmethode.updateIngredientStockByRecipe(this.WaitingOrder);

                    View.Display.DisplayMsg("Le chef donne un plat à préparer aux cuisiniers", false, true, ConsoleColor.Blue);

                    // Transforms the order id into a task
                    Tasks waitingTask = this.ReadRecipe();

                    // Give the task to the cooks
                    int idMeal = this.GiveToCooks(waitingTask);

                    // Takes one unit of crockery to prepare the meal
                    //this.Kitchen.CleanCrokeryStack--;

                    // Calls the kitchen clerk to send it to the exchange desk
                    this.Flavien.BringMeals(idMeal);
                }
                Thread.Sleep(100);
            }
        }
    }
}
