using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses.International_Driving_License
{
    public partial class frmInternationalLicenseInfo : Form
    {
        int _IntLicenseID = -1;
        public frmInternationalLicenseInfo(int IntLicenseID)
        {
            _IntLicenseID = IntLicenseID;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlInternationalLicenseCard1.LoadIntLicenseInfo(_IntLicenseID);
        }
    }
}
