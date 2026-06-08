namespace PSLCommandCentre.Forms
{
    partial class TeamAddEditForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.nudBudget = new System.Windows.Forms.NumericUpDown();
            this.cmbVenue = new System.Windows.Forms.ComboBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBudget)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(13, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(219, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Team";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.cmbVenue);
            this.panel1.Controls.Add(this.nudBudget);
            this.panel1.Controls.Add(this.txtOwner);
            this.panel1.Controls.Add(this.txtCity);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 229);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Team Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "City:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Owner:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Home Venue:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Budget (PKR):";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(167, -1);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 26);
            this.txtName.TabIndex = 5;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(167, 25);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(100, 26);
            this.txtCity.TabIndex = 6;
            // 
            // txtOwner
            // 
            this.txtOwner.Location = new System.Drawing.Point(167, 57);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(100, 26);
            this.txtOwner.TabIndex = 7;
            // 
            // nudBudget
            // 
            this.nudBudget.Location = new System.Drawing.Point(167, 153);
            this.nudBudget.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudBudget.Name = "nudBudget";
            this.nudBudget.Size = new System.Drawing.Size(120, 26);
            this.nudBudget.TabIndex = 8;
            this.nudBudget.ThousandsSeparator = true;
            // 
            // cmbVenue
            // 
            this.cmbVenue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVenue.FormattingEnabled = true;
            this.cmbVenue.Location = new System.Drawing.Point(167, 107);
            this.cmbVenue.Name = "cmbVenue";
            this.cmbVenue.Size = new System.Drawing.Size(121, 28);
            this.cmbVenue.TabIndex = 9;
            this.cmbVenue.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(13, 328);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 20);
            this.lblError.TabIndex = 2;
            this.lblError.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(349, 201);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save Team";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(257, 201);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // TeamAddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 374);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TeamAddEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Team Details";
            this.Load += new System.EventHandler(this.TeamAddEditForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBudget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbVenue;
        private System.Windows.Forms.NumericUpDown nudBudget;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblError;
    }
}