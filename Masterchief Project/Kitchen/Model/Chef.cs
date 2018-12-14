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
        private Tasks waitingTask;
        private ExchangeDesk exchangeDesk;
        private string databaseName = "MasterChiefDB";
        private KitchenClerk flavien = new KitchenClerk();

        public int WaitingOrder { get => waitingOrder; set => waitingOrder = value; }
        public Tasks WaitingTask { get => waitingTask; set => waitingTask = value; }
        public ExchangeDesk ExchangeDesk { get => exchangeDesk; set => exchangeDesk = value; }
        public string DatabaseName { get => databaseName; private set => databaseName = value; }
        public KitchenClerk Flavien { get => flavien; set => flavien = value; }

        public Chef()
        {
            this.exchangeDesk = ExchangeDesk.GetInstance;
            this.waitingTask = new Tasks();
        }

        // The Chef give to the cooks the order of cooking the meal
        public int GiveRecipe()
        {

            DataSet dataSet = SQLprocess.GetTimeTasksByRecipes(this.DatabaseName, this.WaitingOrder);

            DataTable dataTable = dataSet.Tables[this.DatabaseName];

            foreach (DataRow dataRow in dataTable.Rows)
                this.WaitingTask.UnderTasksList.Add(new UnderTask(int.Parse(dataRow["DureeTache"].ToString())));

            const int CooksAmount = 2;
            var doneEvents = new ManualResetEvent[CooksAmount];
            var CooksArray = new Cooks[CooksAmount];

            for (int i = 0; i < CooksAmount; i++)
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
            int orderReady = this.WaitingOrder;
            this.WaitingOrder = -1;
            return orderReady;
        }

        // The Chef read the recipe matching the meal ID from the database,
        // then transform it in a task to be taken care of by the cooks
        public void ReadRecipe(int idMeal)
        {
            // transforms the idMeal into a Tasks object
        }

        // Regroups the orders to optimize the cooking
        public void OptimizeCommand(int idMeal)
        {
            //todo requete sql
        }

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
                    this.ReadRecipe(this.WaitingOrder);

                    View.Display.DisplayMsg("Le chef donne un plat à préparer aux cuisiniers", false, true, ConsoleColor.Blue);
                    this.Flavien.BringMeals(this.GiveRecipe());
                }

                Thread.Sleep(100);
            }
        }
    }
}
