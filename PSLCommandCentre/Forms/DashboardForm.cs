using PSLCommandCentre.Helpers;
using PSLCommandCentre.Repositories;
using System;
using System.Windows.Forms;

namespace PSLCommandCentre.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {SessionManager.Username}";
            LoadStats();
        }

        private void LoadStats()
        {
            try
            {
                lblTeamCount.Text = new TeamRepository().GetAll().Count.ToString();
                lblPlayerCount.Text = new PlayerRepository().GetAll().Count.ToString();
                lblVenueCount.Text = new VenueRepository().GetAll().Count.ToString();
                lblSeasonCount.Text = new SeasonRepository().GetAll().Count.ToString();
            }
            catch (Exception ex)
            {
                Logger.Log("DashboardForm.LoadStats", ex);
            }
        }

        // ── Navigation buttons ──────────────────────────────

        private void btnPlayers_Click_1(object sender, EventArgs e)
            => OpenForm(new PlayerListForm());

        private void btnTeams_Click_1(object sender, EventArgs e)
            => OpenForm(new TeamListForm());

        private void btnVenues_Click_1(object sender, EventArgs e)
            => OpenForm(new VenueListForm());

        private void btnSeasons_Click_1(object sender, EventArgs e)
            => OpenForm(new SeasonListForm());

        private void btnMatches_Click(object sender, EventArgs e)
            => OpenForm(new MatchListForm());

        private void btnAuction_Click_1(object sender, EventArgs e)
            => OpenForm(new AuctionForm());

        private void btnPointsTable_Click_1(object sender, EventArgs e)
            => OpenForm(new PointsTableForm());

        private void OpenForm(Form f)
        {
            f.FormClosed += (s, a) => { this.Show(); LoadStats(); };
            this.Hide();
            f.Show();
        }

        // ── File Menu ───────────────────────────────────────

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SessionManager.Clear();
            var login = new LoginForm();
            login.Show();
            this.Close();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
            => Application.Exit();
    }
}