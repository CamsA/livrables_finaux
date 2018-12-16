using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace RestaurantRoomConsole.Model
{
    public static class SQLprocess
    {

        //Define the new dataset to get data
        public static DataSet oDS;
        public static string rq_sql = "";

        //Before call any of th method above, you need to call this one first
        public static void Start()
        {
            oDS = new DataSet();
            DBConnect.Start("MasterChiefDB");
        }


        //-----------------------------------------------------------------------------
        //  These are the methods you actually call when you need to excute a request
        //-----------------------------------------------------------------------------

        public static DataSet DisplayAll(string dataTableName, string table)
        {
            oDS.Clear(); //Clear the dataset from any prvious data 
            oDS = DBConnect.GetRows(dataTableName, SQLmethode.SelectAllFromTable(table)); //As it is a SELECT request that we want to execute, we need GetRows
            return oDS;
        }

        public static DataSet GetRecipesByType(string dataTableName, int category)
        {
            oDS.Clear();//Clear the dataset from any prvious data
            oDS = DBConnect.GetRows(dataTableName, SQLmethode.SelectRecepiesByType(category));//As it is a SELECT request that we want to execute, we need GetRows
            return oDS;
        }

        public static DataSet GetQuantiesByRecipes(string dataTableName, int category)
        {
            oDS.Clear();//Clear the dataset from any prvious data
            oDS = DBConnect.GetRows(dataTableName, SQLmethode.SelectRecepiesByType(category));//As it is a SELECT request that we want to execute, we need GetRows
            return oDS;
        }

        public static void UpdateIngredientStock(int recipe)
        {
            oDS.Clear();//Clear the dataset from any prvious data
            DBConnect.ActionOnRows(SQLmethode.UpdateIngredientStockByRecipe(recipe));//As we want to change something in the database, we need ActionOnRows
        }

        public static void UpdateIngredientDay(int recipe)
        {
            oDS.Clear();//Clear the dataset from any prvious data
            DBConnect.ActionOnRows(SQLmethode.UpdateArrivalDayIngredientStockByRecipe(recipe));//As we want to change something in the database, we need ActionOnRows
        }

        public static void AddNewScenario(int path)
        {
            oDS.Clear();//Clear the dataset from any prvious data
            DBConnect.ActionOnRows(SQLmethode.InsertIntoScenario(path));//As we want to change something in the database, we need ActionOnRows
        }

        public static DataSet GetTimeTasksByRecipes(string dataTableName, int recipe)
        {
            oDS.Clear();//Clear the dataset from any prvious data
            oDS = DBConnect.GetRows(dataTableName, SQLmethode.SelectTimeTasksByRecipes(recipe));//As it is a SELECT request that we want to execute, we need GetRows
            return oDS;
        }

    }
}
