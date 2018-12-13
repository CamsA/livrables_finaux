using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRoomConsole.Model
{
    public class Tables
    {
        public int rang;
        public int line;

        public bool hasNapkins;
        public bool hasTableClothes;

        public bool cleanTableClothes;
        public bool cleanNapkins;

        public int nbrNapkins;

        public int nbrWatterBottles;
        public int nbrBreadBaskets;

        public bool isOccuped;
        public bool isReserved;
        public String name;
        public int size;
        public String groupAssigned;

        public Tables(int _size, String _name, int _rang, int _line)
        {
            // Initialisation des serviettes et nappes
            this.nbrNapkins = 0;
            this.hasNapkins = false;
            this.hasTableClothes = false;
            this.cleanNapkins = false;
            this.cleanTableClothes = false;

            // Pain et eau :
            this.nbrBreadBaskets = 0;
            this.nbrWatterBottles = 0;

            // Initialisation des rangs et des lignes ou les tables seront placées
            this.rang = _rang;
            this.line = _line;

            // Nom
            this.name = _name;

            // Si la table est occupé ou réservée
            this.isReserved = false;
            this.isOccuped = false;

            // Taille de la table
            this.size = _size;

        }
        public void assign(String _groupAssigned)
        {
            this.groupAssigned = _groupAssigned;
        }
    }

}
