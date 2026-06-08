using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;

namespace PSLCommandCentre.Repositories
{
    public class PointsTableEntry
    {
        public string TeamName { get; set; }
        public int Played { get; set; }
        public int Won { get; set; }
        public int Lost { get; set; }
        public decimal NRR { get; set; }
        public int Points { get; set; }
    }

    public class PointsTableRepository : BaseRepository
    {
        public List<PointsTableEntry> GetStandings(int seasonId)
        {
            var list = new List<PointsTableEntry>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    // Calls our stored procedure from Phase 1
                    var cmd = new MySqlCommand("GetSeasonStandings", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_season_id", seasonId);

                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                            list.Add(new PointsTableEntry
                            {
                                TeamName = r.GetString("name"),
                                Played = r.GetInt32("played"),
                                Won = r.GetInt32("won"),
                                Lost = r.GetInt32("lost"),
                                NRR = r.GetDecimal("nrr"),
                                Points = r.GetInt32("points")
                            });
                }
            }
            catch (Exception ex) { Logger.Log("PointsTableRepository.GetStandings", ex); }
            return list;
        }

        public bool InitialiseForSeason(int seasonId, List<int> teamIds)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    foreach (var tid in teamIds)
                    {
                        var cmd = new MySqlCommand(@"
                            INSERT IGNORE INTO PointsTable
                                (season_id, team_id, played, won, lost, nrr, points)
                            VALUES (@sid, @tid, 0, 0, 0, 0.000, 0)", conn);

                        cmd.Parameters.AddWithValue("@sid", seasonId);
                        cmd.Parameters.AddWithValue("@tid", tid);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex) { Logger.Log("PointsTableRepository.Initialise", ex); return false; }
        }
    }
}