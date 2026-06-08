namespace PSLCommandCentre.Forms
{
    partial class PointsTableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSeason = new System.Windows.Forms.ComboBox();
            this.btnInitialise = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvPoints = new System.Windows.Forms.DataGridView();
            this.colRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlayed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNRR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPoints = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(732, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click_1);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Points Table";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Season: ";
            // 
            // cmbSeason
            // 
            this.cmbSeason.FormattingEnabled = true;
            this.cmbSeason.Location = new System.Drawing.Point(105, 73);
            this.cmbSeason.Name = "cmbSeason";
            this.cmbSeason.Size = new System.Drawing.Size(121, 24);
            this.cmbSeason.TabIndex = 3;
            this.cmbSeason.SelectedIndexChanged += new System.EventHandler(this.cmbSeason_SelectedIndexChanged_1);
            // 
            // btnInitialise
            // 
            this.btnInitialise.Location = new System.Drawing.Point(76, 103);
            this.btnInitialise.Name = "btnInitialise";
            this.btnInitialise.Size = new System.Drawing.Size(150, 23);
            this.btnInitialise.TabIndex = 4;
            this.btnInitialise.Text = "⚙ Initialise for Season";
            this.btnInitialise.UseVisualStyleBackColor = true;
            this.btnInitialise.Click += new System.EventHandler(this.btnInitialise_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "(Top 4 qualify — highlighted in green)";
            // 
            // dgvPoints
            // 
            this.dgvPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRank,
            this.colTeam,
            this.colPlayed,
            this.colWon,
            this.colLost,
            this.colNRR,
            this.colPoints});
            this.dgvPoints.Location = new System.Drawing.Point(42, 179);
            this.dgvPoints.Name = "dgvPoints";
            this.dgvPoints.RowHeadersVisible = false;
            this.dgvPoints.RowHeadersWidth = 51;
            this.dgvPoints.RowTemplate.Height = 24;
            this.dgvPoints.Size = new System.Drawing.Size(538, 282);
            this.dgvPoints.TabIndex = 6;
            // 
            // colRank
            // 
            this.colRank.FillWeight = 23.2017F;
            this.colRank.HeaderText = "#";
            this.colRank.MinimumWidth = 6;
            this.colRank.Name = "colRank";
            this.colRank.Width = 40;
            // 
            // colTeam
            // 
            this.colTeam.FillWeight = 395.3552F;
            this.colTeam.HeaderText = "Team";
            this.colTeam.MinimumWidth = 6;
            this.colTeam.Name = "colTeam";
            this.colTeam.Width = 200;
            // 
            // colPlayed
            // 
            this.colPlayed.FillWeight = 14.21104F;
            this.colPlayed.HeaderText = "P";
            this.colPlayed.MinimumWidth = 6;
            this.colPlayed.Name = "colPlayed";
            this.colPlayed.Width = 50;
            // 
            // colWon
            // 
            this.colWon.FillWeight = 14.21104F;
            this.colWon.HeaderText = "W";
            this.colWon.MinimumWidth = 6;
            this.colWon.Name = "colWon";
            this.colWon.Width = 50;
            // 
            // colLost
            // 
            this.colLost.FillWeight = 14.21104F;
            this.colLost.HeaderText = "L";
            this.colLost.MinimumWidth = 6;
            this.colLost.Name = "colLost";
            this.colLost.Width = 50;
            // 
            // colNRR
            // 
            this.colNRR.FillWeight = 14.21104F;
            this.colNRR.HeaderText = "NRR";
            this.colNRR.MinimumWidth = 6;
            this.colNRR.Name = "colNRR";
            this.colNRR.Width = 80;
            // 
            // colPoints
            // 
            this.colPoints.FillWeight = 224.599F;
            this.colPoints.HeaderText = "Pts";
            this.colPoints.MinimumWidth = 6;
            this.colPoints.Name = "colPoints";
            this.colPoints.Width = 60;
            // 
            // PointsTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 473);
            this.Controls.Add(this.dgvPoints);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnInitialise);
            this.Controls.Add(this.cmbSeason);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PointsTableForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PointsTableForm";
            this.Load += new System.EventHandler(this.PointsTableForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSeason;
        private System.Windows.Forms.Button btnInitialise;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvPoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlayed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNRR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPoints;
    }
}