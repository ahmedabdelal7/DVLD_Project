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
    public partial class ctrlDriverLicenses : UserControl
    {
        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        public void _LoadDriverLicenses(int DriverID)
        {
            _LoadLocalLicenses(DriverID);

            _LoadInternationalLicenses(DriverID);
        }
        private void _LoadLocalLicenses(int DriverID)
        {
            DataTable dtLocalLicenses = clsDriver.ListAllLocalLicenses(DriverID);

            dgvLocalLicensesHistory.Rows.Clear();

            foreach (DataRow row in dtLocalLicenses.Rows)
            {
                dgvLocalLicensesHistory.Rows.Add(
                    row[0],
                    row[1],
                    row[2],
                    row[3],
                    row[4],
                    row[5]
                );
            }
            lblLocalLicensesCount.Text = dgvLocalLicensesHistory.RowCount.ToString();
        }
        private void _LoadInternationalLicenses(int DriverID)
        {
            DataTable dtInternationalLicenses = clsDriver.ListAllInternationalLicenses(DriverID);

            dgvInternationalLicensesHistory.Rows.Clear();

            foreach (DataRow row in dtInternationalLicenses.Rows)
            {
                dgvInternationalLicensesHistory.Rows.Add(
                    row[0],
                    row[1],
                    row[2],
                    row[3],
                    row[4],
                    row[5]
                );
            }

            lblInternationalLicensesCount.Text = dgvInternationalLicensesHistory.RowCount.ToString();
        }
        private void ctrlDriverLicenses_Load(object sender, EventArgs e)
        {

        }

    }
}
