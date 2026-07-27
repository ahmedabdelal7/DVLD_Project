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
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void _FillGridWithApplicationTypes()
        {
            DataTable _dtApplicationTypes = clsApplicationType.ListAllApplicationTypes();
            dgvApplicationTypes.Rows.Clear();

            foreach (DataRow row in _dtApplicationTypes.Rows)
            {
                dgvApplicationTypes.Rows.Add(row["ApplicationTypeID"], row["ApplicationTypeTitle"], row["ApplicationFees"]);
            }
            //dgvApplicationTypes.DataSource = _dtApplicationTypes;

            lblRecordsCount.Text = dgvApplicationTypes.RowCount.ToString();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _FillGridWithApplicationTypes();
        }

        private void dgvApplicationTypes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
