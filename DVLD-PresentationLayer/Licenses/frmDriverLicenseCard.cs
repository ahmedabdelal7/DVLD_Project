using DVLD.Common_Classes;
using DVLD.Properties;
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

namespace DVLD.Licenses
{
    public partial class frmDriverLicenseCard : Form
    {
        int _LicenseID = -1;
        public frmDriverLicenseCard(int LicenseID)
        {
            _LicenseID = LicenseID;
            InitializeComponent();
        }

        private void frmDriverLicenseCard_Load(object sender, EventArgs e)
        {
            clsLicense license = clsLicense.Find(_LicenseID);
            if (license == null) {
                MessageBox.Show("This License is not exists!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            clsPerson personInfo = clsPerson.Find(license.PersonID);

            lblClassName.Text = clsLicenseClass.GetLicenseClassName(license.LicenseClassID);
            lblPersonName.Text = personInfo.FullName;
            lblLicenseID.Text = license.LicenseClassID.ToString();
            lblNationalNo.Text = personInfo.NationalNo;
            lblGender.Text = personInfo.Gender.ToString();
            lblIssueDate.Text = clsUtil.CustomShortDate(license.IssueDate);
            lblIssueReason.Text = license.GetIssueReasonText();
            lblNotes.Text = license.Notes;
            lblIsActive.Text = license.IsActive == true ? "Yes" : "No";
            lblDateOfBirth.Text = clsUtil.CustomShortDate(personInfo.DateOfBirth);
            lblDriverID.Text = license.DriverID.ToString();
            lblExpirationDate.Text = clsUtil.CustomShortDate(license.ExpirationDate);
            //we will handle it later
            lblIsDetained.Text = "No";

            if (string.IsNullOrEmpty(personInfo.ImagePath))
            {
                ppPersonImage.Image = personInfo.Gender == clsPerson.enGender.Male ? Resources.man : Resources.woman;
            }
            else
                ppPersonImage.ImageLocation = personInfo.ImagePath;
               

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
