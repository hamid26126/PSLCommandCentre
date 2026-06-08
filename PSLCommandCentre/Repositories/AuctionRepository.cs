using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;

namespace PSLCommandCentre.Repositories
{
    public class AuctionRepository : BaseRepository
    {
        public List<AuctionDraft> GetBySeason(int seasonId)
        {
            var list = new List<AuctionDraft>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(@"
                        SELECT a.*,
                               p.name        AS player_name,
                               p.role        AS player_role,
                               p.nationality AS player_nation,
                               t.name        AS team_name
                        FROM AuctionDraft a
                        JOIN Player p ON a.player_id      = p.player_id
                        LEFT JOIN Team t ON a.bought_by_team = t.team_id
                        WHERE a.season_id = @sid
                        ORDER BY a.status, p.name", conn);

                    cmd.Parameters.AddWithValue("@sid", seasonId);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read()) list.Add(MapAuction(r));
                }
            }
            catch (Exception ex) { Logger.Log("AuctionRepository.GetBySeason", ex); }
            return list;
        }

        public List<Player> GetUnregisteredPlayers(int seasonId)
        {
            var list = new List<Player>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    // Players not yet in this season's auction pool
                    var cmd = new MySqlCommand(@"
                        SELECT * FROM Player
                        WHERE player_id NOT IN (
                            SELECT player_id FROM AuctionDraft WHERE season_id = @sid
                        )
                        ORDER BY name", conn);

                    cmd.Parameters.AddWithValue("@sid", seasonId);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                            list.Add(new Player
                            {
                                PlayerId = r.GetInt32("player_id"),
                                Name = r.GetString("name"),
                                Role = r.GetString("role"),
                                Nationality = r.GetString("nationality"),
                                IsForeign = r.GetInt32("is_foreign") == 1
                            });
                }
            }
            catch (Exception ex) { Logger.Log("AuctionRepository.GetUnregisteredPlayers", ex); }
            return list;
        }

        public bool RegisterPlayer(int playerId, int seasonId, decimal basePrice)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(@"
                        INSERT INTO AuctionDraft (season_id, player_id, base_price, status)
                        VALUES (@sid, @pid, @base, 'Unsold')", conn);

                    cmd.Parameters.AddWithValue("@sid", seasonId);
                    cmd.Parameters.AddWithValue("@pid", playerId);
                    cmd.Parameters.AddWithValue("@base", basePrice);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) { Logger.Log("AuctionRepository.RegisterPlayer", ex); return false; }
        }

        // Called inside transaction from AuctionService
        public void SellPlayer(int auctionId, int teamId, decimal soldPrice,
                               MySqlConnection conn, MySqlTransaction tx)
        {
            var cmd = new MySqlCommand(@"
                UPDATE AuctionDraft
                SET status = 'Sold', bought_by_team = @tid, sold_price = @price
                WHERE auction_id = @aid", conn, tx);

            cmd.Parameters.AddWithValue("@tid", teamId);
            cmd.Parameters.AddWithValue("@price", soldPrice);
            cmd.Parameters.AddWithValue("@aid", auctionId);
            cmd.ExecuteNonQuery();
        }

        public void AssignToTeam(int playerId, int teamId, int seasonId,
                                 decimal soldPrice, MySqlConnection conn, MySqlTransaction tx)
        {
            var cmd = new MySqlCommand(@"
                INSERT INTO TeamPlayer (team_id, player_id, season_id, sale_price, category)
                VALUES (@tid, @pid, @sid, @price, 'Auctioned')", conn, tx);

            cmd.Parameters.AddWithValue("@tid", teamId);
            cmd.Parameters.AddWithValue("@pid", playerId);
            cmd.Parameters.AddWithValue("@sid", seasonId);
            cmd.Parameters.AddWithValue("@price", soldPrice);
            cmd.ExecuteNonQuery();
        }

        public void DeductBudget(int teamId, decimal amount,
                                 MySqlConnection conn, MySqlTransaction tx)
        {
            var cmd = new MySqlCommand(@"
                UPDATE Team SET budget = budget - @amount WHERE team_id = @tid", conn, tx);

            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@tid", teamId);
            cmd.ExecuteNonQuery();
        }

        public List<AuctionDraft> GetUnsoldPlayers(int seasonId)
        {
            var list = new List<AuctionDraft>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand(@"
                        SELECT a.*, p.name AS player_name,
                               p.role AS player_role, p.nationality AS player_nation
                        FROM AuctionDraft a
                        JOIN Player p ON a.player_id = p.player_id
                        WHERE a.season_id = @sid AND a.status = 'Unsold'
                        ORDER BY p.name", conn);

                    cmd.Parameters.AddWithValue("@sid", seasonId);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read()) list.Add(MapAuction(r));
                }
            }
            catch (Exception ex) { Logger.Log("AuctionRepository.GetUnsoldPlayers", ex); }
            return list;
        }

        private AuctionDraft MapAuction(MySqlDataReader r) => new AuctionDraft
        {
            AuctionId = r.GetInt32("auction_id"),
            SeasonId = r.GetInt32("season_id"),
            PlayerId = r.GetInt32("player_id"),
            BasePrice = r.GetDecimal("base_price"),
            SoldPrice = r.IsDBNull(r.GetOrdinal("sold_price"))
                                  ? (decimal?)null : r.GetDecimal("sold_price"),
            BoughtByTeam = r.IsDBNull(r.GetOrdinal("bought_by_team"))
                                  ? (int?)null : r.GetInt32("bought_by_team"),
            Status = r.GetString("status"),
            PlayerName = r.IsDBNull(r.GetOrdinal("player_name"))
                                  ? "" : r.GetString("player_name"),
            PlayerRole = r.IsDBNull(r.GetOrdinal("player_role"))
                                  ? "" : r.GetString("player_role"),
            PlayerNation = r.IsDBNull(r.GetOrdinal("player_nation"))
                                  ? "" : r.GetString("player_nation"),
            BoughtByTeamName = r.IsDBNull(r.GetOrdinal("team_name"))
                                  ? "Unsold" : r.GetString("team_name")
        };
    }
}