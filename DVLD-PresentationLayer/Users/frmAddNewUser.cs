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
    public partial class frmAddNewUser : Form
    {
        public frmAddNewUser()
        {
            InitializeComponent();
        }

        int _PersonID;
        DataTable _dtUsers;
        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            _PersonID = ctrlPersonCardWithFilter1.PersonID;
            _dtUsers = clsUser.ListAllUsers();
            

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _PersonID = ctrlPersonCardWithFilter1.PersonID;
            if (_PersonID == -1)
            {
                MessageBox.Show("Please select user first!");
                return;
            }

            DataView dvUsers = _dtUsers.DefaultView;

            dvUsers.RowFilter = $"PersonID = {_PersonID}";
            //if dvUsers has rows means that this user is connected to another person.

            if (dvUsers.Count > 0)
            {
                MessageBox.Show("This Person is connected to another user, choose another person.",
                    "Invalid Choice",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // code for go to login info:
            tabControl1.SelectedIndex = 1;

            MessageBox.Show("Are you sure you want to add this user?");

        }
    }
}
