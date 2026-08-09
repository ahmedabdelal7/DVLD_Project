using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.License
{
    public partial class frmIssueLicense : Form
    {
        int _LDLAppID = -1;
        public frmIssueLicense(int LDLAppID)
        {
            _LDLAppID = LDLAppID;
            InitializeComponent();
        }

        private void frmIssueLicense_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingLicenseApplicationInfo1.LoadInfo(_LDLAppID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {

        }
    }
}
