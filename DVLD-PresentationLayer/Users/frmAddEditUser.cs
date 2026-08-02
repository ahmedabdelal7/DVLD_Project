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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD.Users
{
    public partial class frmAddEditUser : Form
    {

        public delegate void DataBackEventHandler();

        // 2. Declare event based on delegate
        public event DataBackEventHandler DataBack;
        enum enMode { AddNew,Update};
        enMode _Mode;

        int _PersonID;
        string _NationalNo;
        int _UserID;
        clsUser _User;


        public frmAddEditUser(int UserID)
        {
            _Mode = enMode.Update;
            _UserID = UserID;
            InitializeComponent();
        }
        public frmAddEditUser()
        {
            _Mode = enMode.AddNew;
            InitializeComponent();
        }
        public enum enFilterBy
        {
            NationalNo = 0, PersonID = 1
        }
        
        private void _LoadInfo()
        {
            if (_Mode == enMode.AddNew) {

                lblAddEditUser.Text = "Add New User";
                _User = new clsUser();
                return;
            }

            lblAddEditUser.Text = "Update User";

            _User = clsUser.Find(_UserID);

            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);

            ctrlPersonCardWithFilter1.DisableFilter();

            lblUserID.Text = _UserID.ToString();

            txtUserName.Text = _User.UserName.ToString();
            txtPassword.Text = _User.Password.ToString();
            txtConfirmPassword.Text = _User.Password.ToString();
            chkIsActive.Checked = _User.IsActive;

            

        }
        private void btnNext_Click(object sender, EventArgs e)
        {    
            _PersonID = ctrlPersonCardWithFilter1.PersonID;
            
            _NationalNo = ctrlPersonCardWithFilter1.NationalNo;

            if (_PersonID == -1 && _NationalNo == "")
            {
                MessageBox.Show("Please select person first!","Failed",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            
            if(_Mode == enMode.AddNew)
            {

                if(ctrlPersonCardWithFilter1.SelectedFilter ==(short)enFilterBy.PersonID)
                {
                    if (clsUser.IsExistByPersonID(_PersonID))
                    {
                        MessageBox.Show("This Person is connected to another user, choose another person.",
                            "Invalid Choice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
            
                }
                else
                {
                    if (clsUser.IsExistByNationalNo(_NationalNo))
                    {
                        MessageBox.Show("This Person is connected to another user, choose another person.",
                            "Invalid Choice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }

                // code for go to login info:
                tabControl1.SelectedIndex = 1;
                return;
            }

            //if mode == update

            tabControl1.SelectedIndex = 1;

        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {

            DataBack?.Invoke();
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {

                MessageBox.Show("Some fields not right!");
                return;
            }

            
            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User.IsActive = chkIsActive.Checked;

            if (_User.Save())
            {
                if(_Mode == enMode.AddNew)
                {
                    MessageBox.Show($"User added successfully with user id [{_User.UserID}].", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblUserID.Text = _User.UserID.ToString();
                    _UserID = _User.UserID;
                }
                else
                {
                    _Mode = enMode.Update;
                    MessageBox.Show($"User updated successfully with id [{_User.UserID}].", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                _LoadInfo();
            }
            else
            {

                MessageBox.Show($"Failed to adding this user ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            //TextBox textBox = sender as TextBox;

            if (string.IsNullOrEmpty(txtUserName.Text))
            {

                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Username should not be empty!");

                return;

            }

                string UserName = txtUserName.Text.Trim().ToString();
            if(_Mode == enMode.AddNew)
            {
                if (clsUser.IsExistByUserName(UserName))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "This username already is exist, choose another one!");
                    return;
                }

            }
            else
            {
                //Update mode
                if(clsUser.IsExistByUserName(UserName) && txtUserName.Text != _User.UserName)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "This username already is exist, choose another one!");
                    return;
                }
            }

            errorProvider1.SetError(txtUserName, null);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel= true;
                errorProvider1.SetError(txtPassword,"Password should not be empty!");
            }else
                errorProvider1.SetError(txtPassword,null);

        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            };
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _LoadInfo();
        }

        private void frmAddEditUser_Activated(object sender, EventArgs e)
        {
            //this.Activate();
            
        }
    }
}
