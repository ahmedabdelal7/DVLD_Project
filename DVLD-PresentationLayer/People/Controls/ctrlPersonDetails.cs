using DVLD.Properties;
using DVLD_BusinessLayer;
using DVLD_BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People.Controls
{
    public partial class ctrlPersonDetails : UserControl
    {
        public ctrlPersonDetails()
        {
            InitializeComponent();
        }
        clsPerson _Person;
        enum enGender { Male = 0, Female = 1}

        

        private void _SetPersonImage()
        {
            if (string.IsNullOrEmpty(_Person.ImagePath))
            {
                ppPersonImage.Image = (_Person.Gender == (short)enGender.Male ? Resources.man : Resources.woman);
            }
            else
            {
                ppPersonImage.ImageLocation = _Person.ImagePath;
            }
        }

        public void LoadPersonInfo(object sender,int personID)
        {
            _Person = clsPerson.Find(personID);

            lblPersonID.Text = _Person.PersonID.ToString();
            lblNationalNo.Text = _Person.NationalNo;
            lblName.Text = _Person.FullName;
            lblPhone.Text = _Person.Phone;
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblGender.Text = (_Person.Gender == (short)enGender.Male ? "Male" : "Female");
            lblCountry.Text = clsCountry.FindByID(_Person.NationalityCountryID).CountryName;
            _SetPersonImage();
        }

        private void llEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(_Person.PersonID);
            frm.DataBack += LoadPersonInfo;
            frm.ShowDialog();
        }
    }
}
