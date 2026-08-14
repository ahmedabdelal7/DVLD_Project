namespace DVLD.Licenses.Controls
{
    partial class ctrListDriverLicenses
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrListDriverLicenses));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvLocalLicensesHistory = new System.Windows.Forms.DataGridView();
            this.lblLocalLicensesCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvInternationalLicensesHistory = new System.Windows.Forms.DataGridView();
            this.lblInternationalLicensesCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicensesHistory)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tab);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1122, 357);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPage1);
            this.tab.Controls.Add(this.tabPage2);
            this.tab.Location = new System.Drawing.Point(15, 41);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1093, 299);
            this.tab.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.dgvLocalLicensesHistory);
            this.tabPage1.Controls.Add(this.lblLocalLicensesCount);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1085, 266);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Local";
            // 
            // dgvLocalLicensesHistory
            // 
            this.dgvLocalLicensesHistory.AllowUserToAddRows = false;
            this.dgvLocalLicensesHistory.AllowUserToDeleteRows = false;
            this.dgvLocalLicensesHistory.AllowUserToOrderColumns = true;
            this.dgvLocalLicensesHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalLicensesHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalLicensesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicensesHistory.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvLocalLicensesHistory.Location = new System.Drawing.Point(10, 43);
            this.dgvLocalLicensesHistory.MultiSelect = false;
            this.dgvLocalLicensesHistory.Name = "dgvLocalLicensesHistory";
            this.dgvLocalLicensesHistory.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLocalLicensesHistory.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalLicensesHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalLicensesHistory.Size = new System.Drawing.Size(1064, 181);
            this.dgvLocalLicensesHistory.TabIndex = 46;
            // 
            // lblLocalLicensesCount
            // 
            this.lblLocalLicensesCount.AutoSize = true;
            this.lblLocalLicensesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalLicensesCount.Location = new System.Drawing.Point(108, 231);
            this.lblLocalLicensesCount.Name = "lblLocalLicensesCount";
            this.lblLocalLicensesCount.Size = new System.Drawing.Size(29, 20);
            this.lblLocalLicensesCount.TabIndex = 42;
            this.lblLocalLicensesCount.Text = "??";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 20);
            this.label1.TabIndex = 44;
            this.label1.Text = "Local Licenses History:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 43;
            this.label2.Text = "#Records: ";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.dgvInternationalLicensesHistory);
            this.tabPage2.Controls.Add(this.lblInternationalLicensesCount);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1085, 266);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "International";
            // 
            // dgvInternationalLicensesHistory
            // 
            this.dgvInternationalLicensesHistory.AllowUserToAddRows = false;
            this.dgvInternationalLicensesHistory.AllowUserToDeleteRows = false;
            this.dgvInternationalLicensesHistory.AllowUserToOrderColumns = true;
            this.dgvInternationalLicensesHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternationalLicensesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicensesHistory.ContextMenuStrip = this.contextMenuStrip2;
            this.dgvInternationalLicensesHistory.Location = new System.Drawing.Point(10, 43);
            this.dgvInternationalLicensesHistory.MultiSelect = false;
            this.dgvInternationalLicensesHistory.Name = "dgvInternationalLicensesHistory";
            this.dgvInternationalLicensesHistory.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvInternationalLicensesHistory.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInternationalLicensesHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInternationalLicensesHistory.Size = new System.Drawing.Size(1064, 181);
            this.dgvInternationalLicensesHistory.TabIndex = 49;
            // 
            // lblInternationalLicensesCount
            // 
            this.lblInternationalLicensesCount.AutoSize = true;
            this.lblInternationalLicensesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternationalLicensesCount.Location = new System.Drawing.Point(110, 229);
            this.lblInternationalLicensesCount.Name = "lblInternationalLicensesCount";
            this.lblInternationalLicensesCount.Size = new System.Drawing.Size(29, 20);
            this.lblInternationalLicensesCount.TabIndex = 46;
            this.lblInternationalLicensesCount.Text = "??";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(253, 20);
            this.label4.TabIndex = 48;
            this.label4.Text = "International Licenses History:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 47;
            this.label5.Text = "#Records: ";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(213, 42);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showLicenseInfoToolStripMenuItem.Image")));
            this.showLicenseInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(212, 38);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(213, 64);
            // 
            // showLicenseInfoToolStripMenuItem1
            // 
            this.showLicenseInfoToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("showLicenseInfoToolStripMenuItem1.Image")));
            this.showLicenseInfoToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseInfoToolStripMenuItem1.Name = "showLicenseInfoToolStripMenuItem1";
            this.showLicenseInfoToolStripMenuItem1.Size = new System.Drawing.Size(212, 38);
            this.showLicenseInfoToolStripMenuItem1.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem1.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem1_Click);
            // 
            // ctrListDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrListDriverLicenses";
            this.Size = new System.Drawing.Size(1122, 357);
            this.Load += new System.EventHandler(this.ctrlDriverLicenses_Load);
            this.groupBox1.ResumeLayout(false);
            this.tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicensesHistory)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblLocalLicensesCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInternationalLicensesCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvLocalLicensesHistory;
        private System.Windows.Forms.DataGridView dgvInternationalLicensesHistory;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem1;
    }
}
