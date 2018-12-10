using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class Meal
    {
        private string name;
        private bool IsEaten;

        public string Name { get => name; set => name = value; }
        public bool IsEaten1 { get => IsEaten; set => IsEaten = value; }

        Meal (string name)
        {
            this.name = name;
        }
    }
}
