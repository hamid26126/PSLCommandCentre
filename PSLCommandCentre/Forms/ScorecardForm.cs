using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;
using PSLCommandCentre.Repositories;
using PSLCommandCentre.Services;

namespace PSLCommandCentre.Forms
{
    public partial class ScorecardForm : Form
    {
        private readonly ScorecardService _service = new ScorecardService();
        private readonly TeamRepository _teamRepo = new TeamRepository();
        private readonly PlayerRepository _playerRepo = new PlayerRepository();
        private readonly Match _match;

        // Holds batting/bowling rows the user is building
        private List<BattingPerf> _batting1 = new List<BattingPerf>();
        private List<BowlingPerf> _bowling1 = new List<BowlingPerf>();
        private List<BattingPerf> _batting2 = new List<BattingPerf>();
        private List<BowlingPerf> _bowling2 = new List<BowlingPerf>();

        public ScorecardForm(Match match)
        {
            InitializeComponent();
            _match = match;
        }

        private void ScorecardForm_Load(object sender, EventArgs e)
        {
            lblMatchTitle.Text =
                $"{_match.Team1Name}  vs  {_match.Team2Name}  |  {_match.MatchDate:dd MMM yyyy}  |  {_match.VenueName}";

            LoadTeamDropdowns();
            LoadPlayerDropdowns();
            LoadWinnerDropdown();
            LoadMotmDropdown();
        }

        // ── Dropdowns ─────────────────────────────────────────────────

        private void LoadTeamDropdowns()
        {
            // Innings 1 batting team
            cmbInn1BattingTeam.Items.Clear();
            cmbInn1BattingTeam.Items.Add(new Team { TeamId = _match.Team1Id, Name = _match.Team1Name });
            cmbInn1BattingTeam.Items.Add(new Team { TeamId = _match.Team2Id, Name = _match.Team2Name });
            cmbInn1BattingTeam.DisplayMember = "Name";
            cmbInn1BattingTeam.SelectedIndex = 0;

            // Innings 2 batting team (auto set to opposite)
            cmbInn2BattingTeam.Items.Clear();
            cmbInn2BattingTeam.Items.Add(new Team { TeamId = _match.Team1Id, Name = _match.Team1Name });
            cmbInn2BattingTeam.Items.Add(new Team { TeamId = _match.Team2Id, Name = _match.Team2Name });
            cmbInn2BattingTeam.DisplayMember = "Name";
            cmbInn2BattingTeam.SelectedIndex = 1; // opposite team bats second
        }

        private void LoadPlayerDropdowns()
        {
            var players = _playerRepo.GetAll();

            // Batting player pickers — both innings
            foreach (var cmb in new[] { cmbBat1Player, cmbBat2Player })
            {
                cmb.Items.Clear();
                foreach (var p in players) cmb.Items.Add(p);
                cmb.DisplayMember = "Name";
                if (cmb.Items.Count > 0) cmb.SelectedIndex = 0;
            }

            // Bowling player pickers — both innings
            foreach (var cmb in new[] { cmbBowl1Player, cmbBowl2Player })
            {
                cmb.Items.Clear();
                foreach (var p in players) cmb.Items.Add(p);
                cmb.DisplayMember = "Name";
                if (cmb.Items.Count > 0) cmb.SelectedIndex = 0;
            }
        }

        private void LoadWinnerDropdown()
        {
            cmbWinner.Items.Clear();
            cmbWinner.Items.Add(new Team { TeamId = _match.Team1Id, Name = _match.Team1Name });
            cmbWinner.Items.Add(new Team { TeamId = _match.Team2Id, Name = _match.Team2Name });
            cmbWinner.DisplayMember = "Name";
            cmbWinner.SelectedIndex = 0;
        }

        private void LoadMotmDropdown()
        {
            cmbMotm.Items.Clear();
            cmbMotm.Items.Add(new Player { PlayerId = 0, Name = "-- None --" });
            foreach (var p in _playerRepo.GetAll()) cmbMotm.Items.Add(p);
            cmbMotm.DisplayMember = "Name";
            cmbMotm.SelectedIndex = 0;
        }

        // ── Add Batting Row ───────────────────────────────────────────

        private void btnAddBat1_Click_1(object sender, EventArgs e)
            => AddBattingRow(1);

        private void btnAddBat2_Click_1(object sender, EventArgs e)
            => AddBattingRow(2);

