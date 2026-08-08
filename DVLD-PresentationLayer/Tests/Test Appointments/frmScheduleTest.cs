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

namespace DVLD.Tests
{
    public partial class frmScheduleTest : Form
    {
        int _LDLAppID;
        clsTestType.enTestType _TestType;
        clsLocalDrivingLicenseApplication _LDLApplication;
        bool _DoesFailPrevTest = false;
        clsApplication _RetakeTestApp;

        int _TestAppointmentID = -1;
        clsTestAppointment _TestAppointment;
        enum enMode
        {
            AddNew = 0, Update
        }
        enMode _Mode;
        public frmScheduleTest(int LDLAppID, clsTestType.enTestType TestType)
        {
            //add new
            InitializeComponent();
            _LDLAppID = LDLAppID;
            _TestType = TestType;
            _Mode = enMode.AddNew;
        }

        public frmScheduleTest(int TestAppointmentID) { 
            //Update
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
            _Mode = enMode.Update;
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);
            _TestType = _TestAppointment.TestTypeID;
            _LDLAppID = _TestAppointment.LDLAppID;
        }

        private void _LoadRetakeTestInfo()
        {
            _DoesFailPrevTest = clsLocalDrivingLicenseApplication.DoesFailPrevTest(_LDLAppID, _TestType);
            if (!_DoesFailPrevTest)
            {
                gbRetakeTestInfo.Enabled = false;
                lblTotalFees.Text = lblTestFees.Text;
                return;
            }



            gbRetakeTestInfo.Enabled = true;

            lblTestTittle.Text = "Schedule Retake Test";

            if (_Mode == enMode.AddNew) {
                _RetakeTestApp = new clsApplication();               
            }
            else
            {
                //update mode

                if (_TestAppointment.RetakeTestApplicationID != -1)
                {
                    lblRetakeTestAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
                    lblRetakeAppFees.Text = clsApplicationType.GetApplicationFees(7).ToString();
                    lblTotalFees.Text = (_TestAppointment.PaidFees + Convert.ToDouble( lblRetakeAppFees.Text)).ToString();
                    return;
                }
                lblRetakeAppFees.Text = "0";
                lblTotalFees.Text = _TestAppointment.PaidFees.ToString();
                lblRetakeTestAppID.Text = "N/A";

            }


        }

        private void ScheduleTest_Load(object sender, EventArgs e)
        {

            _LDLApplication = clsLocalDrivingLicenseApplication.Find(_LDLAppID);
            lblLDLAppID.Text = _LDLAppID.ToString();
            lblLicenseClass.Text = _LDLApplication.LicenseClassName;
            lblApplicantName.Text = _LDLApplication.ApplicantFullName;
            lblTrial.Text = clsLocalDrivingLicenseApplication.GetTestTrialCount(_LDLAppID,_TestType).ToString();
            lblTestFees.Text = clsTestType.GetTestFees(_TestType).ToString();
            //lblTestTittle.Text = "Schedule Test";
            lblAlert.Visible = false;

            _LoadRetakeTestInfo();

            if (_Mode == enMode.Update )
            {
                lblTestFees.Text = _TestAppointment.PaidFees.ToString();
                dateTimePicker1.Value = _TestAppointment.AppointmentDate;

                if (_TestAppointment.IsLocked)
                {
                    btnSave.Enabled = false;
                    dateTimePicker1.Enabled = false;

                    lblAlert.Text = "This person already sat for this test, appointment is locked!";
                    lblAlert.Visible = true;

                }
            }
            else
            {
                _TestAppointment = new clsTestAppointment();
            }



            if (_TestType == clsTestType.enTestType.Vision) {
                gbTestName.Text = "Vision Test";
                
                ppTestPicture.Image = Resources.Vision_512;
                return;

            }
            if (_TestType == clsTestType.enTestType.Written)
            {
                gbTestName.Text = "Written Test";
                
                ppTestPicture.Image = Resources.Written_Test_512;
                return;

            }
            if (_TestType == clsTestType.enTestType.Practical)
            {
                gbTestName.Text = "Practical Test";
                
                ppTestPicture.Image = Resources.driving_test_512;
                return;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                _TestAppointment.LDLAppID = _LDLAppID;
                _TestAppointment.AppointmentDate = dateTimePicker1.Value;
                _TestAppointment.CreatedByUserID = clsGlobalSettings.LoggedInUserID;
                _TestAppointment.PaidFees = clsTestType.GetTestFees(_TestType);
                _TestAppointment.TestTypeID = _TestType;

                if (_DoesFailPrevTest)
                {
                    _RetakeTestApp.ApplicantPersonID = _LDLApplication.ApplicantPersonID;
                    _RetakeTestApp.ApplicationDate = DateTime.Now;
                    _RetakeTestApp.ApplicationStatus = clsApplication.enApplicationStatus.New;
                    _RetakeTestApp.ApplicationTypeID = clsApplication.enApplicationType.RetakeTest;
                    _RetakeTestApp.CreatedByUserID = clsGlobalSettings.LoggedInUserID;
                    _RetakeTestApp.LastStatusDate = DateTime.Now;
                    _RetakeTestApp.PaidFees = clsApplicationType.GetApplicationFees(7);

                    if (_RetakeTestApp.Save())
                    {
                        _TestAppointment.RetakeTestApplicationID = _RetakeTestApp.ApplicationID; 
                    }

                }

                if(_TestAppointment.Save())
                {
                    MessageBox.Show("Appointment saved successfully.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }else
                    MessageBox.Show("Failed to save this appointment!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            //update mode

            if (_DoesFailPrevTest)
            {

            }
        }
    }
}
