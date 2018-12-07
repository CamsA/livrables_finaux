using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    class Meal
    {
        private string name;
        private bool isCooked;

        public string Name { get => name; set => name = value; }
        public bool IsCooked { get => isCooked; set => isCooked = value; }

        Meal (string name)
        {
            this.name = name;
        }
    }
}
