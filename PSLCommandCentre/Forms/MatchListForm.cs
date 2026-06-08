using System;
using System.Windows.Forms;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;
using PSLCommandCentre.Repositories;
using PSLCommandCentre.Services;

namespace PSLCommandCentre.Forms
{
    public partial class MatchListForm : Form
    {
        private readonly MatchService _matchService = new MatchService();
        private readonly SeasonRepository _seasonRepo = new SeasonRepository();

        public MatchListForm()
        {
            InitializeComponent();
        }

        private void MatchListForm_Load(object sender, EventArgs e)
        {
            LoadSeasonFilter();
            LoadMatches();
        }

        private void LoadSeasonFilter()
        {
            cmbSeasonFilter.Items.Clear();
            cmbSeasonFilter.Items.Add(new Season { SeasonId = 0, Name = "All Seasons" });
            foreach (var s in _seasonRepo.GetAll())
                cmbSeasonFilter.Items.Add(s);

            cmbSeasonFilter.DisplayMember = "Name";
            cmbSeasonFilter.SelectedIndex = 0;
        }

        private void LoadMatches()
        {
            try
            {
                var selectedSeason = cmbSeasonFilter.SelectedItem as Season;
                var list = (selectedSeason == null || selectedSeason.SeasonId == 0)
                    ? _matchService.GetAllMatches()
                    : _matchService.GetMatchesBySeason(selectedSeason.SeasonId);

                dgvMatches.Rows.Clear();
                foreach (var m in list)
                {
                    int row = dgvMatches.Rows.Add(
                        m.MatchId,
                        m.MatchDate.ToString("dd MMM yyyy  HH:mm"),
                        m.Team1Name + "  vs  " + m.Team2Name,
                        m.VenueName,
                        m.MatchType,
                        m.Status,
                        m.SeasonName);

                    dgvMatches.Rows[row].Tag = m;

                    // Color by status
                    switch (m.Status)
                    {
                        case "Completed":
                            dgvMatches.Rows[row].DefaultCellStyle.BackColor =
                                System.Drawing.Color.LightGreen; break;
                        case "Live":
                            dgvMatches.Rows[row].DefaultCellStyle.BackColor =
                                System.Drawing.Color.LightYellow; break;
                        case "Abandoned":
                            dgvMatches.Rows[row].DefaultCellStyle.BackColor =
                                System.Drawing.Color.LightCoral; break;
                    }
                }
            }
            catch (Exception ex) { Logger.Log("MatchListForm.LoadMatches", ex); }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            var form = new MatchAddEditForm();
            form.ShowDialog();
            LoadMatches();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dgvMatches.CurrentRow == null) return;
            var match = dgvMatches.CurrentRow.Tag as Match;
            if (match == null) return;

            if (match.Status == "Completed")
            {
                MessageBox.Show("Completed matches cannot be edited.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var form = new MatchAddEditForm(match);
            form.ShowDialog();
            LoadMatches();
        }

        private void btnScorecard_Click_1(object sender, EventArgs e)
        {
            if (dgvMatches.CurrentRow == null) return;
            var match = dgvMatches.CurrentRow.Tag as Match;
            if (match == null) return;

            if (match.Status == "Scheduled")
            {
                MessageBox.Show("Cannot enter scorecard for a Scheduled match.\nChange status to Live first.",
                    "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var form = new ScorecardForm(match);
            form.ShowDialog();
            LoadMatches();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvMatches.CurrentRow == null) return;
            var match = dgvMatches.CurrentRow.Tag as Match;
            if (match == null) return;

            if (match.Status == "Completed")
            {
                MessageBox.Show("Completed matches cannot be deleted.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Delete match: {match.Team1Name} vs {match.Team2Name}?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                bool ok = _matchService.DeleteMatch(match.MatchId);
                MessageBox.Show(
                    ok ? "Match deleted." : "Could not delete match.",
                    ok ? "Success" : "Error", MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                LoadMatches();
            }
        }

        private void cmbSeasonFilter_SelectedIndexChanged_1(object sender, EventArgs e)
            => LoadMatches();

        private void homeToolStripMenuItem_Click_1(object sender, EventArgs e)
            => this.Close();

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
            => Application.Exit();

    }
}