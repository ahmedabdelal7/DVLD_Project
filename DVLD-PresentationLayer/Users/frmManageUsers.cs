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

        DataTable _dtUsers;
        private void _LoadUsers()
        {
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
        }
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _LoadUsers();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddNewUser frmAddNewUser = new frmAddNewUser();
            frmAddNewUser.ShowDialog();
        }
    }
}
