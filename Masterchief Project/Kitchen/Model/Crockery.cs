using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class Crockery
    {
        private bool isDirty;

        public bool IsDirty { get => isDirty; set => isDirty = value; }

        public Crockery()
        {
            IsDirty = false;
        }
    }
}
