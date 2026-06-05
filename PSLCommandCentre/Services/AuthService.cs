using System;
using MySql.Data.MySqlClient;
using PSLCommandCentre.Helpers;

namespace PSLCommandCentre.Services
{
    public class AuthService
    {
        public bool Login(string username, string password)
        {
            try
            {
                string hash = PasswordHelper.Hash(password);

                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        @"SELECT user_id, username, role
                          FROM Users
                          WHERE username = @username
                            AND password_hash = @hash
                          LIMIT 1", conn);

                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@hash", hash);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Store in session
                            SessionManager.UserId = reader.GetInt32("user_id");
                            SessionManager.Username = reader.GetString("username");
                            SessionManager.Role = reader.GetString("role");

                            // Update last_login timestamp
                            reader.Close();
                            UpdateLastLogin(conn, SessionManager.UserId);

                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log("AuthService", ex);
            }

            return false;
        }

        private void UpdateLastLogin(MySqlConnection conn, int userId)
        {
            try
            {
                var cmd = new MySqlCommand(
                    "UPDATE Users SET last_login = NOW() WHERE user_id = @id", conn);
                cmd.Parameters.AddWithValue("@id", userId);
                cmd.ExecuteNonQuery();
            }
            catch { }
        }
    }
}