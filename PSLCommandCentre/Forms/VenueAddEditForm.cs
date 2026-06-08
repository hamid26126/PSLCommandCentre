using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;
using PSLCommandCentre.Services;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PSLCommandCentre.Forms
{
    public partial class VenueAddEditForm : Form
    {
        private readonly VenueService _service = new VenueService();
        private readonly Venue _existing;
        private readonly bool _isEdit;

        public VenueAddEditForm()
        {
            InitializeComponent();
            _isEdit = false;
        }

        public VenueAddEditForm(Venue v)
        {
            InitializeComponent();
            _existing = v;
            _isEdit = true;
        }

        private void VenueAddEditForm_Load(object sender, EventArgs e)
        {
            cmbPitchType.Items.Clear();
            cmbPitchType.Items.AddRange(new[]
            {
                "Batting Friendly", "Bowling Friendly",
                "Balanced", "Spin Friendly"
            });

            if (_isEdit)
            {
                lblTitle.Text = "Edit Venue";
                btnSave.Text = "Update Venue";
                txtName.Text = _existing.Name;
                txtCity.Text = _existing.City;
                nudCapacity.Value = _existing.Capacity > 0 ? _existing.Capacity : 1;
                cmbPitchType.Text = _existing.PitchType;
                txtCountry.Text = _existing.Country;
            }
            else
            {
                lblTitle.Text = "Add New Venue";
                btnSave.Text = "Save Venue";
                txtCountry.Text = "Pakistan";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblError.Visible = false;

            var venue = new Venue
            {
                VenueId = _isEdit ? _existing.VenueId : 0,
                Name = txtName.Text.Trim(),
                City = txtCity.Text.Trim(),
                Capacity = (int)nudCapacity.Value,
                PitchType = cmbPitchType.Text,
                Country = txtCountry.Text.Trim()
            };

            try
            {
                bool ok = _isEdit
                    ? _service.UpdateVenue(venue)
                    : _service.AddVenue(venue);

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
                Logger.Log("VenueAddEditForm", ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}