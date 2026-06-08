using System;
using System.Windows.Forms;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;
using PSLCommandCentre.Services;

namespace PSLCommandCentre.Forms
{
    public partial class TeamListForm : Form
    {
        private readonly TeamService _service = new TeamService();

        public TeamListForm()
        {
            InitializeComponent();
        }

        private void TeamListForm_Load(object sender, EventArgs e) => LoadTeams();

        private void LoadTeams(string keyword = "")
        {
            try
            {
                var list = _service.GetAllTeams();
                dgvTeams.Rows.Clear();

                foreach (var t in list)
                {
                    if (!string.IsNullOrWhiteSpace(keyword) &&
                        !t.Name.ToLower().Contains(keyword.ToLower()) &&
                        !t.City.ToLower().Contains(keyword.ToLower()))
                        continue;

                    int row = dgvTeams.Rows.Add(
                        t.TeamId,
                        t.Name,
                        t.City,
                        t.Owner,
                        t.HomeVenueName,
                        t.Budget.ToString("N0") + " PKR");

                    dgvTeams.Rows[row].Tag = t;
                }
            }
            catch (Exception ex) { Logger.Log("TeamListForm.LoadTeams", ex); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new TeamAddEditForm();
            form.ShowDialog();
            LoadTeams();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTeams.CurrentRow == null) return;
            var team = dgvTeams.CurrentRow.Tag as Team;
            if (team == null) return;

            var form = new TeamAddEditForm(team);
            form.ShowDialog();
            LoadTeams();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTeams.CurrentRow == null) return;
            var team = dgvTeams.CurrentRow.Tag as Team;
            if (team == null) return;

            var confirm = MessageBox.Show(
                $"Delete team '{team.Name}'?\nThis will also remove all squad assignments.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                bool ok = _service.DeleteTeam(team.TeamId);
                MessageBox.Show(
                    ok ? "Team deleted successfully." : "Could not delete. Team has linked matches or players.",
                    ok ? "Success" : "Error",
                    MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                LoadTeams();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
            => LoadTeams(txtSearch.Text);

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
            => this.Close();

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
            => Application.Exit();

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void homeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }
    }
}