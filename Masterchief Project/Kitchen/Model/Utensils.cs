using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class Utensils
    {
        private string name;
        private bool isClean;
        private bool isHeavy;
        private bool isUsed;

        public Utensils(string name, bool heavy)
        {
            Name = name;
            IsClean = true;
            IsHeavy = heavy;
            IsUsed = false;
        }

        public string Name { get => name; set => name = value; }
        public bool IsClean { get => isClean; set => isClean = value; }
        public bool IsHeavy { get => isHeavy; set => isHeavy = value; }
        public bool IsUsed { get => isUsed; set => isUsed = value; }
    }
}
