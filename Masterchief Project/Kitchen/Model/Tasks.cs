using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class Tasks
    {
        // Each task constitue a recipe, and each recipe is composed by one or more undertask(s)
        // For example, for the recipe "onion soup", which is a task, you have at least two
        // preliminate understaks : "peel the onions" and "cut the onions"
        private List<UnderTask> underTasksList;
        private bool isDone;

        public Tasks()
        {
            underTasksList = new List<UnderTask>();
            IsDone = false;
        }

        public List<UnderTask> UnderTasksList { get => underTasksList; set => underTasksList = value; }
        public bool IsDone { get => isDone; set => isDone = value; }
    }
}
