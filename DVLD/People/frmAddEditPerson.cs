using DVLD.Common_Classes;
using DVLD.Properties;
using DVLD_BusinessLayer;
using DVLD_BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmAddEditPerson : Form
    {
        enum enMode { AddNew, Update}
        enum enGender { Male=0, Female=1 }

        enMode _Mode;
        int _PersonID;
        clsPerson _Person;
        public frmAddEditPerson()
        {
            InitializeComponent();
            _PersonID = -1;
            _Mode = enMode.AddNew;
        }
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _Mode = enMode.Update;
        }

        private void _FillCountriesInComboBox()
        {
            //Load all countries from database
            DataTable dt = clsCountry.ListAllCountries();
            foreach (DataRow country in dt.Rows)
            {
                //add countries to ComboBox control
                cbCountries.Items.Add(country["CountryName"]);
            }
        }
        private void _SetDateOfBirthSelectRange()
        {
            //Set Maximum date is date now - 18 year, to add user less than 18 years old  
            dateTimePicker1.MaxDate = DateTime.Today.AddYears(-18);
            //Set Minimum date date now - 100 year, to prevent adding user grater than 100 years old
            dateTimePicker1.MinDate = DateTime.Today.AddYears(-100);
        }
        private void _LoadData()
        {

            _FillCountriesInComboBox();
            _SetDateOfBirthSelectRange();

            if(_Mode == enMode.AddNew)
            {
                _Person = new clsPerson();
                lblAddEditPerson.Text = "Add New Person";
                lblPersonID.Text = "N/A";
                rbMale.Checked = true;
                
                //Set default person image to man 
                ppPersonImage.Image = Resources.man;
                ppPersonImage.ImageLocation = null;
                cbCountries.SelectedItem = "Egypt";
    
                return;
            }

            if(!clsPerson.IsExist(_PersonID))
            {
                //do something and return if the user not exist in database.
                //
                MessageBox.Show("this person does not exist!");
                this.Close();
                return;
            }
            _Person = clsPerson.Find(_PersonID);


            lblPersonID.Text = _Person.PersonID.ToString();
            txtFirstName.Text = _Person.FirstName.ToString();
            txtSecondName.Text = _Person.SecondName.ToString();
            txtThirdName.Text = _Person.ThirdName.ToString();
            txtLastName.Text = _Person.LastName.ToString();
            txtNationalNo.Text = _Person.NationalNo.ToString();
            dateTimePicker1.Value = _Person.DateOfBirth;
            txtEmail.Text = _Person.Email.ToString();
            txtPhone.Text = _Person.Phone.ToString();
            txtAddress.Text = _Person.Address.ToString();   
            ppPersonImage.ImageLocation = _Person.ImagePath;
            cbCountries.SelectedItem = clsCountry.FindByID(_Person.NationalityCountryID).CountryName;

            if(_Person.Gender == (short)enGender.Male)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;


        }
        private void _GenderCheckedChange(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ppPersonImage.ImageLocation))
            {
                ppPersonImage.Image = (rbMale.Checked == true ? Resources.man : Resources.woman);
            }

        }
        private void _ValidateTextBox(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrEmpty(textBox.Text.Trim()))
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider1.SetError(textBox, "This field should not be empty!");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox, null);
            }
        }
        private void _ValidateEmail(object sender, CancelEventArgs e)
        {
            TextBox email = sender as TextBox;
            if (string.IsNullOrEmpty(email.Text) || clsValidate.IsValidEmail(email.Text))
            {
                e.Cancel = false;
                errorProvider1.SetError(email, null);
                return;
            }

            e.Cancel = true;
            email.Focus();
            errorProvider1.SetError(email, "Email address is not valid!");
            return;

        }
        private void _ValidateNationalNo(object sender, CancelEventArgs e)
        {
            TextBox nationalNo = sender as TextBox;
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                nationalNo.Focus();
                errorProvider1.SetError(nationalNo, "National Number should not be empty!");
                return;
            }

            if (clsPerson.IsExist(nationalNo.Text.Trim()))
            {
                e.Cancel = true;
                nationalNo.Focus();
                errorProvider1.SetError(nationalNo, "National Number is already exist, enter another one!");
                return;
            }

            e.Cancel = false;
            errorProvider1.SetError(nationalNo, null);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _FillDataToPersonObject()
        {


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("cannot save, fill required fields or enter valid fields first!","Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Mode == enMode.AddNew) { 
                
                DialogResult msgResult =  MessageBox.Show("Are you sure you want to add this user?","Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
                if (msgResult == DialogResult.Yes) {
                    

                }
                
            }
        }

       
    }
}
