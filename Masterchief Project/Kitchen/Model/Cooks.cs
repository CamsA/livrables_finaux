using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    class Cooks : MovableEntities
    {
        private string recipe;

        public string Recipe { get => recipe; set => recipe = value; }

        public void Cook (string recipe)
        {
            //todo avec camile, requete sql
        }
    }
}
