using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;

namespace PSLCommandCentre.Helpers
{
    public static class DatabaseHelper
    {
        private const string ConnectionString =
            "Server=localhost;" +
            "Database=PSLCommandCentre;" +
            "Uid=root;" +
            "Pwd=HasanYasir01;";   // ← change to your MySQL root password

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        // Call this once on app startup to verify DB is reachable
        public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}