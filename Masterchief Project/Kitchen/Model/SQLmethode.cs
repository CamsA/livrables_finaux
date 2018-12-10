using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen
{
    class SQLmethode
    {
        private string rq_sql;
        private string table;
        private int category;

        //accesseurs
        public string Rq_sql { get => rq_sql; set => rq_sql = value; }
        public string Table { get => table; set => table = value; }
        public int Category { get => category; set => category = value; }

        //Les méthodes
        public string SelectAllFromTable(string ptable)
        {
            table = ptable;

            return Rq_sql = "SELECT * FROM " + table;
        }

        public string SelectRecepiesByType(int pcategory)
        {
            category = pcategory;

            return Rq_sql = "SELECT TOP 1 IDRecette FROM Recette WHERE Categorie = " + category +" ORDER BY NEWID()";
        }

        public string delete(int pid)
        {
            id = pid;

            return Rq_sql = "DELETE FROM TB_A2_WS2 WHERE" + pid;
        }

        public string insert(int pid, string name, string firstname)
        {
            id = pid;
            nom = name;
            prénom = firstname;

            return Rq_sql = "INSERT INTO TB_A2_WS2 VALUES ('" + pid + "', '" + name + "','" + firstname + "')";
        }

        public string update(int pid, string name, string firstname)
        {
            id = pid;
            nom = name;
            prénom = firstname;

            return Rq_sql = "UPDATE TB_A2_WS2 SET nom = '" + name + "', prenom = '" + firstname + "' WHERE" + pid;
        }
    }
}
