using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Kitchen.Model
{
    class Cooks : MovableEntities
    {
        private string recipe;

        public string Recipe { get => recipe; set => recipe = value; }

        /*public void Thread()
        {
            ThreadPool.QueueUserWorkItem(test);
        }

        public void test(object a)
        {
        }*/

        public void Cook (string recipe)
        {
            //todo avec camile, requete sql
        }
    }
}
