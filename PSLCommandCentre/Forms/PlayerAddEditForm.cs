using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;
using PSLCommandCentre.Services;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PSLCommandCentre.Forms
{
    public partial class PlayerAddEditForm : Form
    {
        private readonly PlayerService _service = new PlayerService();
        private readonly Player _existing;
        private readonly bool _isEdit;

        // Add mode
        public PlayerAddEditForm()
        {
            InitializeComponent();
            _isEdit = false;
        }

        // Edit mode
        public PlayerAddEditForm(Player existing)
        {
            InitializeComponent();
            _existing = existing;
            _isEdit = true;
        }

        private void PlayerAddEditForm_Load(object sender, EventArgs e)
        {
            // Populate dropdowns
            cmbRole.Items.AddRange(new[] { "Batsman", "Bowler", "All-Rounder", "Wicket-Keeper" });
            cmbBatting.Items.AddRange(new[] { "Right-Hand", "Left-Hand", "N/A" });
            cmbBowling.Items.AddRange(new[] {
                "Right-Arm Fast", "Right-Arm Medium", "Right-Arm Off-Break",
                "Left-Arm Fast", "Left-Arm Medium", "Left-Arm Chinaman",
                "Leg-Break", "N/A" });

            if (_isEdit)
            {
                lblTitle.Text = "Edit Player";
                btnSave.Text = "Update Player";
                txtName.Text = _existing.Name;
                dtpDOB.Value = _existing.DateOfBirth ?? DateTime.Today.AddYears(-20);
                txtNationality.Text = _existing.Nationality;
                cmbRole.Text = _existing.Role;
                cmbRole.Text = _existing.BattingStyle;
                cmbBowling.Text = _existing.BowlingStyle;
                chkForeign.Checked = _existing.IsForeign;
            }
            else
            {
                lblTitle.Text = "Add New Player";
                btnSave.Text = "Save Player";
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblError.Visible = false;

            var player = new Player
            {
                PlayerId = _isEdit ? _existing.PlayerId : 0,
                Name = txtName.Text.Trim(),
                DateOfBirth = dtpDOB.Value,
                Nationality = txtNationality.Text.Trim(),
                Role = cmbRole.Text,
                BattingStyle = cmbBatting.Text,
                BowlingStyle = cmbBowling.Text,
                IsForeign = chkForeign.Checked
            };

            try
            {
                bool ok = _isEdit
                    ? _service.UpdatePlayer(player)
                    : _service.AddPlayer(player);

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
                Logger.Log("PlayerAddEditForm", ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

    }
}