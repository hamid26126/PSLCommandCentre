using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;
using PSLCommandCentre.Repositories;

namespace PSLCommandCentre.Services
{
    public class AuctionService
    {
        private readonly AuctionRepository _repo = new AuctionRepository();

        public List<AuctionDraft> GetSeasonAuction(int seasonId)
            => _repo.GetBySeason(seasonId);

        public List<AuctionDraft> GetUnsoldPlayers(int seasonId)
            => _repo.GetUnsoldPlayers(seasonId);

        public List<Player> GetUnregisteredPlayers(int seasonId)
            => _repo.GetUnregisteredPlayers(seasonId);

        public bool RegisterPlayerForAuction(int playerId, int seasonId, decimal basePrice)
        {
            if (basePrice <= 0) throw new Exception("Base price must be greater than 0.");
            return _repo.RegisterPlayer(playerId, seasonId, basePrice);
        }

        // ── TRANSACTION 2 ─────────────────────────────────────────────
        // Sell a player: update auction record + assign to team + deduct budget
        // All three must succeed or none are saved.
        public void SellPlayer(AuctionDraft draft, int teamId, decimal soldPrice)
        {
            if (soldPrice < draft.BasePrice)
                throw new Exception($"Sold price cannot be less than base price ({draft.BasePrice:N0} PKR).");

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        // Step 1 — Mark player as Sold in AuctionDraft
                        _repo.SellPlayer(draft.AuctionId, teamId, soldPrice, conn, tx);

                        // Step 2 — Add player to TeamPlayer for this season
                        _repo.AssignToTeam(draft.PlayerId, teamId, draft.SeasonId,
                                           soldPrice, conn, tx);

                        // Step 3 — Deduct sold price from team's budget
                        _repo.DeductBudget(teamId, soldPrice, conn, tx);

                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        Logger.Log("AuctionService.SellPlayer", ex);
                        throw;
                    }
                }
            }
        }
    }
}