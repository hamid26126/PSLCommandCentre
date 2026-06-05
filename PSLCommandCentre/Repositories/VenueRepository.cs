using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;

namespace PSLCommandCentre.Repositories
{
    public class VenueRepository : BaseRepository
    {
        public List<Venue> GetAll()
        {
            var list = new List<Venue>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand("SELECT * FROM Venue ORDER BY name", conn);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                            list.Add(Map(r));
                }
            }
            catch (Exception ex) { Logger.Log("VenueRepository.GetAll", ex); }
            return list;
        }

        public Venue GetById(int id)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand("SELECT * FROM Venue WHERE venue_id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var r = cmd.ExecuteReader())
                        if (r.Read()) return Map(r);
                }
            }
            catch (Exception ex) { Logger.Log("VenueRepository.GetById", ex); }
            return null;
        }

        public bool Add(Venue v)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        @"INSERT INTO Venue (name, city, capacity, pitch_type, country)
                          VALUES (@name, @city, @cap, @pitch, @country)", conn);
                    cmd.Parameters.AddWithValue("@name", v.Name);
                    cmd.Parameters.AddWithValue("@city", v.City);
                    cmd.Parameters.AddWithValue("@cap", v.Capacity);
                    cmd.Parameters.AddWithValue("@pitch", v.PitchType ?? "");
                    cmd.Parameters.AddWithValue("@country", v.Country);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) { Logger.Log("VenueRepository.Add", ex); return false; }
        }

        public bool Update(Venue v)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        @"UPDATE Venue SET name=@name, city=@city, capacity=@cap,
                          pitch_type=@pitch, country=@country
                          WHERE venue_id=@id", conn);
                    cmd.Parameters.AddWithValue("@name", v.Name);
                    cmd.Parameters.AddWithValue("@city", v.City);
                    cmd.Parameters.AddWithValue("@cap", v.Capacity);
                    cmd.Parameters.AddWithValue("@pitch", v.PitchType ?? "");
                    cmd.Parameters.AddWithValue("@country", v.Country);
                    cmd.Parameters.AddWithValue("@id", v.VenueId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) { Logger.Log("VenueRepository.Update", ex); return false; }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        "DELETE FROM Venue WHERE venue_id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) { Logger.Log("VenueRepository.Delete", ex); return false; }
        }

        private Venue Map(MySqlDataReader r) => new Venue
        {
            VenueId = r.GetInt32("venue_id"),
            Name = r.GetString("name"),
            City = r.GetString("city"),
            Capacity = r.GetInt32("capacity"),
            PitchType = r.IsDBNull(r.GetOrdinal("pitch_type")) ? "" : r.GetString("pitch_type"),
            Country = r.GetString("country")
        };
    }
}