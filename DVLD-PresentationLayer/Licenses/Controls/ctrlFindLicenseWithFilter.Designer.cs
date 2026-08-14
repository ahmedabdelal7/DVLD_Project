namespace DVLD.Licenses.Controls
{
    partial class ctrlFindLicenseWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlFindLicenseWithFilter));
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnFindLicense = new System.Windows.Forms.Button();
            this.txtLicenseID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlLicenseDetails1 = new DVLD.Licenses.Controls.ctrlLicenseDetails();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnFindLicense);
            this.gbFilter.Controls.Add(this.txtLicenseID);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Location = new System.Drawing.Point(0, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(672, 109);
            this.gbFilter.TabIndex = 0;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnFindLicense
            // 
            this.btnFindLicense.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFindLicense.BackgroundImage")));
            this.btnFindLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindLicense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFindLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindLicense.Location = new System.Drawing.Point(545, 34);
            this.btnFindLicense.Name = "btnFindLicense";
            this.btnFindLicense.Size = new System.Drawing.Size(64, 47);
            this.btnFindLicense.TabIndex = 39;
            this.btnFindLicense.UseVisualStyleBackColor = true;
            this.btnFindLicense.Click += new System.EventHandler(this.btnFindLicense_Click);
            // 
            // txtLicenseID
            // 
            this.txtLicenseID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLicenseID.Location = new System.Drawing.Point(180, 45);
            this.txtLicenseID.Name = "txtLicenseID";
            this.txtLicenseID.Size = new System.Drawing.Size(328, 26);
            this.txtLicenseID.TabIndex = 1;
            this.txtLicenseID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLicenseID_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "License ID: ";
            // 
            // ctrlLicenseDetails1
            // 
            this.ctrlLicenseDetails1.BackColor = System.Drawing.Color.White;
            this.ctrlLicenseDetails1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlLicenseDetails1.LicenseID = 0;
            this.ctrlLicenseDetails1.Location = new System.Drawing.Point(0, 120);
            this.ctrlLicenseDetails1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlLicenseDetails1.Name = "ctrlLicenseDetails1";
            this.ctrlLicenseDetails1.Size = new System.Drawing.Size(1013, 351);
            this.ctrlLicenseDetails1.TabIndex = 44;
            // 
            // ctrlFindLicenseWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctrlLicenseDetails1);
            this.Controls.Add(this.gbFilter);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ctrlFindLicenseWithFilter";
            this.Size = new System.Drawing.Size(1017, 475);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.TextBox txtLicenseID;
        private System.Windows.Forms.Label label1;
        private ctrlLicenseDetails ctrlLicenseDetails1;
        public System.Windows.Forms.Button btnFindLicense;
    }
}
