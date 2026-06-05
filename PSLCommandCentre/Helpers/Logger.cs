using System;
using MySql.Data.MySqlClient;

namespace PSLCommandCentre.Helpers
{
    public static class Logger
    {
        public static void Log(string module, Exception ex)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        @"INSERT INTO ErrorLog (timestamp, module, error_message, stack_trace)
                          VALUES (NOW(), @module, @message, @stack)", conn);

                    cmd.Parameters.AddWithValue("@module", module);
                    cmd.Parameters.AddWithValue("@message", ex.Message);
                    cmd.Parameters.AddWithValue("@stack", ex.StackTrace ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                // Silent fail — never let logging crash the app
            }
        }

        public static void LogMessage(string module, string message)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        @"INSERT INTO ErrorLog (timestamp, module, error_message)
                          VALUES (NOW(), @module, @message)", conn);

                    cmd.Parameters.AddWithValue("@module", module);
                    cmd.Parameters.AddWithValue("@message", message);
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }
    }
}