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
        //fonction qui permet d'éplucher un légume nommé
        public void Peel(string vegetable)
        {
            Thread.Sleep(5000);
            Display.DisplayMsg("Le Commis a epluché une " + vegetable, false, true, ConsoleColor.DarkGray);
        }

        //fonction qui permet d'apporté un légume nommé
        public void GetIngredients(string vegetable)
        {
            Thread.Sleep(5000);
            Display.DisplayMsg("Le Commis va cherché une " + vegetable, false, true, ConsoleColor.DarkGray);
        }

        //fonction qui permet d'apporté un plat préparé aux comptoire d'échange
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
