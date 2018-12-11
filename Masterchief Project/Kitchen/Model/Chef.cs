using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    class Chef : Entities
    {
        public void GiveRecipe(Cooks cooks, string recipe)
        {
            cooks.Recipe = recipe;
        }

        public void OptimizedCommand ()
        {
            //todo requete sql
        }

        public void RemoveMeal()
        {
            //todo requete sql
        }

        public void GetOrder ()
        {
            //todo socket
        }
    }
}
