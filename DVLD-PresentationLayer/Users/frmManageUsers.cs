using DVLD.People.Controls;
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

namespace DVLD.Users
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        enum enFilterBy { None = 0, UserID, UserName, PersonID, FullName, IsActive};
        

        DataTable _dtUsers;
        private void _LoadUsers()
        {
            dgvUsers.Rows.Clear();
            _dtUsers = clsUser.ListAllUsers();

            foreach (DataRow row in _dtUsers.Rows)
            {
                dgvUsers.Rows.Add
                    (
                        row["UserID"],
                        row["PersonID"],
                        row["FullName"],
                        row["UserName"],
                        row["IsActive"]
                    );
            }
            //dgvUsers.ClearSelection();
            cbFilter.SelectedIndex = (int)enFilterBy.None; 
        }

        private int _GetSelectedUserID()
        {
            int UserID;
            try
            {
                UserID = Convert.ToInt32(dgvUsers.SelectedCells[0].Value);

            }
            catch {
                UserID = -1;
            }

            return UserID;  

        } 
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _LoadUsers();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditUser frmAddNewUser = new frmAddEditUser();
            frmAddNewUser.DataBack += _RefreshUsers;
            frmAddNewUser.ShowDialog();
        }

        private void msEdit_Click(object sender, EventArgs e)
        {
            //dgvUsers.ClearSelection();
            int UserID = _GetSelectedUserID();

            //MessageBox.Show($"Selected UserID = {UserID}");

            if (UserID == -1) { 
                MessageBox.Show("Please Select User First!","Invalid",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmAddEditUser frmAddNewUser = new frmAddEditUser(UserID);
            frmAddNewUser.DataBack += _RefreshUsers;
            frmAddNewUser.ShowDialog();

        }
        public void _RefreshUsers()
        {
            _LoadUsers();
        }

        private void msDelete_Click(object sender, EventArgs e)
        {
            int UserID = _GetSelectedUserID();

            if (UserID == -1)
            {
                MessageBox.Show("Please Select User First!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult msgResult = MessageBox.Show($"Are you sure you want to delete user ID = {UserID} ?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (msgResult == DialogResult.Yes)
            {

                if (clsUser.Delete(UserID))
                {
                    MessageBox.Show($"User with ID = {UserID} is delete successfully.", "Done",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show($"Failed to delete this User with ID = {UserID}, because he related to information in the system ", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
