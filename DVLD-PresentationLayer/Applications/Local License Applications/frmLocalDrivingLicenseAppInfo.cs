using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License_Applications
{
    public partial class frmLocalDrivingLicenseAppInfo : Form
    {
        int _LDLAppID = -1;
        public frmLocalDrivingLicenseAppInfo(int LDLAppID)
        {
            _LDLAppID= LDLAppID;

            InitializeComponent();
        }

        private void frmLocalDrivingLicenseAppInfo_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingLicenseApplicationInfo1.LoadInfo(_LDLAppID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
