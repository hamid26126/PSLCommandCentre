using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;
using PSLCommandCentre.Services;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PSLCommandCentre.Forms
{
    public partial class TeamAddEditForm : Form
    {
        private readonly TeamService _teamService = new TeamService();
        private readonly VenueService _venueService = new VenueService();
        private readonly Team _existing;
        private readonly bool _isEdit;

        public TeamAddEditForm()
        {
            InitializeComponent();
            _isEdit = false;
        }

        public TeamAddEditForm(Team t)
        {
            InitializeComponent();
            _existing = t;
            _isEdit = true;
        }

        private void TeamAddEditForm_Load(object sender, EventArgs e)
        {
            LoadVenueDropdown();

            if (_isEdit)
            {
                lblTitle.Text = "Edit Team";
                btnSave.Text = "Update Team";
                txtName.Text = _existing.Name;
                txtCity.Text = _existing.City;
                txtOwner.Text = _existing.Owner;
                nudBudget.Value = _existing.Budget > nudBudget.Maximum
                                    ? nudBudget.Maximum : _existing.Budget;

                // Pre-select the correct venue in dropdown
                if (_existing.HomeVenueId.HasValue)
                {
                    foreach (var item in cmbVenue.Items)
                    {
                        var v = item as Venue;
                        if (v != null && v.VenueId == _existing.HomeVenueId.Value)
                        {
                            cmbVenue.SelectedItem = v;
                            break;
                        }
                    }
                }
            }
            else
            {
                lblTitle.Text = "Add New Team";
                btnSave.Text = "Save Team";
            }
        }

        private void LoadVenueDropdown()
        {
            cmbVenue.Items.Clear();

            // Blank option first
            var blank = new Venue { VenueId = 0, Name = "-- No Home Venue --" };
            cmbVenue.Items.Add(blank);

            foreach (var v in _venueService.GetAllVenues())
                cmbVenue.Items.Add(v);

            cmbVenue.DisplayMember = "Name";
            cmbVenue.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblError.Visible = false;

            var selectedVenue = cmbVenue.SelectedItem as Venue;

            var team = new Team
            {
                TeamId = _isEdit ? _existing.TeamId : 0,
                Name = txtName.Text.Trim(),
                City = txtCity.Text.Trim(),
                Owner = txtOwner.Text.Trim(),
                HomeVenueId = (selectedVenue != null && selectedVenue.VenueId > 0)
                                  ? selectedVenue.VenueId
                                  : (int?)null,
                Budget = nudBudget.Value
            };

            try
            {
                bool ok = _isEdit
                    ? _teamService.UpdateTeam(team)
                    : _teamService.AddTeam(team);

                if (ok)
                    this.Close();
                else
                {
                    lblError.Text = "Operation failed. Please try again.";
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                Logger.Log("TeamAddEditForm", ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}