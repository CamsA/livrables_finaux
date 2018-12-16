using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen
{

    //This class contains all requests needed for Kitchen

    public static class SQLmethode
    {
        public static string rq_sql;

        // Accessors
        public static string Rq_sql { get => rq_sql; set => rq_sql = value; }

        // Methods
        //public static string SelectAllFromTable(string table)
        //{
        //    return Rq_sql = "SELECT * FROM " + table;
        //}

        //public static string SelectRecepiesByType(int category)
        //{
        //    return Rq_sql = "SELECT IDRecette FROM Recette WHERE Categorie = " + category;
        //}

        //public static string SelectIngredientsAndQuantitiesByRecipes(int recipe)
        //{
        //    return Rq_sql = "SELECT IDIngredient, QuantiteIngredient FROM Compose WHERE IDRecette =" + recipe;
        //}

        public static string UpdateIngredientStockByRecipe(int recipe)
        {
            return Rq_sql = "EXEC SelectRecette @Recette = " + recipe;
        }

        //public static string UpdateArrivalDayIngredientStockByRecipe(int recipe)
        //{
        //    return Rq_sql = "UPDATE StockCuisine SET JourArrivé = JourArrivé + 1 WHERE IDStock = " + recipe;
        //}

        public static string InsertIntoScenario(int path)
        {
            return Rq_sql = "INSERT INTO Scenario( CheminRacine, Date ) VALUES('" + path + "', GETDATE()); ";
        }

        public static string SelectTimeTasksByRecipes(int recipe)
        {
            return Rq_sql = "SELECT Tache.DureeTache FROM Tache LEFT JOIN Necessite On Necessite.IDTache = Tache.IDTache WHERE Necessite.IDRecette = " + recipe;
        }
    }
}
