using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;

namespace PSLCommandCentre.Repositories
{
    public class PlayerRepository : BaseRepository
    {
        public List<Player> GetAll()
        {
            var list = new List<Player>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand("SELECT * FROM Player ORDER BY name", conn);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read()) list.Add(Map(r));
                }
            }
            catch (Exception ex) { Logger.Log("PlayerRepository.GetAll", ex); }
            return list;
        }

        public List<Player> Search(string keyword)
        {
            var list = new List<Player>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        @"SELECT * FROM Player
                          WHERE name LIKE @kw OR nationality LIKE @kw OR role LIKE @kw
                          ORDER BY name", conn);
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    using (var r = cmd.ExecuteReader())
                        while (r.Read()) list.Add(Map(r));
                }
            }
            catch (Exception ex) { Logger.Log("PlayerRepository.Search", ex); }
            return list;
        }

        public bool Add(Player p)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        @"INSERT INTO Player
                          (name, dob, nationality, batting_style, bowling_style, role, is_foreign, profile_pic)
                          VALUES (@name,@dob,@nat,@bat,@bowl,@role,@foreign,@pic)", conn);
                    SetParams(cmd, p);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) { Logger.Log("PlayerRepository.Add", ex); return false; }
        }

        public bool Update(Player p)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        @"UPDATE Player SET
                          name=@name, dob=@dob, nationality=@nat,
                          batting_style=@bat, bowling_style=@bowl,
                          role=@role, is_foreign=@foreign, profile_pic=@pic
                          WHERE player_id=@id", conn);
                    SetParams(cmd, p);
                    cmd.Parameters.AddWithValue("@id", p.PlayerId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) { Logger.Log("PlayerRepository.Update", ex); return false; }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand("DELETE FROM Player WHERE player_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) { Logger.Log("PlayerRepository.Delete", ex); return false; }
        }

        private void SetParams(MySqlCommand cmd, Player p)
        {
            cmd.Parameters.AddWithValue("@name", p.Name);
            cmd.Parameters.AddWithValue("@dob", p.DateOfBirth.HasValue
                                                        ? (object)p.DateOfBirth.Value.ToString("yyyy-MM-dd")
                                                        : DBNull.Value);
            cmd.Parameters.AddWithValue("@nat", p.Nationality);
            cmd.Parameters.AddWithValue("@bat", p.BattingStyle ?? "");
            cmd.Parameters.AddWithValue("@bowl", p.BowlingStyle ?? "");
            cmd.Parameters.AddWithValue("@role", p.Role);
            cmd.Parameters.AddWithValue("@foreign", p.IsForeign ? 1 : 0);
            cmd.Parameters.AddWithValue("@pic", p.ProfilePic ?? "");
        }

        private Player Map(MySqlDataReader r) => new Player
        {
            PlayerId = r.GetInt32("player_id"),
            Name = r.GetString("name"),
            DateOfBirth = r.IsDBNull(r.GetOrdinal("dob")) ? (DateTime?)null : r.GetDateTime("dob"),
            Nationality = r.GetString("nationality"),
            BattingStyle = r.IsDBNull(r.GetOrdinal("batting_style")) ? "" : r.GetString("batting_style"),
            BowlingStyle = r.IsDBNull(r.GetOrdinal("bowling_style")) ? "" : r.GetString("bowling_style"),
            Role = r.GetString("role"),
            IsForeign = r.GetInt32("is_foreign") == 1,
            ProfilePic = r.IsDBNull(r.GetOrdinal("profile_pic")) ? "" : r.GetString("profile_pic")
        };
    }
}