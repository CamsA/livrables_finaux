using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class KitchenClerk : MovableEntities
    {

        public void Peel(string vegetable)
        {
            // todo with vegetable
        }

        public void GetIngredients()
        {
            //todo requete sql avec camille
        }

        public void BringMeals(int idMeal)
        {
            ExchangeDesk.GetInstance.AddWaitingOrder(idMeal);
        }
    }
}
