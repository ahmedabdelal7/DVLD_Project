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
    public partial class ctrlLocalDrivingLicenseApplicationInfo : UserControl
    {
        public ctrlLocalDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadInfo(int LocalDrivingLicenseID)
        {
            //Load Driving License Application Info
            clsLocalDrivingLicenseApplication DrivingLicenseApp =
                clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseID);

            lblLocalLicenseID.Text = DrivingLicenseApp.ID.ToString();
            lblLicenseClass.Text = clsLicenseClass.GetLicenseClassName(DrivingLicenseApp.LicenseClassID);
            lblPassedTestsCount.Text = DrivingLicenseApp.GetPassedTestsCount() + "/3";

            //Load Application basic info
            lblApplicationID.Text = DrivingLicenseApp.ApplicationID.ToString();
            lblStatus.Text = DrivingLicenseApp.GetStatusText();
            lblFees.Text = DrivingLicenseApp.PaidFees.ToString();
            lblType.Text = clsApplicationType.GetApplicationTypeTitle((int)DrivingLicenseApp.ApplicationTypeID).ToString();
            lblApplicant.Text = DrivingLicenseApp.ApplicantFullName.ToString();
            lblApplicationDate.Text = clsUtil.CustomShortDate(DrivingLicenseApp.ApplicationDate);
            lblStatusDate.Text = clsUtil.CustomShortDate(DrivingLicenseApp.LastStatusDate);
            lblCreatedBy.Text = clsUser.Find(DrivingLicenseApp.CreatedByUserID).UserName;


        }

        private void ctrlLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            
        }
    }
}
