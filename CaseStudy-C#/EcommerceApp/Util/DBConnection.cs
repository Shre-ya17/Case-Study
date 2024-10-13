using System;
using System.Data.SqlClient;
using System.Configuration;

namespace EcommerceApp.Util
{
    public static class DBConnection
    {
        private static SqlConnection connection = null;

        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["EcommerceAppDB"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            return connection;
        }
    }
}
