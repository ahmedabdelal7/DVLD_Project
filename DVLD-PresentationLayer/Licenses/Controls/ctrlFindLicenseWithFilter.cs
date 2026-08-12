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

namespace DVLD.Licenses.Controls
{
    public partial class ctrlFindLicenseWithFilter : UserControl
    {
        public ctrlFindLicenseWithFilter()
        {
            InitializeComponent();
        }


        // Define a custom event handler delegate with parameters
        public event Action<int> OnLicenseSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID); // Raise the event with the parameter
            }
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !clsValidate.IsValidInteger(sender, e);
        }

        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            clsLicense License = clsLicense.Find(int.Parse(txtLicenseID.Text.Trim()));
            if (License == null) {
                MessageBox.Show("This license not found, please enter valid licenseID.",
                    "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if(OnLicenseSelected != null)
                    LicenseSelected(-1);
                return;
            }

            
        }
    }
}
