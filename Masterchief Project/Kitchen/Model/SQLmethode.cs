using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen
{
    static class SQLmethode
    {
        static string rq_sql;

        //accesseur
        static string Rq_sql { get => rq_sql; set => rq_sql = value; }

        //Les méthodes
        static string SelectAllFromTable(string table)
        {
            return Rq_sql = "SELECT * FROM " + table;
        }

        static string SelectRecepiesByType(int category)
        {
            return Rq_sql = "SELECT IDRecette FROM Recette WHERE Categorie = " + category;
        }

        static string SelectIngredientsAndQuantitiesByRecipes(int recipe)
        {
            return Rq_sql = "SELECT IDIngredient, QuantiteIngredient FROM Compose WHERE IDRecette =" + recipe;
        }

        static string UpdateIngredientStockByRecipe(int recipe)
        {
            return Rq_sql = "EXEC SelectRecette @Recette = " + recipe;
        }
    }
}
