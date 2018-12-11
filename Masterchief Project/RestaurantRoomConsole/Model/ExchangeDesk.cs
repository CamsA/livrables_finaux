using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRoomConsole.Model
{
    public class ExchangeDesk
    {
        private static ExchangeDesk instance = null;
        private static readonly object padlock = new object();

        private int cleanTableClothes;
        private int cleanNapkins;
        private List<int> preparedMeals;

        public int CleanTableClothes { get => cleanTableClothes; set => cleanTableClothes = value; }
        public int CleanNapkins { get => cleanNapkins; set => cleanNapkins = value; }
        internal List<int> PreparedMeals { get => preparedMeals; set => preparedMeals = value; }


        private ExchangeDesk()
        { }

        public static ExchangeDesk GetInstance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ExchangeDesk();
                    }
                    return instance;
                }
            }
        }

        public void AddPreparedMeal(int idOrder)
        {
            this.preparedMeals.Add(idOrder);
        }

        public void AddCleanTableClothes(int number)
        {
            this.CleanTableClothes += number;
        }

        public void AddCleanNapkins(int number)
        {
            this.CleanNapkins += number;
        }
    }
}
