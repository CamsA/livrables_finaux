using Kitchen.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class KitchenClerk
    {
        // Peels a designated vegetable
        public void Peel(string vegetable)
        {
            Thread.Sleep(5000);
            Display.DisplayMsg("Le Commis a epluché une " + vegetable, false, true, ConsoleColor.DarkGray);
        }

        // Takes an ingredient from the stock
        public void GetIngredients(string vegetable)
        {
            Thread.Sleep(5000);
            Display.DisplayMsg("Le Commis va chercher une " + vegetable, false, true, ConsoleColor.DarkGray);
        }

        // Brings a prepared meal to the exchange desk
        public void BringMeals(int idMeal)
        {
            View.Display.DisplayMsg("Le commis emmène un plat préparé par le cuisinier au comptoir", false, true, ConsoleColor.White);
            ExchangeDesk.GetInstance.SendPreparedMeal(idMeal);
        }

        public void Work()
        {
            //this.BringMeals();
            this.Peel("patate");
        }
    }
}
