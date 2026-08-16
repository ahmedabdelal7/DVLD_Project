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

        DataTable _dtPeople = clsPerson.ListAllPeople();

        private void frmManagePeople_Load(object sender, EventArgs e)
        {

            cbFilter.SelectedIndex = 0;
            txtFilterText.Visible = false;

            //_dtPeople = clsPerson.ListAllPeople();
            dgvPeople.DataSource = _dtPeople;

            lblRecords.Text = _dtPeople.Rows.Count.ToString();

            if (_dtPeople.Rows.Count == 0)
            {
                return;
            }

            dgvPeople.Columns[0].HeaderText = "Person ID";
            dgvPeople.Columns[0].Width = 100;

            dgvPeople.Columns[1].HeaderText = "National No.";
            dgvPeople.Columns[1].Width = 100;

            dgvPeople.Columns[2].HeaderText = "First Name";
            dgvPeople.Columns[2].Width = 120;

            dgvPeople.Columns[3].HeaderText = "Second Name";
            dgvPeople.Columns[3].Width = 135;

            dgvPeople.Columns[4].HeaderText = "Third Name";
            dgvPeople.Columns[4].Width = 135;

            dgvPeople.Columns[5].HeaderText = "Last Name";
            dgvPeople.Columns[5].Width = 140;
            dgvPeople.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvPeople.Columns[6].HeaderText = "Gender";
            dgvPeople.Columns[6].Width = 95;

            dgvPeople.Columns[7].HeaderText = "Date Of Birth";
            dgvPeople.Columns[7].Width = 180;

            dgvPeople.Columns[8].HeaderText = "Phone";
            dgvPeople.Columns[8].Width = 140;

            dgvPeople.Columns[9].HeaderText = "Email";
            dgvPeople.Columns[9].Width = 120;

            dgvPeople.Columns[10].HeaderText = "Nationality";
            dgvPeople.Columns[10].Width = 100;

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
            txtFilterText.Visible = cbFilter.SelectedIndex != (int)enFilterBY.None;
            txtFilterText.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frmAddEditPerson = new frmAddEditPerson();
            frmAddEditPerson.ShowDialog();
           
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
            editPerson.DataBack += _RefreshDataTable;
            editPerson.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = _GetSelectedPersonID();
            DialogResult msgResult = MessageBox.Show($"Are you sure you want to delete this person [{PersonID}]",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (msgResult != DialogResult.Yes)
                return;
            
            if (clsPerson.IsExist(PersonID))
            {

                if (clsPerson.Delete(PersonID))
                {

                    MessageBox.Show("Person deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                       
                    return;
                }

                //referential integrity.
                MessageBox.Show("Failed to this person because he has a related data in the system!",
                    "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            MessageBox.Show("Failed, this person does not exist!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void _ShowPersonDetails()
        {
            int PersonID = _GetSelectedPersonID();
            if (PersonID <= 0)
                MessageBox.Show("Please select person first.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (!clsPerson.IsExist(PersonID))
            {
                MessageBox.Show("this person does not exist, chose another one.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
               return ;
            }

            frmPersonDetails frmPersonDetails = new frmPersonDetails(PersonID);
            frmPersonDetails.ShowDialog();

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
            AddNewPerson.DataBack += _RefreshDataTable;
            AddNewPerson.ShowDialog();            
        }

        private void _RefreshDataTable(int PersonID =1)
        {
            if (PersonID != -1)
            {
                 _dtPeople = clsPerson.ListAllPeople();
                dgvPeople.DataSource = _dtPeople;
                cbFilter.SelectedIndex = (int)enFilterBY.None;
            }
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
            if(string.IsNullOrEmpty(txtFilterText.Text))
            {
                _dtPeople.DefaultView.RowFilter = "";
                return;
            }

            string FilterColumn = "";

            switch ((enFilterBY)cbFilter.SelectedIndex) {
                case enFilterBY.PersonID:
                    FilterColumn = "PersonID";
                    break;
                case enFilterBY.NationalNo:
                    FilterColumn = "NationalNo";
                    break;
                case enFilterBY.FirstName:
                    FilterColumn = "FirstName";
                    break;
                case enFilterBY.SecondName:
                    FilterColumn = "SecondName";
                    break;
                case enFilterBY.ThirdName:
                    FilterColumn = "ThirdName";
                    break;
                case enFilterBY.LastName:
                    FilterColumn = "LastName";
                    break;
                case enFilterBY.Gender:
                    FilterColumn = "Gender";
                    break;
                case enFilterBY.Phone:
                    FilterColumn = "Phone";
                    break;
                case enFilterBY.Email:
                    FilterColumn = "Email";
                    break;
                case enFilterBY.Nationality:
                    FilterColumn = "Nationality";
                    break;
                case enFilterBY.None:
                    FilterColumn = "None";
                    break;
            }

            if (cbFilter.SelectedIndex == (int)enFilterBY.PersonID) {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, int.Parse(txtFilterText.Text.Trim()));
            }
            else
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtFilterText.Text.Trim());
            }

        }

        private void msManagePeople_Opening(object sender, CancelEventArgs e)
        {
            if (dgvPeople.SelectedRows.Count == 0)
                msManagePeople.Enabled = false;       
            else
                msManagePeople.Enabled = true;
        }
    }
}
 
