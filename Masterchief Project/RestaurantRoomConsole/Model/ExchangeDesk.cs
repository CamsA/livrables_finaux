using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRoomConsole.Model
{
    public class ExchangeDesk
    {
        // Static instance to create the Singleton
        private static ExchangeDesk instance = null;
        private static readonly object padlock = new object();

        // Various stacks of equipments and meals ready to be carried by the waiter
        private int cleanTableClothes;
        private int cleanNapkins;
        private List<int> preparedMeals;

        // Getters and Setters
        public int CleanTableClothes { get => cleanTableClothes; set => cleanTableClothes = value; }
        public int CleanNapkins { get => cleanNapkins; set => cleanNapkins = value; }
        internal List<int> PreparedMeals { get => preparedMeals; set => preparedMeals = value; }

        // Private constructor
        private ExchangeDesk()
        { }

        // Instanciation and transmission of the instance via a Singleton
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

        // Add a meal on the desk
        public void AddPreparedMeal(int idMeal)
        {
            this.preparedMeals.Add(idMeal);
        }

        // Add a clean equipment on the desk
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
