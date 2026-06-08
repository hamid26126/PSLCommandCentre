using System;
using System.Windows.Forms;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;
using PSLCommandCentre.Repositories;
using PSLCommandCentre.Services;

namespace PSLCommandCentre.Forms
{
    public partial class PointsTableForm : Form
    {
        private readonly PointsTableService _service = new PointsTableService();
        private readonly SeasonRepository _seasonRepo = new SeasonRepository();
        private readonly TeamRepository _teamRepo = new TeamRepository();

        public PointsTableForm()
        {
            InitializeComponent();
        }

        private void PointsTableForm_Load(object sender, EventArgs e)
        {
            LoadSeasons();
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

        private void LoadStandings(int seasonId)
        {
            try
            {
                var standings = _service.GetStandings(seasonId);
                dgvPoints.Rows.Clear();
                int rank = 1;

                foreach (var row in standings)
                {
                    int i = dgvPoints.Rows.Add(
                        rank++, row.TeamName,
                        row.Played, row.Won, row.Lost,
                        row.NRR.ToString("+0.000;-0.000"),
                        row.Points);

                    // Top 4 qualify — highlight them
                    if (rank - 1 <= 4)
                        dgvPoints.Rows[i].DefaultCellStyle.BackColor =
                            System.Drawing.Color.LightGreen;
                }
            }
            catch (Exception ex) { Logger.Log("PointsTableForm.LoadStandings", ex); }
        }

        private void btnInitialise_Click_1(object sender, EventArgs e)
        {
            var season = cmbSeason.SelectedItem as Season;
            if (season == null || season.SeasonId == 0)
            {
                MessageBox.Show("Please select a season.", "Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get all teams and create 0-row PointsTable entries for this season
            var teams = _teamRepo.GetAll();
            var teamIds = new System.Collections.Generic.List<int>();
            foreach (var t in teams) teamIds.Add(t.TeamId);

            bool ok = _service.InitialiseForSeason(season.SeasonId, teamIds);
            MessageBox.Show(
                ok ? "Points table initialised for all teams.\nStart entering match results!" : "Already initialised or error occurred.",
                ok ? "Done" : "Notice",
                MessageBoxButtons.OK,
                ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            LoadStandings(season.SeasonId);
        }

        private void cmbSeason_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var season = cmbSeason.SelectedItem as Season;
            if (season == null || season.SeasonId == 0) return;
            LoadStandings(season.SeasonId);
        }

        private void homeToolStripMenuItem_Click_1(object sender, EventArgs e)
            => this.Close();

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
            => Application.Exit();
    }
}