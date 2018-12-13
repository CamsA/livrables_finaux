using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class KitchenClerk
    {

        public void Peel(string vegetable)
        {
            Thread.Sleep(1000);
            // todo with vegetable
        }

        public void GetIngredients()
        {
            //todo requete sql avec camille
        }

        public void BringMeals(int idMeal)
        {
            View.Display.DisplayMsg("Le commis emmène un plat préparé par le cusinier au comptoir", false, true, ConsoleColor.White);
            ExchangeDesk.GetInstance.SendPreparedMeal(idMeal);
        }

        public void Work()
        {
            //this.BringMeals();
            this.Peel("patate");
        }
    }
}
