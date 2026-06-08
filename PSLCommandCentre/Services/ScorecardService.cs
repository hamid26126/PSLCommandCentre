using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;
using PSLCommandCentre.Repositories;

namespace PSLCommandCentre.Services
{
    public class ScorecardService
    {
        private readonly ScorecardRepository _repo = new ScorecardRepository();

        // ── TRANSACTION 1 ─────────────────────────────────────────────
        // Saves both innings + all batting/bowling perfs + match result
        // atomically. If anything fails, nothing is saved.
        public void SaveFullScorecard(
            Innings innings1,
            List<BattingPerf> batting1,
            List<BowlingPerf> bowling1,
            Innings innings2,
            List<BattingPerf> batting2,
            List<BowlingPerf> bowling2,
            MatchResult result)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        // Step 1 — Insert innings 1, get ID back
                        int inn1Id = _repo.AddInnings(innings1, conn, tx);
                        innings1.InningsId = inn1Id;

                        // Step 2 — Insert all batting for innings 1
                        foreach (var bp in batting1)
                        {
                            bp.InningsId = inn1Id;
                            _repo.AddBattingPerf(bp, conn, tx);
                        }

                        // Step 3 — Insert all bowling for innings 1
                        foreach (var bwp in bowling1)
                        {
                            bwp.InningsId = inn1Id;
                            _repo.AddBowlingPerf(bwp, conn, tx);
                        }

                        // Step 4 — Insert innings 2, get ID back
                        int inn2Id = _repo.AddInnings(innings2, conn, tx);
                        innings2.InningsId = inn2Id;

                        // Step 5 — Insert all batting for innings 2
                        foreach (var bp in batting2)
                        {
                            bp.InningsId = inn2Id;
                            _repo.AddBattingPerf(bp, conn, tx);
                        }

                        // Step 6 — Insert all bowling for innings 2
                        foreach (var bwp in bowling2)
                        {
                            bwp.InningsId = inn2Id;
                            _repo.AddBowlingPerf(bwp, conn, tx);
                        }

                        // Step 7 — Insert match result
                        // This triggers trg_after_match_result which updates PointsTable
                        _repo.AddMatchResult(result, conn, tx);

                        // All 7 steps succeeded — commit everything
                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Any step failed — rollback ALL inserts
                        tx.Rollback();
                        Logger.Log("ScorecardService.SaveFullScorecard", ex);
                        throw; // re-throw so the form can show the error
                    }
                }
            }
        }

        public List<BattingPerf> GetBatting(int inningsId)
            => _repo.GetBatting(inningsId);

        public List<BowlingPerf> GetBowling(int inningsId)
            => _repo.GetBowling(inningsId);
    }
}