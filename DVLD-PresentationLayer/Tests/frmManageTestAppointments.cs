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
    public partial class frmManageTestAppointments : Form
    {
        enum enMode
        {
            VisionTest = 1, WrittenTest, PracticalTest

        }
        enMode _Mode;
        int _LDLAppID = -1;
        public frmManageTestAppointments(clsTestType.enTestType testType, int LDLAppID)
        {
            _Mode = (enMode)testType;
            _LDLAppID = LDLAppID;
            InitializeComponent();
        }

        private void _LoadInfo()
        {
            ctrlLocalDrivingLicenseApplicationInfo1.LoadInfo(_LDLAppID);
        }

        private void frmManageTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadInfo();
        }
    }
}
