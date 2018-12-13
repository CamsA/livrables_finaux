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
    class SQLprocess
    {
        private DataSet oDS;
        private SQLmethode oMethode;
        private DBConnect oDBConnect;
        private string rq_sql = "";

        public SQLprocess()
        {
            oDS = new DataSet();
            oMethode = new SQLmethode();
            oDBConnect = new DBConnect("MasterChiefDB");
        }

        public DataSet DisplayAll(string dataTableName, string table)
        {
            oDS.Clear();
            oDS = oDBConnect.GetRows(dataTableName, oMethode.SelectAllFromTable(table));
            return oDS;
        }

        public DataSet GetRecipesByType(string dataTableName, int category)
        {
            oDS.Clear();
            oDS = oDBConnect.GetRows(dataTableName, oMethode.SelectRecepiesByType(category));
            return oDS;
        }

        public DataSet GetQuantiesByRecipes(string dataTableName, int category)
        {
            oDS.Clear();
            oDS = oDBConnect.GetRows(dataTableName, oMethode.SelectRecepiesByType(category));
            return oDS;
        }

    }
}
