using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Kitchen.Model
{
    class DBConnect
    {

            private string cnx = "";
            private SqlDataAdapter adapter = null;
            private SqlConnection connection = null;
            private SqlCommand command = null;
            private DataSet data = null;
            private string datasrc = "localhost";

            public DBConnect()
            {
                // Connexion à la base de données

                adapter = new SqlDataAdapter();
                command = new SqlCommand();
                data = new DataSet();
                datasrc = Environment.MachineName;
                cnx = "Data Source=" + datasrc + ";Initial Catalog=DB_A2_WS2;Integrated Security=True"; //Paramètres de la connexion
                connection = new SqlConnection(cnx);//Instanciation de la connexion

                try
                {
                    connection.Open(); // Ouverture de la connexion
                    Console.WriteLine("Ok");
                }
                catch (Exception)
                {
                    // Affiche des erreurs
                    Console.WriteLine("Pas reussi à joindre la base de donnée");
                }
            }

            public int TestCon()
            {
            //test de la connection
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }

        public void Deconnection()
            {
                // Fermeture de la connexion à la base de données
                connection.Close();
            }

        }
    }