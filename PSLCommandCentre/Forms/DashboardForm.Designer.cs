namespace PSLCommandCentre.Forms
{
    partial class DashboardForm
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
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTeamCount = new System.Windows.Forms.Label();
            this.lblPlayerCount = new System.Windows.Forms.Label();
            this.lblVenueCount = new System.Windows.Forms.Label();
            this.lblSeasonCount = new System.Windows.Forms.Label();
            this.btnPlayers = new System.Windows.Forms.Button();
            this.btnTeams = new System.Windows.Forms.Button();
            this.btnVenues = new System.Windows.Forms.Button();
            this.btnSeasons = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.logoutToolStripMenuItem.Text = "Logout";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(321, 30);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(175, 25);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome, Admin";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSeasonCount);
            this.panel1.Controls.Add(this.lblVenueCount);
            this.panel1.Controls.Add(this.lblPlayerCount);
            this.panel1.Controls.Add(this.lblTeamCount);
            this.panel1.Location = new System.Drawing.Point(90, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 100);
            this.panel1.TabIndex = 2;
            // 
            // lblTeamCount
            // 
            this.lblTeamCount.AutoSize = true;
            this.lblTeamCount.Location = new System.Drawing.Point(17, 15);
            this.lblTeamCount.Name = "lblTeamCount";
            this.lblTeamCount.Size = new System.Drawing.Size(14, 16);
            this.lblTeamCount.TabIndex = 0;
            this.lblTeamCount.Text = "0";
            // 
            // lblPlayerCount
            // 
            this.lblPlayerCount.AutoSize = true;
            this.lblPlayerCount.Location = new System.Drawing.Point(89, 15);
            this.lblPlayerCount.Name = "lblPlayerCount";
            this.lblPlayerCount.Size = new System.Drawing.Size(14, 16);
            this.lblPlayerCount.TabIndex = 1;
            this.lblPlayerCount.Text = "0";
            // 
            // lblVenueCount
            // 
            this.lblVenueCount.AutoSize = true;
            this.lblVenueCount.Location = new System.Drawing.Point(169, 15);
            this.lblVenueCount.Name = "lblVenueCount";
            this.lblVenueCount.Size = new System.Drawing.Size(14, 16);
            this.lblVenueCount.TabIndex = 2;
            this.lblVenueCount.Text = "0";
            // 
            // lblSeasonCount
            // 
            this.lblSeasonCount.AutoSize = true;
            this.lblSeasonCount.Location = new System.Drawing.Point(233, 15);
            this.lblSeasonCount.Name = "lblSeasonCount";
            this.lblSeasonCount.Size = new System.Drawing.Size(14, 16);
            this.lblSeasonCount.TabIndex = 3;
            this.lblSeasonCount.Text = "0";
            // 
            // btnPlayers
            // 
            this.btnPlayers.Location = new System.Drawing.Point(64, 222);
            this.btnPlayers.Name = "btnPlayers";
            this.btnPlayers.Size = new System.Drawing.Size(103, 23);
            this.btnPlayers.TabIndex = 3;
            this.btnPlayers.Text = "🏏 Players";
            this.btnPlayers.UseVisualStyleBackColor = true;
            // 
            // btnTeams
            // 
            this.btnTeams.Location = new System.Drawing.Point(207, 222);
            this.btnTeams.Name = "btnTeams";
            this.btnTeams.Size = new System.Drawing.Size(103, 23);
            this.btnTeams.TabIndex = 4;
            this.btnTeams.Text = "👥 Teams";
            this.btnTeams.UseVisualStyleBackColor = true;
            // 
            // btnVenues
            // 
            this.btnVenues.Location = new System.Drawing.Point(366, 222);
            this.btnVenues.Name = "btnVenues";
            this.btnVenues.Size = new System.Drawing.Size(103, 23);
            this.btnVenues.TabIndex = 5;
            this.btnVenues.Text = "🏟 Venues";
            this.btnVenues.UseVisualStyleBackColor = true;
            // 
            // btnSeasons
            // 
            this.btnSeasons.Location = new System.Drawing.Point(522, 222);
            this.btnSeasons.Name = "btnSeasons";
            this.btnSeasons.Size = new System.Drawing.Size(103, 23);
            this.btnSeasons.TabIndex = 6;
            this.btnSeasons.Text = "📅 Seasons";
            this.btnSeasons.UseVisualStyleBackColor = true;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSeasons);
            this.Controls.Add(this.btnVenues);
            this.Controls.Add(this.btnTeams);
            this.Controls.Add(this.btnPlayers);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DashboardForm";
            this.Text = "DashboardForm";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSeasonCount;
        private System.Windows.Forms.Label lblVenueCount;
        private System.Windows.Forms.Label lblPlayerCount;
        private System.Windows.Forms.Label lblTeamCount;
        private System.Windows.Forms.Button btnPlayers;
        private System.Windows.Forms.Button btnTeams;
        private System.Windows.Forms.Button btnVenues;
        private System.Windows.Forms.Button btnSeasons;
    }
}