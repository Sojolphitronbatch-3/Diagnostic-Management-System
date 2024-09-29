namespace Diagnostic_Management_System
{
    partial class Userfrm
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
            this.closebtn = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.listBoxDiagnosticCenters = new System.Windows.Forms.ListBox();
            this.labelDiagnosticCenterName = new System.Windows.Forms.Label();
            this.labelDiagnosticCenterAddress = new System.Windows.Forms.Label();
            this.panelInformation = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelAvgRating = new System.Windows.Forms.Label();
            this.labelDiagnosticCenterID = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panelInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // closebtn
            // 
            this.closebtn.BackColor = System.Drawing.Color.Transparent;
            this.closebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closebtn.FlatAppearance.BorderSize = 0;
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.ForeColor = System.Drawing.Color.Red;
            this.closebtn.Location = new System.Drawing.Point(1378, 1);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(40, 40);
            this.closebtn.TabIndex = 1;
            this.closebtn.Text = "X";
            this.closebtn.UseVisualStyleBackColor = false;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatAppearance.BorderSize = 3;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(669, 537);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(119, 43);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // listBoxDiagnosticCenters
            // 
            this.listBoxDiagnosticCenters.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxDiagnosticCenters.FormattingEnabled = true;
            this.listBoxDiagnosticCenters.ItemHeight = 29;
            this.listBoxDiagnosticCenters.Location = new System.Drawing.Point(21, 104);
            this.listBoxDiagnosticCenters.Name = "listBoxDiagnosticCenters";
            this.listBoxDiagnosticCenters.Size = new System.Drawing.Size(472, 468);
            this.listBoxDiagnosticCenters.TabIndex = 3;
            this.listBoxDiagnosticCenters.SelectedIndexChanged += new System.EventHandler(this.listBoxDiagnosticCenters_SelectedIndexChanged);
            // 
            // labelDiagnosticCenterName
            // 
            this.labelDiagnosticCenterName.AutoSize = true;
            this.labelDiagnosticCenterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiagnosticCenterName.Location = new System.Drawing.Point(31, 121);
            this.labelDiagnosticCenterName.Name = "labelDiagnosticCenterName";
            this.labelDiagnosticCenterName.Size = new System.Drawing.Size(64, 25);
            this.labelDiagnosticCenterName.TabIndex = 4;
            this.labelDiagnosticCenterName.Text = "Name";
            // 
            // labelDiagnosticCenterAddress
            // 
            this.labelDiagnosticCenterAddress.AutoSize = true;
            this.labelDiagnosticCenterAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiagnosticCenterAddress.Location = new System.Drawing.Point(31, 238);
            this.labelDiagnosticCenterAddress.Name = "labelDiagnosticCenterAddress";
            this.labelDiagnosticCenterAddress.Size = new System.Drawing.Size(85, 25);
            this.labelDiagnosticCenterAddress.TabIndex = 5;
            this.labelDiagnosticCenterAddress.Text = "Address";
            // 
            // panelInformation
            // 
            this.panelInformation.BackColor = System.Drawing.Color.White;
            this.panelInformation.Controls.Add(this.label1);
            this.panelInformation.Controls.Add(this.labelAvgRating);
            this.panelInformation.Controls.Add(this.labelDiagnosticCenterID);
            this.panelInformation.Controls.Add(this.labelDiagnosticCenterAddress);
            this.panelInformation.Controls.Add(this.labelDiagnosticCenterName);
            this.panelInformation.Location = new System.Drawing.Point(982, 104);
            this.panelInformation.Name = "panelInformation";
            this.panelInformation.Size = new System.Drawing.Size(389, 476);
            this.panelInformation.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 26);
            this.label1.TabIndex = 7;
            this.label1.Text = "Information";
            // 
            // labelAvgRating
            // 
            this.labelAvgRating.AutoSize = true;
            this.labelAvgRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAvgRating.Location = new System.Drawing.Point(31, 302);
            this.labelAvgRating.Name = "labelAvgRating";
            this.labelAvgRating.Size = new System.Drawing.Size(67, 25);
            this.labelAvgRating.TabIndex = 7;
            this.labelAvgRating.Text = "Rating";
            // 
            // labelDiagnosticCenterID
            // 
            this.labelDiagnosticCenterID.AutoSize = true;
            this.labelDiagnosticCenterID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiagnosticCenterID.Location = new System.Drawing.Point(31, 182);
            this.labelDiagnosticCenterID.Name = "labelDiagnosticCenterID";
            this.labelDiagnosticCenterID.Size = new System.Drawing.Size(95, 25);
            this.labelDiagnosticCenterID.TabIndex = 6;
            this.labelDiagnosticCenterID.Text = "Center ID";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.FlatAppearance.BorderSize = 3;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(669, 600);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(119, 43);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(524, 38);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(295, 35);
            this.txtSearch.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(845, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 36);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // Userfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Diagnostic_Management_System.Properties.Resources.Pic;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1418, 669);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.panelInformation);
            this.Controls.Add(this.listBoxDiagnosticCenters);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.closebtn);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Userfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Userfrm";
            this.panelInformation.ResumeLayout(false);
            this.panelInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ListBox listBoxDiagnosticCenters;
        private System.Windows.Forms.Label labelDiagnosticCenterName;
        private System.Windows.Forms.Label labelDiagnosticCenterAddress;
        private System.Windows.Forms.Panel panelInformation;
        private System.Windows.Forms.Label labelDiagnosticCenterID;
        private System.Windows.Forms.Label labelAvgRating;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
    }
}