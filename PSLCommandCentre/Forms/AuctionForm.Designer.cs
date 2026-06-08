namespace PSLCommandCentre.Forms
{
    partial class AuctionForm
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSeason = new System.Windows.Forms.ComboBox();
            this.dgvAuctionPool = new System.Windows.Forms.DataGridView();
            this.colAid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlayer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbRegisterPlayer = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudBasePrice = new System.Windows.Forms.NumericUpDown();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblSelectedPlayer = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbBuyingTeam = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nudSoldPrice = new System.Windows.Forms.NumericUpDown();
            this.btnSell = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuctionPool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBasePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoldPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1082, 28);
            this.menuStrip1.TabIndex = 1;
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Player Auction";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(832, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Season: ";
            // 
            // cmbSeason
            // 
            this.cmbSeason.FormattingEnabled = true;
            this.cmbSeason.Location = new System.Drawing.Point(928, 39);
            this.cmbSeason.Name = "cmbSeason";
            this.cmbSeason.Size = new System.Drawing.Size(121, 24);
            this.cmbSeason.TabIndex = 4;
            this.cmbSeason.SelectedIndexChanged += new System.EventHandler(this.cmbSeason_SelectedIndexChanged_1);
            // 
            // dgvAuctionPool
            // 
            this.dgvAuctionPool.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuctionPool.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAid,
            this.colPlayer,
            this.colRole,
            this.colNation,
            this.colBase,
            this.colSold,
            this.colTeam,
            this.colStatus});
            this.dgvAuctionPool.Location = new System.Drawing.Point(44, 93);
            this.dgvAuctionPool.Name = "dgvAuctionPool";
            this.dgvAuctionPool.RowHeadersWidth = 51;
            this.dgvAuctionPool.RowTemplate.Height = 24;
            this.dgvAuctionPool.Size = new System.Drawing.Size(589, 481);
            this.dgvAuctionPool.TabIndex = 5;
            //this.dgvAuctionPool.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAuctionPool_CellContentClick);
            this.dgvAuctionPool.SelectionChanged += new System.EventHandler(this.dgvAuctionPool_SelectionChanged);
            // 
            // colAid
            // 
            this.colAid.HeaderText = "#";
            this.colAid.MinimumWidth = 6;
            this.colAid.Name = "colAid";
            this.colAid.Width = 40;
            // 
            // colPlayer
            // 
            this.colPlayer.HeaderText = "Player";
            this.colPlayer.MinimumWidth = 6;
            this.colPlayer.Name = "colPlayer";
            this.colPlayer.Width = 150;
            // 
            // colRole
            // 
            this.colRole.HeaderText = "Role";
            this.colRole.MinimumWidth = 6;
            this.colRole.Name = "colRole";
            // 
            // colNation
            // 
            this.colNation.HeaderText = "Nation";
            this.colNation.MinimumWidth = 6;
            this.colNation.Name = "colNation";
            this.colNation.Width = 80;
            // 
            // colBase
            // 
            this.colBase.HeaderText = "Base Price";
            this.colBase.MinimumWidth = 6;
            this.colBase.Name = "colBase";
            // 
            // colSold
            // 
            this.colSold.HeaderText = "Sold Price";
            this.colSold.MinimumWidth = 6;
            this.colSold.Name = "colSold";
            // 
            // colTeam
            // 
            this.colTeam.HeaderText = "Bought By";
            this.colTeam.MinimumWidth = 6;
            this.colTeam.Name = "colTeam";
            this.colTeam.Width = 130;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 6;
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 80;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(738, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Register Player for Auction: ";
            // 
            // cmbRegisterPlayer
            // 
            this.cmbRegisterPlayer.FormattingEnabled = true;
            this.cmbRegisterPlayer.Location = new System.Drawing.Point(845, 174);
            this.cmbRegisterPlayer.Name = "cmbRegisterPlayer";
            this.cmbRegisterPlayer.Size = new System.Drawing.Size(121, 24);
            this.cmbRegisterPlayer.TabIndex = 7;
            //this.cmbRegisterPlayer.SelectedIndexChanged += new System.EventHandler(this.cmbRegisterPlayer_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(741, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Best Price (PKR): ";
            // 
            // nudBasePrice
            // 
            this.nudBasePrice.Location = new System.Drawing.Point(846, 259);
            this.nudBasePrice.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudBasePrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBasePrice.Name = "nudBasePrice";
            this.nudBasePrice.Size = new System.Drawing.Size(120, 22);
            this.nudBasePrice.TabIndex = 9;
            this.nudBasePrice.Value = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(863, 303);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(103, 23);
            this.btnRegister.TabIndex = 10;
            this.btnRegister.Text = "+ Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click_1);
            // 
            // lblSelectedPlayer
            // 
            this.lblSelectedPlayer.AutoSize = true;
            this.lblSelectedPlayer.Location = new System.Drawing.Point(744, 385);
            this.lblSelectedPlayer.Name = "lblSelectedPlayer";
            this.lblSelectedPlayer.Size = new System.Drawing.Size(103, 16);
            this.lblSelectedPlayer.TabIndex = 11;
            this.lblSelectedPlayer.Text = "Selected Player";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(754, 433);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Buying Team: ";
            // 
            // cmbBuyingTeam
            // 
            this.cmbBuyingTeam.FormattingEnabled = true;
            this.cmbBuyingTeam.Location = new System.Drawing.Point(863, 433);
            this.cmbBuyingTeam.Name = "cmbBuyingTeam";
            this.cmbBuyingTeam.Size = new System.Drawing.Size(121, 24);
            this.cmbBuyingTeam.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(750, 488);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Final Sold Price(PKR): ";
            // 
            // nudSoldPrice
            // 
            this.nudSoldPrice.Location = new System.Drawing.Point(868, 524);
            this.nudSoldPrice.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudSoldPrice.Name = "nudSoldPrice";
            this.nudSoldPrice.Size = new System.Drawing.Size(120, 22);
            this.nudSoldPrice.TabIndex = 15;
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(863, 575);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(125, 23);
            this.btnSell.TabIndex = 16;
            this.btnSell.Text = "💰 Confirm Sale";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(689, 341);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(319, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "------------------------------------------------------------------------------";
            // 
            // AuctionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 653);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.nudSoldPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbBuyingTeam);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSelectedPlayer);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.nudBasePrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbRegisterPlayer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvAuctionPool);
            this.Controls.Add(this.cmbSeason);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AuctionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AuctionForm";
            this.Load += new System.EventHandler(this.AuctionForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuctionPool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBasePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoldPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSeason;
        private System.Windows.Forms.DataGridView dgvAuctionPool;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSold;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbRegisterPlayer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudBasePrice;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblSelectedPlayer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbBuyingTeam;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudSoldPrice;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Label label7;
    }
}