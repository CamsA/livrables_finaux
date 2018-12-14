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
        public int clock;
        private static Kitchen instance = null;
        private static readonly object padlock = new object();

        private DishWasherMachine dishwasherMachine;
        private WashingMachine washingMachine;
        private int cleanCrokeryStack;

        public DishWasherMachine DishwasherMachine { get => dishwasherMachine; private set => dishwasherMachine = value; }
        public WashingMachine WashingMachine { get => washingMachine; private set => washingMachine = value; }
        public int CleanCrokeryStack { get => cleanCrokeryStack; set => cleanCrokeryStack = value; }

        private Kitchen()
        {
            this.DishwasherMachine = new DishWasherMachine();
            this.WashingMachine = new WashingMachine();
            this.CleanCrokeryStack = 0;
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