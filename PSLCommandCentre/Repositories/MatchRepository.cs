using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;

namespace PSLCommandCentre.Repositories
{
    public class MatchRepository : BaseRepository
    {
        public List<Match> GetAll()
        {
            var list = new List<Match>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(@"
                        SELECT m.*,
                               s.name  AS season_name,
                               t1.name AS team1_name,
                               t2.name AS team2_name,
                               v.name  AS venue_name
                        FROM `Match` m
                        JOIN Season s  ON m.season_id = s.season_id
                        JOIN Team   t1 ON m.team1_id  = t1.team_id
                        JOIN Team   t2 ON m.team2_id  = t2.team_id
                        JOIN Venue  v  ON m.venue_id  = v.venue_id
                        ORDER BY m.match_date DESC", conn);

                    using (var r = cmd.ExecuteReader())
                        while (r.Read()) list.Add(Map(r));
                }
            }
            catch (Exception ex) { Logger.Log("MatchRepository.GetAll", ex); }
            return list;
        }

        public List<Match> GetBySeason(int seasonId)
        {
            var list = new List<Match>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(@"
                        SELECT m.*,
                               s.name  AS season_name,
                               t1.name AS team1_name,
                               t2.name AS team2_name,
                               v.name  AS venue_name
                        FROM `Match` m
                        JOIN Season s  ON m.season_id = s.season_id
                        JOIN Team   t1 ON m.team1_id  = t1.team_id
                        JOIN Team   t2 ON m.team2_id  = t2.team_id
                        JOIN Venue  v  ON m.venue_id  = v.venue_id
                        WHERE m.season_id = @sid
                        ORDER BY m.match_date ASC", conn);

                    cmd.Parameters.AddWithValue("@sid", seasonId);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read()) list.Add(Map(r));
                }
            }
            catch (Exception ex) { Logger.Log("MatchRepository.GetBySeason", ex); }
            return list;
        }

        public int Add(Match m)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(@"
                        INSERT INTO `Match`
                            (season_id, team1_id, team2_id, venue_id, match_date, match_type, status)
                        VALUES
                            (@sid, @t1, @t2, @vid, @date, @type, @status);
                        SELECT LAST_INSERT_ID();", conn);

                    cmd.Parameters.AddWithValue("@sid", m.SeasonId);
                    cmd.Parameters.AddWithValue("@t1", m.Team1Id);
                    cmd.Parameters.AddWithValue("@t2", m.Team2Id);
                    cmd.Parameters.AddWithValue("@vid", m.VenueId);
                    cmd.Parameters.AddWithValue("@date", m.MatchDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@type", m.MatchType);
                    cmd.Parameters.AddWithValue("@status", m.Status);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex) { Logger.Log("MatchRepository.Add", ex); return -1; }
        }

        public bool Update(Match m)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(@"
                        UPDATE `Match` SET
                            season_id  = @sid,
                            team1_id   = @t1,
                            team2_id   = @t2,
                            venue_id   = @vid,
                            match_date = @date,
                            match_type = @type,
                            status     = @status
                        WHERE match_id = @id", conn);

                    cmd.Parameters.AddWithValue("@sid", m.SeasonId);
                    cmd.Parameters.AddWithValue("@t1", m.Team1Id);
                    cmd.Parameters.AddWithValue("@t2", m.Team2Id);
                    cmd.Parameters.AddWithValue("@vid", m.VenueId);
                    cmd.Parameters.AddWithValue("@date", m.MatchDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@type", m.MatchType);
                    cmd.Parameters.AddWithValue("@status", m.Status);
                    cmd.Parameters.AddWithValue("@id", m.MatchId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) { Logger.Log("MatchRepository.Update", ex); return false; }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        "DELETE FROM `Match` WHERE match_id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) { Logger.Log("MatchRepository.Delete", ex); return false; }
        }

        private Match Map(MySqlDataReader r) => new Match
        {
            MatchId = r.GetInt32("match_id"),
            SeasonId = r.GetInt32("season_id"),
            Team1Id = r.GetInt32("team1_id"),
            Team2Id = r.GetInt32("team2_id"),
            VenueId = r.GetInt32("venue_id"),
            MatchDate = r.GetDateTime("match_date"),
            MatchType = r.GetString("match_type"),
            Status = r.GetString("status"),
            SeasonName = r.GetString("season_name"),
            Team1Name = r.GetString("team1_name"),
            Team2Name = r.GetString("team2_name"),
            VenueName = r.GetString("venue_name")
        };
    }
}