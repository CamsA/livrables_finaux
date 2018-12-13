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
        static string table;
        static int category;
        static int idRecipe;

        //accesseurs
        static string Rq_sql { get => rq_sql; set => rq_sql = value; }
        static string Table { get => table; set => table = value; }
        static int Category { get => category; set => category = value; }
        static int IdRecipe { get => idRecipe; set => idRecipe = value; }

        //Les méthodes
        static string SelectAllFromTable(string ptable)
        {
            table = ptable;

            return Rq_sql = "SELECT * FROM " + table;
        }

        static string SelectRecepiesByType(int pcategory)
        {
            category = pcategory;

            return Rq_sql = "SELECT IDRecette FROM Recette WHERE Categorie = " + category;
        }

        static string SelectIngredientsAndQuantitiesByRecipes(int precipe)
        {
            idRecipe = precipe;

            return Rq_sql = "SELECT IDIngredient, QuantiteIngredient FROM Compose WHERE IDRecette =" + idRecipe;
        }

        static string UpdateIngredientStockByRecipe(int precipe)
        {
            idRecipe = precipe;

            return Rq_sql = "EXEC SelectRecette @Recette = " + idRecipe;
        }

    }
}
