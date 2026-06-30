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

        private int _GetSelectedPersonID()
        {
            return (int)dgvPeople.SelectedCells[0].Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilterText.Visible = (cbFilter.SelectedItem.ToString() != "None");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frmAddEditPerson = new frmAddEditPerson();
            frmAddEditPerson.ShowDialog();
            _LoadPeople();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeople.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select person first!");
                return;
            }
            int PersonID = _GetSelectedPersonID();

            frmAddEditPerson editPerson = new frmAddEditPerson(PersonID);
            editPerson.ShowDialog();
            _LoadPeople();
        }
    }
}
