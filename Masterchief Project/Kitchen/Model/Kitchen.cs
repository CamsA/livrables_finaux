using Kitchen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class Kitchen
    {
        private static Kitchen instance = null;
        private static readonly object padlock = new object();

        private int cleanCrokeryStack = 0;
        private DishWasherMachine dishMachine = new DishWasherMachine();
        private WashingMachine washingMachine = new WashingMachine();

        public int CleanCrokeryStack { get => cleanCrokeryStack; set => cleanCrokeryStack = value; }
        public DishWasherMachine DishMachine { get => dishMachine; set => dishMachine = value; }
        public WashingMachine WashingMachine { get => washingMachine; set => washingMachine = value; }

        private Kitchen()
        {
        }

        public static Kitchen GetInstance
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