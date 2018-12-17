using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Kitchen
{
    public static class DBConnect
    {
        public static string cnx = "";
        public static SqlDataAdapter adapter = null;
        public static SqlConnection connection = null;
        public static SqlCommand command = null;
        public static DataSet data = null;
        public static string datasrc = "local";
        public static string dbname = null;


        public static string Datasrc { get => datasrc; set => datasrc = value; }
        public static string DBname { get => DBname; set => DBname = value; }

        //Here is the method that you need to call when you need the database

        public static void Start(string namedb)
        {
            // Connection to the database

            adapter = new SqlDataAdapter();
            command = new SqlCommand();
            data = new DataSet();
            datasrc = Environment.MachineName;
            dbname = namedb;
            cnx = "Data Source=" + datasrc + ";Initial Catalog=" + dbname + ";Integrated Security=True"; // Connection parameters
            connection = new SqlConnection(cnx); // Instanciation of the connection

            try
            {
                connection.Open(); // Opens the connection
                View.Display.DisplayMsg("La connexion à la base de données est établie", true, true, ConsoleColor.DarkGreen); //To control that all is operational

            }
            catch (Exception e)
            {
                View.Display.DisplayMsg("/!\\/!\\/!\\ La connexion à la base de données à échouée /!\\/!\\/!\\" + e.ToString(), true, true, ConsoleColor.Red);
            }
        }

        //It's this method that get and place data when you want to execute a select request
        public static DataSet GetRows(string dataTableName, string rq_sql) 
        {
            command.CommandText = rq_sql;
            adapter.SelectCommand = new SqlCommand(command.CommandText);
            adapter.SelectCommand.Connection = connection; // Reads the data and replace the SqlDataReader
            adapter.Fill(data, dataTableName); // Get the data
            return data;
        }

        //It's this method that get and place data when you want to execute a select request
        public static void ActionOnRows(string rq_sql)
        {
            command.CommandText = rq_sql; 
            command.ExecuteNonQuery(); //Excutes updates, deletes, inserts
        }
    }
}
