using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRoomConsole.View
{
    class Display
    {

        // Private variables
        private double ClientsPerMinutesMin;
        private double ClientsPerMinutesMax;

        //Constructeur
        public Display()
        {
        }

        public double ClientsPerMinutesMinSG
        {
            get { return ClientsPerMinutesMin; }
            set { ClientsPerMinutesMin = value; }
        }

        public double ClientsPerMinutesMaxSG
        {
            get { return ClientsPerMinutesMax; }
            set { ClientsPerMinutesMax = value; }
        }

        //Méthode privée pour initialiser les paramètres
        //Appelée par le constructeur
        



    }
}