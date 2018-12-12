using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class Tasks
    {
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
