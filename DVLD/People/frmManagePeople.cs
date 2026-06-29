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

namespace DVLD.People
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void _LoadPeople()
        {
            DataTable dt = clsPerson.ListAllPeople();
            dgvPeople.DataSource = dt;

            cbFilter.SelectedIndex = 0;

            lblRecords.Text = dt.Rows.Count.ToString();
            txtFilterText.Visible = false;

        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _LoadPeople();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilterText.Visible = (cbFilter.SelectedItem.ToString() != "None");
        }
    }
}
