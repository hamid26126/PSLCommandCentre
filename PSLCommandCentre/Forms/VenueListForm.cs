using System;
using System.Windows.Forms;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;
using PSLCommandCentre.Services;

namespace PSLCommandCentre.Forms
{
    public partial class VenueListForm : Form
    {
        private readonly VenueService _service = new VenueService();

        public VenueListForm()
        {
            InitializeComponent();
        }

        private void VenueListForm_Load(object sender, EventArgs e) => LoadVenues();

        private void LoadVenues(string keyword = "")
        {
            try
            {
                var list = _service.GetAllVenues();
                dgvVenues.Rows.Clear();

                foreach (var v in list)
                {
                    if (!string.IsNullOrWhiteSpace(keyword) &&
                        !v.Name.ToLower().Contains(keyword.ToLower()) &&
                        !v.City.ToLower().Contains(keyword.ToLower()))
                        continue;

                    int row = dgvVenues.Rows.Add(
                        v.VenueId, v.Name, v.City,
                        v.Capacity.ToString("N0"), v.PitchType, v.Country);

                    dgvVenues.Rows[row].Tag = v;
                }
            }
            catch (Exception ex) { Logger.Log("VenueListForm.LoadVenues", ex); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new VenueAddEditForm();
            form.ShowDialog();
            LoadVenues();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvVenues.CurrentRow == null) return;
            var venue = dgvVenues.CurrentRow.Tag as Venue;
            if (venue == null) return;

            var form = new VenueAddEditForm(venue);
            form.ShowDialog();
            LoadVenues();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvVenues.CurrentRow == null) return;
            var venue = dgvVenues.CurrentRow.Tag as Venue;
            if (venue == null) return;

            var confirm = MessageBox.Show(
                $"Delete venue '{venue.Name}'? This cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                bool ok = _service.DeleteVenue(venue.VenueId);
                MessageBox.Show(
                    ok ? "Venue deleted successfully." : "Could not delete. Venue may be linked to matches.",
                    ok ? "Success" : "Error",
                    MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                LoadVenues();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
            => LoadVenues(txtSearch.Text);

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
            => this.Close();

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
            => Application.Exit();

        private void homeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }
    }
}