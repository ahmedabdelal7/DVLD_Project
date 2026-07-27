using DVLD.Applications;
using DVLD.Common_Classes;
using DVLD.People;
using DVLD.Tests;
using DVLD.Users;
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

namespace DVLD
{
    public partial class frmMain : Form
    {
        clsUser _CurrentUser;

        public frmMain()
        {
            //_CurrentUser = clsUser.Find(UserID);
            InitializeComponent();
        }
        public delegate void DataBackEventHandler(bool EndProgram);

        // 2. Declare event based on delegate
        public event DataBackEventHandler DataBack;

        private void frmMain_Load(object sender, EventArgs e)
        {
            //MessageBox.Show($"{clsGlobalSettings.UserName} & {clsGlobalSettings.Password}");
            _CurrentUser = clsUser.Find(clsGlobalSettings.LoggedInUserID);
            //MessageBox.Show($"UserID = {_CurrentUser.UserID}");
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople frmManagePeople = new frmManagePeople();
            frmManagePeople.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frmManageUsers = new frmManageUsers();
            frmManageUsers.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(false);
            this.Hide();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataBack?.Invoke(true);
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frmUserInfo = new frmUserInfo(clsGlobalSettings.LoggedInUserID);
            frmUserInfo.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword(clsGlobalSettings.LoggedInUserID);
            frmChangePassword.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frmManageApplicationTypes = new frmManageApplicationTypes();
            frmManageApplicationTypes.ShowDialog(); 
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes frmManageTestTypes = new frmManageTestTypes();
            frmManageTestTypes.ShowDialog();
        }
    }
}
