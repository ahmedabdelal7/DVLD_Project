using DVLD.Common_Classes;
using DVLD_BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmManageLocalDrivingLicenseApplications : Form
    {
        public frmManageLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }
        DataTable _dtApplications;

        enum enFilterBy
        {
            None = 0, LDLAppID, NationalNo, FullName, Status
        }

        enum enStatus
        {
            All = 0, New, Cancelled, Completed
        }


        private void _FillDataViewWithApplications(DataTable dataTable)
        {
            dgvLDLApplications.Rows.Clear();
            foreach (DataRow row in dataTable.Rows)
            {

                dgvLDLApplications.Rows.Add(
                    row["LocalDrivingLicenseApplicationID"],
                    row["ClassName"],
                    row["NationalNo"],
                    row["FullName"],
                    clsUtil.CustomShortDate((DateTime)row["ApplicationDate"]),
                    row["PassedTestCount"],
                    row["Status"]
                    );

            }
            lblRecordsCount.Text = dataTable.Rows.Count.ToString();
        }
        private void _LoadInfo()
        {
            _dtApplications = clsLocalDrivingLicenseApplication.ListAllLocalDrivingLicenseApplications();

            _FillDataViewWithApplications(_dtApplications);

            cbStatus.Visible = false;
            cbStatus.SelectedIndex = (int)enStatus.All;

            cbFilter.SelectedIndex = (int)enFilterBy.None;
            txtFilterValue.Visible = false;

            
        }
        private int _GetSelectedLicenseApplicationID()
        {
            int ID;
            try
            {
                ID = Convert.ToInt32(dgvLDLApplications.SelectedCells[0].Value);

            }
            catch
            {
                ID = -1;
            }

            return ID;
        }
        private void frmManageLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _LoadInfo();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilter.SelectedIndex == (int)enFilterBy.LDLAppID)
            {
                e.Handled = !clsValidate.IsValidInteger(sender, e);
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            cbStatus.SelectedIndex = (int)enStatus.All;

            if (cbFilter.SelectedIndex == (int)enFilterBy.None) { 
                txtFilterValue.Visible = false;
                cbStatus.Visible=false;
                return;

            }

            if (cbFilter.SelectedIndex == (int)enFilterBy.Status) { 
                txtFilterValue.Visible=false;
                cbStatus.Visible=true;
                return;
            }

            txtFilterValue.Visible = true;
            cbStatus.Visible = false;

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string findValue = txtFilterValue.Text.Trim().ToString();

            DataView dv = _dtApplications.DefaultView;

            if (dv == null) return;
            if (string.IsNullOrEmpty(findValue))
            {
                _FillDataViewWithApplications(_dtApplications);
                return;
            }
                

            if(cbFilter.SelectedIndex == (int)enFilterBy.LDLAppID)
            {
                if(int.TryParse(findValue, out int ID))
                {
                    dv.RowFilter = $"LocalDrivingLicenseApplicationID = {ID}";

                    _FillDataViewWithApplications( dv.ToTable());

                }
                return;                

            }


            if (cbFilter.SelectedIndex == (int)enFilterBy.NationalNo)
            {
                
                dv.RowFilter = $"NationalNo = '{findValue}'";

                _FillDataViewWithApplications(dv.ToTable());

                
                return;

            }

            if (cbFilter.SelectedIndex == (int)enFilterBy.FullName)
            {

                dv.RowFilter = $"FullName LIKE '%{findValue}%'";

                _FillDataViewWithApplications(dv.ToTable());


                return;

            }


        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = _dtApplications.DefaultView;
            if (dv == null || cbStatus.SelectedIndex == (int)enStatus.All)
            {
                _FillDataViewWithApplications(_dtApplications);
                return;
            }

            if (cbStatus.SelectedIndex == (int)enStatus.New)
            {
                dv.RowFilter = $"Status = '{enStatus.New.ToString()}'";
                _FillDataViewWithApplications(dv.ToTable());
                return;
            }

            if (cbStatus.SelectedIndex == (int)enStatus.Cancelled) {
                dv.RowFilter = $"Status = '{enStatus.Cancelled.ToString()}'";
                _FillDataViewWithApplications(dv.ToTable());
                return;
            }
            if (cbStatus.SelectedIndex == (int)enStatus.Completed)
            {
                dv.RowFilter = $"Status = '{enStatus.Completed.ToString()}'";
                _FillDataViewWithApplications(dv.ToTable());
                return;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frmAdd = new frmAddUpdateLocalDrivingLicenseApplication();
            frmAdd.DataBack += _RefreshScreen;
            frmAdd.ShowDialog();

        }

        private void _RefreshScreen(bool IsRequireRefresh)
        {
            if (IsRequireRefresh) _LoadInfo();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedID = _GetSelectedLicenseApplicationID();
            if (SelectedID == -1)
                return;

            frmAddUpdateLocalDrivingLicenseApplication frmAddUpdate = new frmAddUpdateLocalDrivingLicenseApplication(SelectedID);
            //subscribe in delegate:
            frmAddUpdate.DataBack += _RefreshScreen;
            frmAddUpdate.ShowDialog();
        }

        private void _ChangeContextUpdatePermission(bool perm)
        {
            deleteApplicationToolStripMenuItem.Enabled = perm;
            cancelApplicationToolStripMenuItem.Enabled = perm;
            scheduleTestToolStripMenuItem.Enabled = perm;
            editApplicationToolStripMenuItem.Enabled = perm;
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            showApplicationDetailsToolStripMenuItem.Enabled = true;
            _ChangeContextUpdatePermission(true);
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
            showApplicationDetailsToolStripMenuItem.Enabled = true;
            showLicenseToolStripMenuItem.Enabled = true;

            int SelectedID = _GetSelectedLicenseApplicationID();
            clsLocalDrivingLicenseApplication licenseApplication  = clsLocalDrivingLicenseApplication.Find(SelectedID);
            if(licenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.Completed
                || licenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.Cancelled)
            {
                _ChangeContextUpdatePermission(false);



            }
            if(licenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.Cancelled)
            {
                _ChangeContextUpdatePermission(false );
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem .Enabled = false;

            }
            if(licenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New)
            {
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;
            }

                        
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            clsLocalDrivingLicenseApplication Application = clsLocalDrivingLicenseApplication.Find(_GetSelectedLicenseApplicationID());

            if (Application == null) {
                MessageBox.Show($"Error, application is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LoadInfo();
                return;
            }

            DialogResult msgResult =
                MessageBox.Show($"Are you sure you want to delete this application ID = {Application.ID}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (msgResult == DialogResult.No)
                return;

            if(Application.Delete())
            {
                MessageBox.Show($"Application deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LoadInfo();
                return;
            }

            MessageBox.Show($"Failed to delete this application, because it related to other information in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication Application = clsLocalDrivingLicenseApplication.Find(_GetSelectedLicenseApplicationID());

            if (Application == null)
            {
                MessageBox.Show($"Error, application is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LoadInfo();
                return;
            }

            DialogResult msgResult =
                MessageBox.Show($"Are you sure you want to cancel this application ID = {Application.ID}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (msgResult == DialogResult.No)
                return;

            if (Application.CancelApplication())
            {
                MessageBox.Show($"Application cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LoadInfo();
                return;
            }

            MessageBox.Show($"Failed to cancel this application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


    }
}
