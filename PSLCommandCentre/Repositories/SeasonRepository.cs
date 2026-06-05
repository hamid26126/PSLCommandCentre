using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;

namespace PSLCommandCentre.Repositories
{
    public class SeasonRepository : BaseRepository
    {
        public List<Season> GetAll()
        {
            var list = new List<Season>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand("SELECT * FROM Season ORDER BY year DESC", conn);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read()) list.Add(Map(r));
                }
            }
            catch (Exception ex) { Logger.Log("SeasonRepository.GetAll", ex); }
            return list;
        }

        public bool Add(Season s)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        @"INSERT INTO Season (name, year, start_date, end_date, status)
                          VALUES (@name, @year, @start, @end, @status)", conn);
                    cmd.Parameters.AddWithValue("@name", s.Name);
                    cmd.Parameters.AddWithValue("@year", s.Year);
                    cmd.Parameters.AddWithValue("@start", s.StartDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@end", s.EndDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@status", s.Status);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) { Logger.Log("SeasonRepository.Add", ex); return false; }
        }

        public bool Update(Season s)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        @"UPDATE Season SET name=@name, year=@year, start_date=@start,
                          end_date=@end, status=@status WHERE season_id=@id", conn);
                    cmd.Parameters.AddWithValue("@name", s.Name);
                    cmd.Parameters.AddWithValue("@year", s.Year);
                    cmd.Parameters.AddWithValue("@start", s.StartDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@end", s.EndDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@status", s.Status);
                    cmd.Parameters.AddWithValue("@id", s.SeasonId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) { Logger.Log("SeasonRepository.Update", ex); return false; }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        "DELETE FROM Season WHERE season_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) { Logger.Log("SeasonRepository.Delete", ex); return false; }
        }

        private Season Map(MySqlDataReader r) => new Season
        {
            SeasonId = r.GetInt32("season_id"),
            Name = r.GetString("name"),
            Year = r.GetInt32("year"),
            StartDate = r.GetDateTime("start_date"),
            EndDate = r.GetDateTime("end_date"),
            Status = r.GetString("status")
        };
    }
}