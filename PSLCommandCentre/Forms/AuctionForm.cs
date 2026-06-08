using System;
using System.Windows.Forms;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;
using PSLCommandCentre.Repositories;
using PSLCommandCentre.Services;

namespace PSLCommandCentre.Forms
{
    public partial class AuctionForm : Form
    {
        private readonly AuctionService _auctionService = new AuctionService();
        private readonly SeasonRepository _seasonRepo = new SeasonRepository();
        private readonly TeamRepository _teamRepo = new TeamRepository();
        private int _currentSeasonId = 0;

        public AuctionForm()
        {
            InitializeComponent();
        }

        private void AuctionForm_Load(object sender, EventArgs e)
        {
            LoadSeasons();
            LoadTeams();
        }

        private void LoadSeasons()
        {
            cmbSeason.Items.Clear();
            cmbSeason.Items.Add(new Season { SeasonId = 0, Name = "-- Select Season --" });
            foreach (var s in _seasonRepo.GetAll())
                cmbSeason.Items.Add(s);
            cmbSeason.DisplayMember = "Name";
            cmbSeason.SelectedIndex = 0;
        }

        private void LoadTeams()
        {
            cmbBuyingTeam.Items.Clear();
            cmbBuyingTeam.Items.Add(new Team { TeamId = 0, Name = "-- Select Team --" });
            foreach (var t in _teamRepo.GetAll())
                cmbBuyingTeam.Items.Add(t);
            cmbBuyingTeam.DisplayMember = "Name";
            cmbBuyingTeam.SelectedIndex = 0;
        }

        private void cmbSeason_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var season = cmbSeason.SelectedItem as Season;
            if (season == null || season.SeasonId == 0) return;
            _currentSeasonId = season.SeasonId;
            LoadAuctionPool();
            LoadUnregisteredPlayers();
        }

        private void LoadAuctionPool()
        {
            try
            {
                var list = _auctionService.GetSeasonAuction(_currentSeasonId);
                dgvAuctionPool.Rows.Clear();

                foreach (var a in list)
                {
                    int row = dgvAuctionPool.Rows.Add(
                        a.AuctionId,
                        a.PlayerName,
                        a.PlayerRole,
                        a.PlayerNation,
                        a.BasePrice.ToString("N0"),
                        a.SoldPrice.HasValue ? a.SoldPrice.Value.ToString("N0") : "-",
                        a.BoughtByTeamName,
                        a.Status);

                    dgvAuctionPool.Rows[row].Tag = a;

                    if (a.Status == "Sold")
                        dgvAuctionPool.Rows[row].DefaultCellStyle.BackColor =
                            System.Drawing.Color.LightGreen;
                }
            }
            catch (Exception ex) { Logger.Log("AuctionForm.LoadAuctionPool", ex); }
        }

        private void LoadUnregisteredPlayers()
        {
            try
            {
                var list = _auctionService.GetUnregisteredPlayers(_currentSeasonId);
                cmbRegisterPlayer.Items.Clear();
                foreach (var p in list) cmbRegisterPlayer.Items.Add(p);
                cmbRegisterPlayer.DisplayMember = "Name";
                if (cmbRegisterPlayer.Items.Count > 0)
                    cmbRegisterPlayer.SelectedIndex = 0;
            }
            catch (Exception ex) { Logger.Log("AuctionForm.LoadUnregisteredPlayers", ex); }
        }

        // ── Register player into auction pool ─────────────────────────

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            if (_currentSeasonId == 0)
            {
                MessageBox.Show("Please select a season first.", "Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var player = cmbRegisterPlayer.SelectedItem as Player;
            if (player == null) return;

            bool ok = _auctionService.RegisterPlayerForAuction(
                player.PlayerId, _currentSeasonId, nudBasePrice.Value);

            MessageBox.Show(
                ok ? $"{player.Name} added to auction pool."
                   : "Could not register player. Already registered?",
                ok ? "Done" : "Error",
                MessageBoxButtons.OK,
                ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            LoadAuctionPool();
            LoadUnregisteredPlayers();
        }

        // ── Sell player (Transaction 2) ───────────────────────────────

        private void btnSell_Click_1(object sender, EventArgs e)
        {
            if (dgvAuctionPool.CurrentRow == null) return;
            var draft = dgvAuctionPool.CurrentRow.Tag as AuctionDraft;
            if (draft == null) return;

            if (draft.Status == "Sold")
            {
                MessageBox.Show("This player is already sold.", "Already Sold",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var team = cmbBuyingTeam.SelectedItem as Team;
            if (team == null || team.TeamId == 0)
            {
                MessageBox.Show("Please select a buying team.", "Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal soldPrice = nudSoldPrice.Value;

            var confirm = MessageBox.Show(
                $"Sell {draft.PlayerName} to {team.Name} for PKR {soldPrice:N0}?",
                "Confirm Sale",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                _auctionService.SellPlayer(draft, team.TeamId, soldPrice);
                MessageBox.Show(
                    $"{draft.PlayerName} sold to {team.Name}!\nBudget deducted.",
                    "Sale Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAuctionPool();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sale failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Log("AuctionForm.btnSell", ex);
            }
        }

        private void dgvAuctionPool_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAuctionPool.CurrentRow == null) return;
            var draft = dgvAuctionPool.CurrentRow.Tag as AuctionDraft;
            if (draft == null) return;

            // Auto-fill sold price with base price as starting point
            nudSoldPrice.Value = draft.BasePrice <= nudSoldPrice.Maximum
                ? draft.BasePrice : nudSoldPrice.Maximum;

            lblSelectedPlayer.Text =
                $"Selected: {draft.PlayerName}  |  " +
                $"Role: {draft.PlayerRole}  |  " +
                $"Base: PKR {draft.BasePrice:N0}  |  " +
                $"Status: {draft.Status}";
        }

        private void homeToolStripMenuItem_Click_1(object sender, EventArgs e)
            => this.Close();

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
            => Application.Exit();

    }
}