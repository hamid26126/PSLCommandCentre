using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;

namespace PSLCommandCentre.Repositories
{
    public class TeamRepository : BaseRepository
    {
        public List<Team> GetAll()
        {
            var list = new List<Team>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        @"SELECT t.*, v.name AS venue_name
                          FROM Team t
                          LEFT JOIN Venue v ON t.home_venue_id = v.venue_id
                          ORDER BY t.name", conn);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read()) list.Add(Map(r));
                }
            }
            catch (Exception ex) { Logger.Log("TeamRepository.GetAll", ex); }
            return list;
        }

        public bool Add(Team t)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        @"INSERT INTO Team (name, city, owner, home_venue_id, budget)
                          VALUES (@name, @city, @owner, @venueId, @budget)", conn);
                    cmd.Parameters.AddWithValue("@name", t.Name);
                    cmd.Parameters.AddWithValue("@city", t.City);
                    cmd.Parameters.AddWithValue("@owner", t.Owner ?? "");
                    cmd.Parameters.AddWithValue("@venueId", t.HomeVenueId.HasValue ? (object)t.HomeVenueId.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@budget", t.Budget);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) { Logger.Log("TeamRepository.Add", ex); return false; }
        }

        public bool Update(Team t)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        @"UPDATE Team SET name=@name, city=@city, owner=@owner,
                          home_venue_id=@venueId, budget=@budget
                          WHERE team_id=@id", conn);
                    cmd.Parameters.AddWithValue("@name", t.Name);
                    cmd.Parameters.AddWithValue("@city", t.City);
                    cmd.Parameters.AddWithValue("@owner", t.Owner ?? "");
                    cmd.Parameters.AddWithValue("@venueId", t.HomeVenueId.HasValue ? (object)t.HomeVenueId.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@budget", t.Budget);
                    cmd.Parameters.AddWithValue("@id", t.TeamId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) { Logger.Log("TeamRepository.Update", ex); return false; }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand("DELETE FROM Team WHERE team_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) { Logger.Log("TeamRepository.Delete", ex); return false; }
        }

        private Team Map(MySqlDataReader r) => new Team
        {
            TeamId = r.GetInt32("team_id"),
            Name = r.GetString("name"),
            City = r.GetString("city"),
            Owner = r.IsDBNull(r.GetOrdinal("owner")) ? "" : r.GetString("owner"),
            HomeVenueId = r.IsDBNull(r.GetOrdinal("home_venue_id")) ? (int?)null : r.GetInt32("home_venue_id"),
            HomeVenueName = r.IsDBNull(r.GetOrdinal("venue_name")) ? "" : r.GetString("venue_name"),
            Budget = r.GetDecimal("budget")
        };
    }
}