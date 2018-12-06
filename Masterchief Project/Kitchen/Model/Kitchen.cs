using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public sealed class Kitchen
    {
        private static Kitchen instance = null;
        private static readonly object padlock = new object();


        int cleanCrokeryStack = 0;
        List<Utensils> dirtyUtensilsList = new List<Utensils>();
        DishWasherMachine dishMachine;
        WashingMachine washingMachine;


        Kitchen()
        {

        }

        public static Kitchen Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Kitchen();
                    }
                    return instance;
                }
            }
        }
    }
}
