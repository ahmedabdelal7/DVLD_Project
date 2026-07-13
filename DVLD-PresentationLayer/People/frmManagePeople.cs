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

namespace DVLD.People
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }
        enum enFilterBY
        {
            None = 0, PersonID, NationalNo, FirstName, SecondName,
            ThirdName, LastName, Nationality, Gender, Phone, Email
        }

        DataTable _dtPeople;
        private void _LoadPeople()
        {
            _dtPeople = clsPerson.ListAllPeople();
            dgvPeople.DataSource = _dtPeople;

            //cbFilter.SelectedIndex = 0;

            lblRecords.Text = _dtPeople.Rows.Count.ToString();
            //txtFilterText.Visible = false;

        }
        private void _LoadPeople(DataTable dataTable)
        {
            dgvPeople.DataSource = dataTable;

            //cbFilter.SelectedIndex = 0;

            lblRecords.Text = dataTable.Rows.Count.ToString();
            //txtFilterText.Visible = false;

        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            txtFilterText.Visible = false;
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
            txtFilterText.Visible = (cbFilter.SelectedIndex != (int)enFilterBY.None);
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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = _GetSelectedPersonID();
            DialogResult msgResult = MessageBox.Show($"Are you sure you want to delete this person [{PersonID}]",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (msgResult == DialogResult.Yes)
            {
                if (clsPerson.IsExist(PersonID))
                {

                    if (clsPerson.Delete(PersonID))
                    {

                        MessageBox.Show("Person deleted successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _LoadPeople();
                        return;
                    }

                    MessageBox.Show("Failed to this person because he has a related data in the system!",
                        "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                else
                {
                    MessageBox.Show("Failed, this person does not exist!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void _ShowPersonDetails()
        {
            int PersonID = _GetSelectedPersonID();
            if (PersonID < -1)
                MessageBox.Show("Please select person first.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (!clsPerson.IsExist(PersonID))
            {
                MessageBox.Show("this person does not exist, chose another one.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LoadPeople();
            }


            frmPersonDetails frmPersonDetails = new frmPersonDetails(PersonID);
            frmPersonDetails.ShowDialog();

            _LoadPeople();

        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowPersonDetails();
        }

        private void dgvPeople_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _ShowPersonDetails();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson AddNewPerson = new frmAddEditPerson();
            AddNewPerson.ShowDialog();
            _LoadPeople();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The feature is not implemented yet.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The feature is not implemented yet.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void txtFilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedIndex == (short)enFilterBY.PersonID)
                e.Handled = !clsValidate.IsValidInteger(sender, e);
        }

        private void txtFilterText_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtFilterText.Text;
            if (string.IsNullOrEmpty(searchText))
            {
                _LoadPeople();
                return;
            }

            DataTable dtPeople = _dtPeople;
            DataView dv = dtPeople.DefaultView;

            string searchBy = cbFilter.SelectedItem.ToString();

            //Search by PersonID & National No Exact Match
            if(cbFilter.SelectedIndex == (short)enFilterBY.PersonID )
            {
                dv.RowFilter = $"{searchBy} = {searchText}";
                _LoadPeople(dtPeople = dv.ToTable());
                return;
            }

            //Search by NationalNo & National No Exact Match
            if (cbFilter.SelectedIndex == (short)enFilterBY.NationalNo)
            {
                //string searchBy = cbFilter.SelectedItem.ToString();
                dv.RowFilter = $"{searchBy} = '{searchText}'";
                _LoadPeople(dtPeople = dv.ToTable());
                return;
            }

            if (cbFilter.SelectedIndex == (short)enFilterBY.Gender)
            {
                dv.RowFilter = $"Gendor LIKE '{searchText}%'";
                _LoadPeople(dtPeople = dv.ToTable());

                return;
            }
            else
            {
                //string searchBy = cbFilter.SelectedItem.ToString();
                dv.RowFilter = $"{searchBy} LIKE '%{searchText}%'";
                _LoadPeople(dtPeople = dv.ToTable());
                return;
            }


        }
    }
}
 
