using System;
using System.Windows.Forms;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;
using PSLCommandCentre.Services;

namespace PSLCommandCentre.Forms
{
    public partial class SeasonListForm : Form
    {
        private readonly SeasonService _service = new SeasonService();

        public SeasonListForm()
        {
            InitializeComponent();
        }

        private void SeasonListForm_Load(object sender, EventArgs e) => LoadSeasons();

        private void LoadSeasons()
        {
            try
            {
                var list = _service.GetAllSeasons();
                dgvSeasons.Rows.Clear();

                foreach (var s in list)
                {
                    int row = dgvSeasons.Rows.Add(
                        s.SeasonId,
                        s.Name,
                        s.Year,
                        s.StartDate.ToString("dd MMM yyyy"),
                        s.EndDate.ToString("dd MMM yyyy"),
                        s.Status);

                    dgvSeasons.Rows[row].Tag = s;

                    // Color-code by status
                    if (s.Status == "Active")
                        dgvSeasons.Rows[row].DefaultCellStyle.BackColor =
                            System.Drawing.Color.LightGreen;
                    else if (s.Status == "Completed")
                        dgvSeasons.Rows[row].DefaultCellStyle.BackColor =
                            System.Drawing.Color.LightGray;
                }
            }
            catch (Exception ex) { Logger.Log("SeasonListForm.LoadSeasons", ex); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new SeasonAddEditForm();
            form.ShowDialog();
            LoadSeasons();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSeasons.CurrentRow == null) return;
            var season = dgvSeasons.CurrentRow.Tag as Season;
            if (season == null) return;

            var form = new SeasonAddEditForm(season);
            form.ShowDialog();
            LoadSeasons();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSeasons.CurrentRow == null) return;
            var season = dgvSeasons.CurrentRow.Tag as Season;
            if (season == null) return;

            if (season.Status == "Active")
            {
                MessageBox.Show(
                    "Cannot delete an Active season. Change its status first.",
                    "Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Delete season '{season.Name}'? All related data will be affected.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                bool ok = _service.DeleteSeason(season.SeasonId);
                MessageBox.Show(
                    ok ? "Season deleted." : "Could not delete. Season has linked data.",
                    ok ? "Success" : "Error",
                    MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                LoadSeasons();
            }
        }

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