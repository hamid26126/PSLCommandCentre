using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;

namespace PSLCommandCentre.Repositories
{
    public class ScorecardRepository : BaseRepository
    {
        // ── Innings ────────────────────────────────────────────────────

        public int AddInnings(Innings inn, MySqlConnection conn, MySqlTransaction tx)
        {
            var cmd = new MySqlCommand(@"
                INSERT INTO Innings
                    (match_id, batting_team_id, innings_number, total_runs, total_wickets, total_overs)
                VALUES (@mid, @btid, @inum, @runs, @wkts, @overs);
                SELECT LAST_INSERT_ID();", conn, tx);

            cmd.Parameters.AddWithValue("@mid", inn.MatchId);
            cmd.Parameters.AddWithValue("@btid", inn.BattingTeamId);
            cmd.Parameters.AddWithValue("@inum", inn.InningsNumber);
            cmd.Parameters.AddWithValue("@runs", inn.TotalRuns);
            cmd.Parameters.AddWithValue("@wkts", inn.TotalWickets);
            cmd.Parameters.AddWithValue("@overs", inn.TotalOvers);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        // ── Batting ────────────────────────────────────────────────────

        public void AddBattingPerf(BattingPerf bp, MySqlConnection conn, MySqlTransaction tx)
        {
            var cmd = new MySqlCommand(@"
                INSERT INTO BattingPerf
                    (innings_id, player_id, runs, balls, fours, sixes, dismissal_type)
                VALUES (@iid, @pid, @runs, @balls, @fours, @sixes, @diss)", conn, tx);

            cmd.Parameters.AddWithValue("@iid", bp.InningsId);
            cmd.Parameters.AddWithValue("@pid", bp.PlayerId);
            cmd.Parameters.AddWithValue("@runs", bp.Runs);
            cmd.Parameters.AddWithValue("@balls", bp.Balls);
            cmd.Parameters.AddWithValue("@fours", bp.Fours);
            cmd.Parameters.AddWithValue("@sixes", bp.Sixes);
            cmd.Parameters.AddWithValue("@diss", bp.DismissalType ?? "Not Out");
            cmd.ExecuteNonQuery();
        }

        // ── Bowling ────────────────────────────────────────────────────

        public void AddBowlingPerf(BowlingPerf bwp, MySqlConnection conn, MySqlTransaction tx)
        {
            var cmd = new MySqlCommand(@"
                INSERT INTO BowlingPerf
                    (innings_id, player_id, overs, runs_given, wickets, economy)
                VALUES (@iid, @pid, @overs, @runs, @wkts, @eco)", conn, tx);

            cmd.Parameters.AddWithValue("@iid", bwp.InningsId);
            cmd.Parameters.AddWithValue("@pid", bwp.PlayerId);
            cmd.Parameters.AddWithValue("@overs", bwp.Overs);
            cmd.Parameters.AddWithValue("@runs", bwp.RunsGiven);
            cmd.Parameters.AddWithValue("@wkts", bwp.Wickets);
            cmd.Parameters.AddWithValue("@eco", bwp.Economy);
            cmd.ExecuteNonQuery();
        }

        // ── Match Result ───────────────────────────────────────────────

        public void AddMatchResult(MatchResult res, MySqlConnection conn, MySqlTransaction tx)
        {
            var cmd = new MySqlCommand(@"
                INSERT INTO MatchResult
                    (match_id, winner_team_id, margin, margin_type, motm_player_id)
                VALUES (@mid, @win, @margin, @mtype, @motm)", conn, tx);

            cmd.Parameters.AddWithValue("@mid", res.MatchId);
            cmd.Parameters.AddWithValue("@win", res.WinnerTeamId);
            cmd.Parameters.AddWithValue("@margin", res.Margin);
            cmd.Parameters.AddWithValue("@mtype", res.MarginType);
            cmd.Parameters.AddWithValue("@motm", res.MotmPlayerId.HasValue
                                                        ? (object)res.MotmPlayerId.Value
                                                        : DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        // ── Read Scorecard ─────────────────────────────────────────────

        public List<BattingPerf> GetBatting(int inningsId)
        {
            var list = new List<BattingPerf>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(@"
                        SELECT bp.*, p.name AS player_name
                        FROM BattingPerf bp
                        JOIN Player p ON bp.player_id = p.player_id
                        WHERE bp.innings_id = @iid
                        ORDER BY bp.runs DESC", conn);

                    cmd.Parameters.AddWithValue("@iid", inningsId);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                            list.Add(new BattingPerf
                            {
                                BpId = r.GetInt32("bp_id"),
                                InningsId = r.GetInt32("innings_id"),
                                PlayerId = r.GetInt32("player_id"),
                                PlayerName = r.GetString("player_name"),
                                Runs = r.GetInt32("runs"),
                                Balls = r.GetInt32("balls"),
                                Fours = r.GetInt32("fours"),
                                Sixes = r.GetInt32("sixes"),
                                DismissalType = r.IsDBNull(r.GetOrdinal("dismissal_type"))
                                                    ? "Not Out" : r.GetString("dismissal_type")
                            });
                }
            }
            catch (Exception ex) { Logger.Log("ScorecardRepository.GetBatting", ex); }
            return list;
        }

        public List<BowlingPerf> GetBowling(int inningsId)
        {
            var list = new List<BowlingPerf>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(@"
                        SELECT bwp.*, p.name AS player_name
                        FROM BowlingPerf bwp
                        JOIN Player p ON bwp.player_id = p.player_id
                        WHERE bwp.innings_id = @iid
                        ORDER BY bwp.wickets DESC", conn);

                    cmd.Parameters.AddWithValue("@iid", inningsId);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                            list.Add(new BowlingPerf
                            {
                                BwpId = r.GetInt32("bwp_id"),
                                InningsId = r.GetInt32("innings_id"),
                                PlayerId = r.GetInt32("player_id"),
                                PlayerName = r.GetString("player_name"),
                                Overs = r.GetDecimal("overs"),
                                RunsGiven = r.GetInt32("runs_given"),
                                Wickets = r.GetInt32("wickets"),
                                Economy = r.GetDecimal("economy")
                            });
                }
            }
            catch (Exception ex) { Logger.Log("ScorecardRepository.GetBowling", ex); }
            return list;
        }
    }
}