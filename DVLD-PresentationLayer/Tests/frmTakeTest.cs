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
using static DVLD_BussinessLayer.clsTestType;

namespace DVLD.Tests
{
    public partial class frmTakeTest : Form
    {

        
        clsTestAppointment _TestAppointment;
        clsLocalDrivingLicenseApplication _LDLApplication;
        clsTestType.enTestType _TestType;
        public frmTakeTest(int TestAppointmentID)
        {
            _TestAppointment =  clsTestAppointment.Find(TestAppointmentID);
            _LDLApplication = clsLocalDrivingLicenseApplication.Find(_TestAppointment.LDLAppID);
            _TestType = _TestAppointment.TestTypeID;
            
            InitializeComponent();
        }
        private void _LoadTestNameAndImage(clsTestType.enTestType TestType)
        {
            ppTestPicture.Image =
                TestType == clsTestType.enTestType.Vision ? Resources.Vision_512 :
                (TestType == clsTestType.enTestType.Written ? Resources.Written_Test_512 : Resources.driving_test_512);

            gbTestName.Text = TestType.ToString() + " Test";

        }
        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            clsTestType.enTestType TestType = _TestAppointment.TestTypeID;

            lblLDLAppID.Text = _TestAppointment.LDLAppID.ToString();
            lblTestAppointmentDate.Text = _TestAppointment.AppointmentDate.ToString();
            lblTestFees.Text = _TestAppointment.PaidFees.ToString();

            lblApplicantName.Text = _LDLApplication.ApplicantFullName;
            lblLicenseClass.Text = _LDLApplication.LicenseClassName;
            lblTrial.Text = clsLocalDrivingLicenseApplication.GetTestTrialCount(_LDLApplication.ID, TestType).ToString();
            rbPass.Checked = true;


            gbTestName.Text = _TestAppointment.TestTypeID.ToString() + " Test";


            _LoadTestNameAndImage(TestType);


        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
