namespace DVLD.Applications.International_Driving_License_Applications
{
    partial class frmInternationalDrivingLicenseApplication
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
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlFindLicenseWithFilter1 = new DVLD.Licenses.Controls.ctrlFindLicenseWithFilter();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Firebrick;
            this.label3.Location = new System.Drawing.Point(19, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1026, 50);
            this.label3.TabIndex = 37;
            this.label3.Text = "International License Application";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlFindLicenseWithFilter1
            // 
            this.ctrlFindLicenseWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlFindLicenseWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlFindLicenseWithFilter1.Location = new System.Drawing.Point(18, 97);
            this.ctrlFindLicenseWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlFindLicenseWithFilter1.Name = "ctrlFindLicenseWithFilter1";
            this.ctrlFindLicenseWithFilter1.Size = new System.Drawing.Size(1026, 463);
            this.ctrlFindLicenseWithFilter1.TabIndex = 0;
            // 
            // frmInternationalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1057, 666);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctrlFindLicenseWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmInternationalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New International Driving License Application";
            this.ResumeLayout(false);

        }

        #endregion

        private Licenses.Controls.ctrlFindLicenseWithFilter ctrlFindLicenseWithFilter1;
        private System.Windows.Forms.Label label3;
    }
}