        private void AddBattingRow(int innings)
        {
            var playerCmb = innings == 1 ? cmbBat1Player : cmbBat2Player;
            var runBox = innings == 1 ? nudBat1Runs : nudBat2Runs;
            var ballBox = innings == 1 ? nudBat1Balls : nudBat2Balls;
            var fourBox = innings == 1 ? nudBat1Fours : nudBat2Fours;
            var sixBox = innings == 1 ? nudBat1Sixes : nudBat2Sixes;
            var dissCmb = innings == 1 ? cmbBat1Diss : cmbBat2Diss;
            var grid = innings == 1 ? dgvBatting1 : dgvBatting2;
            var list = innings == 1 ? _batting1 : _batting2;

            var player = playerCmb.SelectedItem as Player;
            if (player == null) return;

            var bp = new BattingPerf
            {
                PlayerId = player.PlayerId,
                PlayerName = player.Name,
                Runs = (int)runBox.Value,
                Balls = (int)ballBox.Value,
                Fours = (int)fourBox.Value,
                Sixes = (int)sixBox.Value,
                DismissalType = dissCmb.Text
            };

            list.Add(bp);

            int row = grid.Rows.Add(
                player.Name, bp.Runs, bp.Balls,
                bp.Fours, bp.Sixes, bp.StrikeRate, bp.DismissalType);
            grid.Rows[row].Tag = bp;

            // Reset inputs
            runBox.Value = 0; ballBox.Value = 0;
            fourBox.Value = 0; sixBox.Value = 0;
        }

        // ── Add Bowling Row ───────────────────────────────────────────

        private void btnAddBowl1_Click_1(object sender, EventArgs e)
            => AddBowlingRow(1);

        private void btnAddBowl2_Click_1(object sender, EventArgs e)
            => AddBowlingRow(2);

        private void AddBowlingRow(int innings)
        {
            var playerCmb = innings == 1 ? cmbBowl1Player : cmbBowl2Player;
            var overBox = innings == 1 ? nudBowl1Overs : nudBowl2Overs;
            var runBox = innings == 1 ? nudBowl1Runs : nudBowl2Runs;
            var wktBox = innings == 1 ? nudBowl1Wkts : nudBowl2Wkts;
            var grid = innings == 1 ? dgvBowling1 : dgvBowling2;
            var list = innings == 1 ? _bowling1 : _bowling2;

            var player = playerCmb.SelectedItem as Player;
            if (player == null) return;

            decimal overs = overBox.Value;
            decimal economy = overs > 0
                ? Math.Round(runBox.Value / overs, 2) : 0;

            var bwp = new BowlingPerf
            {
                PlayerId = player.PlayerId,
                PlayerName = player.Name,
                Overs = overs,
                RunsGiven = (int)runBox.Value,
                Wickets = (int)wktBox.Value,
                Economy = economy
            };

            list.Add(bwp);

            int row = grid.Rows.Add(
                player.Name, bwp.Overs, bwp.RunsGiven,
                bwp.Wickets, bwp.Economy);
            grid.Rows[row].Tag = bwp;

            overBox.Value = 0; runBox.Value = 0; wktBox.Value = 0;
        }

        // ── Save Full Scorecard (Transaction) ─────────────────────────

        private void btnSaveScorecard_Click_1(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblError.Visible = false;

            if (_batting1.Count == 0 || _batting2.Count == 0)
            {
                lblError.Text = "Please add batting entries for both innings.";
                lblError.Visible = true;
                return;
            }

            var inn1BatTeam = cmbInn1BattingTeam.SelectedItem as Team;
            var inn2BatTeam = cmbInn2BattingTeam.SelectedItem as Team;
            var winner = cmbWinner.SelectedItem as Team;
            var motm = cmbMotm.SelectedItem as Player;

            var innings1 = new Innings
            {
                MatchId = _match.MatchId,
                BattingTeamId = inn1BatTeam.TeamId,
                InningsNumber = 1,
                TotalRuns = (int)nudInn1Runs.Value,
                TotalWickets = (int)nudInn1Wkts.Value,
                TotalOvers = nudInn1Overs.Value
            };

            var innings2 = new Innings
            {
                MatchId = _match.MatchId,
                BattingTeamId = inn2BatTeam.TeamId,
                InningsNumber = 2,
                TotalRuns = (int)nudInn2Runs.Value,
                TotalWickets = (int)nudInn2Wkts.Value,
                TotalOvers = nudInn2Overs.Value
            };

            var result = new MatchResult
            {
                MatchId = _match.MatchId,
                WinnerTeamId = winner.TeamId,
                Margin = (int)nudMargin.Value,
                MarginType = cmbMarginType.Text,
                MotmPlayerId = (motm != null && motm.PlayerId > 0)
                                   ? motm.PlayerId : (int?)null
            };

            try
            {
                _service.SaveFullScorecard(
                    innings1, _batting1, _bowling1,
                    innings2, _batting2, _bowling2,
                    result);

                MessageBox.Show("Scorecard saved successfully!\nPoints table has been updated.",
                    "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error saving scorecard: " + ex.Message;
                lblError.Visible = true;
                Logger.Log("ScorecardForm", ex);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e) => this.Close();

        private void homeToolStripMenuItem_Click_1(object sender, EventArgs e)
            => this.Close();

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
            => Application.Exit();
    }
}