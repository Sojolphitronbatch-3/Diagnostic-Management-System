namespace Diagnostic_Management_System
{
    partial class AdminDashboardfrm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnViewOrder = new System.Windows.Forms.Button();
            this.btnViewEarning = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnAddDiagnosticCenter = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.closebtn = new System.Windows.Forms.Button();
            this.dataGridViewViewOrder = new System.Windows.Forms.DataGridView();
            this.panelAddDiagnosticCenter = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dataGridViewService = new System.Windows.Forms.DataGridView();
            this.dataGridViewEarning = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewViewOrder)).BeginInit();
            this.panelAddDiagnosticCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEarning)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panel1.Controls.Add(this.btnViewOrder);
            this.panel1.Controls.Add(this.btnViewEarning);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnAddDiagnosticCenter);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 673);
            this.panel1.TabIndex = 0;
            // 
            // btnViewOrder
            // 
            this.btnViewOrder.BackColor = System.Drawing.Color.White;
            this.btnViewOrder.FlatAppearance.BorderSize = 0;
            this.btnViewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewOrder.Location = new System.Drawing.Point(0, 244);
            this.btnViewOrder.Name = "btnViewOrder";
            this.btnViewOrder.Size = new System.Drawing.Size(215, 42);
            this.btnViewOrder.TabIndex = 4;
            this.btnViewOrder.Text = "View Order";
            this.btnViewOrder.UseVisualStyleBackColor = false;
            this.btnViewOrder.Click += new System.EventHandler(this.btnViewOrder_Click);
            // 
            // btnViewEarning
            // 
            this.btnViewEarning.BackColor = System.Drawing.Color.White;
            this.btnViewEarning.FlatAppearance.BorderSize = 0;
            this.btnViewEarning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewEarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewEarning.Location = new System.Drawing.Point(0, 311);
            this.btnViewEarning.Name = "btnViewEarning";
            this.btnViewEarning.Size = new System.Drawing.Size(215, 42);
            this.btnViewEarning.TabIndex = 3;
            this.btnViewEarning.Text = "View Earning";
            this.btnViewEarning.UseVisualStyleBackColor = false;
            this.btnViewEarning.Click += new System.EventHandler(this.btnViewEarning_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(0, 378);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(215, 42);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnAddDiagnosticCenter
            // 
            this.btnAddDiagnosticCenter.BackColor = System.Drawing.Color.White;
            this.btnAddDiagnosticCenter.FlatAppearance.BorderSize = 0;
            this.btnAddDiagnosticCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDiagnosticCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDiagnosticCenter.Location = new System.Drawing.Point(0, 162);
            this.btnAddDiagnosticCenter.Name = "btnAddDiagnosticCenter";
            this.btnAddDiagnosticCenter.Size = new System.Drawing.Size(215, 57);
            this.btnAddDiagnosticCenter.TabIndex = 1;
            this.btnAddDiagnosticCenter.Text = "Add Diagnostic Center";
            this.btnAddDiagnosticCenter.UseVisualStyleBackColor = false;
            this.btnAddDiagnosticCenter.Click += new System.EventHandler(this.btnAddDiagnosticCenter_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(215, 144);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(28, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Admin Dashboard";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Diagnostic_Management_System.Properties.Resources.User_Icon_Female_White_At_Clkercom_Vector_Online;
            this.pictureBox1.Location = new System.Drawing.Point(71, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // closebtn
            // 
            this.closebtn.BackColor = System.Drawing.Color.Transparent;
            this.closebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closebtn.FlatAppearance.BorderSize = 0;
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.ForeColor = System.Drawing.Color.Red;
            this.closebtn.Location = new System.Drawing.Point(1367, 0);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(40, 40);
            this.closebtn.TabIndex = 11;
            this.closebtn.Text = "X";
            this.closebtn.UseVisualStyleBackColor = false;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // dataGridViewViewOrder
            // 
            this.dataGridViewViewOrder.AllowUserToAddRows = false;
            this.dataGridViewViewOrder.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewViewOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewViewOrder.Location = new System.Drawing.Point(293, 88);
            this.dataGridViewViewOrder.Name = "dataGridViewViewOrder";
            this.dataGridViewViewOrder.RowHeadersWidth = 51;
            this.dataGridViewViewOrder.RowTemplate.Height = 24;
            this.dataGridViewViewOrder.Size = new System.Drawing.Size(975, 478);
            this.dataGridViewViewOrder.TabIndex = 12;
            // 
            // panelAddDiagnosticCenter
            // 
            this.panelAddDiagnosticCenter.BackColor = System.Drawing.Color.Transparent;
            this.panelAddDiagnosticCenter.Controls.Add(this.btnAdd);
            this.panelAddDiagnosticCenter.Controls.Add(this.label3);
            this.panelAddDiagnosticCenter.Controls.Add(this.label2);
            this.panelAddDiagnosticCenter.Controls.Add(this.txtAddress);
            this.panelAddDiagnosticCenter.Controls.Add(this.txtName);
            this.panelAddDiagnosticCenter.Location = new System.Drawing.Point(253, 88);
            this.panelAddDiagnosticCenter.Name = "panelAddDiagnosticCenter";
            this.panelAddDiagnosticCenter.Size = new System.Drawing.Size(493, 478);
            this.panelAddDiagnosticCenter.TabIndex = 13;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAdd.FlatAppearance.BorderSize = 3;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(236, 254);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(111, 44);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(50, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(71, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(152, 183);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(294, 42);
            this.txtAddress.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(152, 103);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(294, 40);
            this.txtName.TabIndex = 0;
            // 
            // dataGridViewService
            // 
            this.dataGridViewService.AllowUserToAddRows = false;
            this.dataGridViewService.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewService.Location = new System.Drawing.Point(891, 88);
            this.dataGridViewService.Name = "dataGridViewService";
            this.dataGridViewService.RowHeadersWidth = 51;
            this.dataGridViewService.RowTemplate.Height = 24;
            this.dataGridViewService.Size = new System.Drawing.Size(486, 478);
            this.dataGridViewService.TabIndex = 14;
            // 
            // dataGridViewEarning
            // 
            this.dataGridViewEarning.AllowUserToAddRows = false;
            this.dataGridViewEarning.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewEarning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEarning.Location = new System.Drawing.Point(254, 88);
            this.dataGridViewEarning.Name = "dataGridViewEarning";
            this.dataGridViewEarning.RowHeadersWidth = 51;
            this.dataGridViewEarning.RowTemplate.Height = 24;
            this.dataGridViewEarning.Size = new System.Drawing.Size(1058, 478);
            this.dataGridViewEarning.TabIndex = 16;
            // 
            // AdminDashboardfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Diagnostic_Management_System.Properties.Resources.Pic19;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1408, 673);
            this.Controls.Add(this.closebtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelAddDiagnosticCenter);
            this.Controls.Add(this.dataGridViewService);
            this.Controls.Add(this.dataGridViewViewOrder);
            this.Controls.Add(this.dataGridViewEarning);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminDashboardfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewViewOrder)).EndInit();
            this.panelAddDiagnosticCenter.ResumeLayout(false);
            this.panelAddDiagnosticCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEarning)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddDiagnosticCenter;
        private System.Windows.Forms.Button btnViewOrder;
        private System.Windows.Forms.Button btnViewEarning;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.DataGridView dataGridViewViewOrder;
        private System.Windows.Forms.Panel panelAddDiagnosticCenter;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridView dataGridViewService;
        private System.Windows.Forms.DataGridView dataGridViewEarning;
    }
}