using System;
using System.Windows.Forms;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;
using PSLCommandCentre.Services;

namespace PSLCommandCentre.Forms
{
    public partial class PlayerListForm : Form
    {
        private readonly PlayerService _service = new PlayerService();

        public PlayerListForm()
        {
            InitializeComponent();
        }

        private void PlayerListForm_Load(object sender, EventArgs e) => LoadPlayers();

        private void LoadPlayers(string keyword = "")
        {
            try
            {
                var list = string.IsNullOrWhiteSpace(keyword)
                    ? _service.GetAllPlayers()
                    : _service.SearchPlayers(keyword);

                dgvPlayers.Rows.Clear();
                foreach (var p in list)
                {
                    int row = dgvPlayers.Rows.Add(
                        p.PlayerId, p.Name, p.Role,
                        p.Nationality, p.IsForeign ? "Yes" : "No",
                        p.BattingStyle, p.BowlingStyle);

                    // Store the full Player object in the row tag for easy retrieval
                    dgvPlayers.Rows[row].Tag = p;
                }
            }
            catch (Exception ex) { Logger.Log("PlayerListForm.LoadPlayers", ex); }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            var form = new PlayerAddEditForm();
            form.ShowDialog();
            LoadPlayers();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dgvPlayers.CurrentRow == null) return;
            var player = dgvPlayers.CurrentRow.Tag as Player;
            if (player == null) return;

            var form = new PlayerAddEditForm(player);
            form.ShowDialog();
            LoadPlayers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPlayers.CurrentRow == null) return;
            var player = dgvPlayers.CurrentRow.Tag as Player;
            if (player == null) return;

            var confirm = MessageBox.Show(
                $"Delete player '{player.Name}'? This cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                bool ok = _service.DeletePlayer(player.PlayerId);
                if (ok)
                    MessageBox.Show("Player deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Could not delete. Player may be linked to match data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadPlayers();
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
            => LoadPlayers(txtSearch.Text);

        private void homeToolStripMenuItem_Click_1(object sender, EventArgs e)
            => this.Close();

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
            => Application.Exit();

      
    }
}