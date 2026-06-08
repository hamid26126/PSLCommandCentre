using Org.BouncyCastle.Asn1.Cmp;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;
using PSLCommandCentre.Services;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PSLCommandCentre.Forms
{
    public partial class SeasonAddEditForm : Form
    {
        private readonly SeasonService _service = new SeasonService();
        private readonly Season _existing;
        private readonly bool _isEdit;

        public SeasonAddEditForm()
        {
            InitializeComponent();
            _isEdit = false;
        }

        public SeasonAddEditForm(Season s)
        {
            InitializeComponent();
            _existing = s;
            _isEdit = true;
        }

        private void SeasonAddEditForm_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new[] { "Upcoming", "Active", "Completed" });

            if (_isEdit)
            {
                lblTitle.Text = "Edit Season";
                btnSave.Text = "Update Season";
                txtName.Text = _existing.Name;
                nudYear.Value = _existing.Year;
                dtpStart.Value = _existing.StartDate;
                dtpEnd.Value = _existing.EndDate;
                cmbStatus.Text = _existing.Status;
            }
            else
            {
                lblTitle.Text = "Add New Season";
                btnSave.Text = "Save Season";
                nudYear.Value = DateTime.Today.Year;
                dtpStart.Value = DateTime.Today;
                dtpEnd.Value = DateTime.Today.AddMonths(2);
                cmbStatus.SelectedIndex = 0;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblError.Visible = false;

            var season = new Season
            {
                SeasonId = _isEdit ? _existing.SeasonId : 0,
                Name = txtName.Text.Trim(),
                Year = (int)nudYear.Value,
                StartDate = dtpStart.Value,
                EndDate = dtpEnd.Value,
                Status = cmbStatus.Text
            };

            try
            {
                bool ok = _isEdit
                    ? _service.UpdateSeason(season)
                    : _service.AddSeason(season);

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
                Logger.Log("SeasonAddEditForm", ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();
    }
}