using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Kitchen;

namespace Kitchen.Model
{
    public static class SQLprocess
    {
        public static DataSet oDS;
        public static string rq_sql = "";

        public static void Start()
        {
            oDS = new DataSet();
            DBConnect.Start("MasterChiefDB");
        }

        public static DataSet DisplayAll(string dataTableName, string table)
        {
            oDS.Clear();
            oDS = DBConnect.GetRows(dataTableName, SQLmethode.SelectAllFromTable(table));
            return oDS;
        }

        public static DataSet GetRecipesByType(string dataTableName, int category)
        {
            oDS.Clear();
            oDS = DBConnect.GetRows(dataTableName, SQLmethode.SelectRecepiesByType(category));
            return oDS;
        }

        public static DataSet GetQuantiesByRecipes(string dataTableName, int category)
        {
            oDS.Clear();
            oDS = DBConnect.GetRows(dataTableName, SQLmethode.SelectRecepiesByType(category));
            return oDS;
        }

        public static void UpdateIngredientStock(int recipe)
        {
            oDS.Clear();
            DBConnect.ActionOnRows(SQLmethode.UpdateIngredientStockByRecipe(recipe));
        }

        public static void UpdateIngredientDay(int recipe)
        {
            oDS.Clear();
            DBConnect.ActionOnRows(SQLmethode.UpdateArrivalDayIngredientStockByRecipe(recipe));
        }

        public static void AddNewScenario(int path)
        {
            oDS.Clear();
            DBConnect.ActionOnRows(SQLmethode.InsertIntoScenario(path));
        }

        public static DataSet GetTimeTasksByRecipes(string dataTableName, int recipe)
        {
            oDS.Clear();
            oDS = DBConnect.GetRows(dataTableName, SQLmethode.SelectTimeTasksByRecipes(recipe));
            return oDS;
        }


    }
}
