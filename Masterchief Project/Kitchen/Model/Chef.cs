using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Kitchen.Model
{
    class Chef
    {

        public void GetsOrders()
        {

        }

        public void GetsRecipe()
        {

        }

        public void GiveTask()
        {

        }

        public void OptimizeOrders()
        {

        }

        public void RemoveMeal(Meal meal)
        {

        }

        public void ChefRunning()
        {
            for(int i = 0; i < 5; i++)
            {
                Console.Write("Thread running " + i + Environment.NewLine);
            }

        }

        public Chef()
        {
            Thread chefThread = new Thread(ChefRunning);
        }
    }
}
