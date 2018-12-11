using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Kitchen;


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
            }
            catch (Exception)
            {
                // Affiche des erreurs
                Console.WriteLine("Pas reussi à joindre la base de donnée");
            }
        }

        public string Datasrc { get => datasrc; set => datasrc = value; }
        public string DBname { get => DBname; set => DBname = value; }
    }
}
