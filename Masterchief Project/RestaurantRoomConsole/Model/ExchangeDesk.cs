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

        public void AddPreparedMeal(int idMeal)
        {
            this.preparedMeals.Add(idMeal);
        }

        public void AddCleanObject(string type, int number)
        {
            switch (type)
            {
                case "TableClothes":
                    this.CleanTableClothes += number;
                    break;
                case "Napkins":
                    this.CleanNapkins += number;
                    break;
                default:
                    Console.Write("Error on the restaurant exchange desk\n");
                    break;
            }
        }
    }
}
