using System.Data.SqlClient;

namespace EcommerceSystem.Util
{
    public class DBConnection
    {
        private static SqlConnection connection;

        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                string connectionString = PropertyUtil.GetPropertyString();
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            return connection;
        }
    }
}
