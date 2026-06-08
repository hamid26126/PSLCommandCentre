using System;
using System.Windows.Forms;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;
using PSLCommandCentre.Repositories;
using PSLCommandCentre.Services;

namespace PSLCommandCentre.Forms
{
    public partial class MatchAddEditForm : Form
    {
        private readonly MatchService _matchService = new MatchService();
        private readonly SeasonRepository _seasonRepo = new SeasonRepository();
        private readonly TeamRepository _teamRepo = new TeamRepository();
        private readonly VenueRepository _venueRepo = new VenueRepository();
        private readonly Match _existing;
        private readonly bool _isEdit;

        public MatchAddEditForm()
        {
            InitializeComponent();
            _isEdit = false;
        }

        public MatchAddEditForm(Match m)
        {
            InitializeComponent();
            _existing = m;
            _isEdit = true;
        }

        private void MatchAddEditForm_Load(object sender, EventArgs e)
        {
            LoadDropdowns();

            cmbType.Items.AddRange(new[]
                { "League", "Qualifier", "Eliminator", "Final" });

            cmbStatus.Items.AddRange(new[]
                { "Scheduled", "Live", "Completed", "Abandoned" });

            if (_isEdit)
            {
                lblTitle.Text = "Edit Match";
                btnSave.Text = "Update Match";
                dtpMatchDate.Value = _existing.MatchDate;
                cmbType.Text = _existing.MatchType;
                cmbStatus.Text = _existing.Status;

                SelectComboItem(cmbSeason, "SeasonId", _existing.SeasonId);
                SelectComboItem(cmbTeam1, "TeamId", _existing.Team1Id);
                SelectComboItem(cmbTeam2, "TeamId", _existing.Team2Id);
                SelectComboItem(cmbVenue, "VenueId", _existing.VenueId);
            }
            else
            {
                lblTitle.Text = "Schedule New Match";
                btnSave.Text = "Save Match";
                dtpMatchDate.Value = DateTime.Today.AddDays(1);
                cmbType.SelectedIndex = 0;
                cmbStatus.SelectedIndex = 0;
            }
        }

        private void LoadDropdowns()
        {
            // Seasons
            cmbSeason.Items.Clear();
            cmbSeason.Items.Add(new Season { SeasonId = 0, Name = "-- Select Season --" });
            foreach (var s in _seasonRepo.GetAll())
                cmbSeason.Items.Add(s);
            cmbSeason.DisplayMember = "Name";
            cmbSeason.SelectedIndex = 0;

            // Teams
            var teams = _teamRepo.GetAll();

            cmbTeam1.Items.Clear();
            cmbTeam1.Items.Add(new Team { TeamId = 0, Name = "-- Select Team 1 --" });
            foreach (var t in teams) cmbTeam1.Items.Add(t);
            cmbTeam1.DisplayMember = "Name";
            cmbTeam1.SelectedIndex = 0;

            cmbTeam2.Items.Clear();
            cmbTeam2.Items.Add(new Team { TeamId = 0, Name = "-- Select Team 2 --" });
            foreach (var t in teams) cmbTeam2.Items.Add(t);
            cmbTeam2.DisplayMember = "Name";
            cmbTeam2.SelectedIndex = 0;

            // Venues
            cmbVenue.Items.Clear();
            cmbVenue.Items.Add(new Venue { VenueId = 0, Name = "-- Select Venue --" });
            foreach (var v in _venueRepo.GetAll()) cmbVenue.Items.Add(v);
            cmbVenue.DisplayMember = "Name";
            cmbVenue.SelectedIndex = 0;
        }

        // Helper to pre-select correct item in edit mode
        private void SelectComboItem(ComboBox cmb, string idProperty, int idValue)
        {
            foreach (var item in cmb.Items)
            {
                var prop = item.GetType().GetProperty(idProperty);
                if (prop != null && (int)prop.GetValue(item) == idValue)
                {
                    cmb.SelectedItem = item;
                    return;
                }
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblError.Visible = false;

            var season = cmbSeason.SelectedItem as Season;
            var team1 = cmbTeam1.SelectedItem as Team;
            var team2 = cmbTeam2.SelectedItem as Team;
            var venue = cmbVenue.SelectedItem as Venue;

            var match = new Match
            {
                MatchId = _isEdit ? _existing.MatchId : 0,
                SeasonId = season?.SeasonId ?? 0,
                Team1Id = team1?.TeamId ?? 0,
                Team2Id = team2?.TeamId ?? 0,
                VenueId = venue?.VenueId ?? 0,
                MatchDate = dtpMatchDate.Value,
                MatchType = cmbType.Text,
                Status = cmbStatus.Text
            };

            try
            {
                if (_isEdit)
                {
                    bool ok = _matchService.UpdateMatch(match);
                    if (ok) this.Close();
                    else { lblError.Text = "Update failed."; lblError.Visible = true; }
                }
                else
                {
                    int newId = _matchService.AddMatch(match);
                    if (newId > 0) this.Close();
                    else { lblError.Text = "Could not save match."; lblError.Visible = true; }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                Logger.Log("MatchAddEditForm", ex);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e) => this.Close();

        private void cmbSeason_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}