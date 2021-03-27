using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEmploye.Models.DAL
{
    public class DbConnection
    {
        static string connectionString = "Server=localhost;Database=StudentApi;Uid=root;Pwd=1ngenieur.c0m;";

        public static MySqlConnection GetConnection()
        {
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return connection;
        }
    }
}
