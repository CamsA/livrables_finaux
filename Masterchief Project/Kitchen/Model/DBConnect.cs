using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Kitchen
{
    public class DBConnect
    {
        private string cnx = "";
        private SqlDataAdapter adapter = null;
        private SqlConnection connection = null;
        private SqlCommand command = null;
        private DataSet data = null;
        private string datasrc = "local";
        private string dbname = null;

        public string Datasrc { get => datasrc; set => datasrc = value; }
        public string DBname { get => DBname; set => DBname = value; }

        public DBConnect(string namedb)
        {
            // Connexion à la base de données

            adapter = new SqlDataAdapter();
            command = new SqlCommand();
            data = new DataSet();
            datasrc = Environment.MachineName;
            dbname = namedb;
            cnx = "Data Source=" + datasrc + ";Initial Catalog=" + dbname + ";Integrated Security=True"; //Paramètres de la connexion
            connection = new SqlConnection(cnx);//Instanciation de la connexion

            try
            {
                connection.Open(); // Ouverture de la connexion
                View.Display.DisplayMsg("La connexion à la base de données est établie", true, true, ConsoleColor.Green);

            }
            catch (Exception e)
            {
                // Affiche des erreurs
                View.Display.DisplayMsg("/!\\/!\\/!\\ La connexion à la base de données à échouée /!\\/!\\/!\\" + e.ToString(), true, true, ConsoleColor.Red);
            }
        }

        public DataSet GetRows(string dataTableName, string rq_sql)
        {
            command.CommandText = rq_sql;
            adapter.SelectCommand = new SqlCommand(command.CommandText);
            adapter.SelectCommand.Connection = connection; // Permet de lire les données et remplace le SqlDataReader
            adapter.Fill(data, dataTableName); // Récupère les données
            return data;
        }

        public void ActionOnRows(string rq_sql)
        {

            command.CommandText = rq_sql;
            command.ExecuteNonQuery();
        }
    }
}
