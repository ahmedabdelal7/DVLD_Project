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
        

        public int PersonID
        {
            get { return _Person.PersonID; }
        }
        
        private void _SetPersonImage()
        {
            if (string.IsNullOrEmpty(_Person.ImagePath))
            {
                ppPersonImage.Image = (_Person.Gender == clsPerson.enGender.Male ? Resources.man : Resources.woman);
            }
            else
            {
                ppPersonImage.ImageLocation = _Person.ImagePath;
            }
            
        }

        private void _LoadInfo()
        {
            lblPersonID.Text = _Person.PersonID.ToString();
            lblNationalNo.Text = _Person.NationalNo;
            lblName.Text = _Person.FullName;
            lblPhone.Text = _Person.Phone;
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblGender.Text = (_Person.Gender == clsPerson.enGender.Male ? "Male" : "Female");
            lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
            _SetPersonImage();
        }
        public void LoadPersonInfo(int personID)
        {
            ResetPersonCard();
            _Person = clsPerson.Find(personID);

            _LoadInfo();
        }

        public void LoadPersonInfo( string NationalNo)
        {
            ResetPersonCard();
            _Person = clsPerson.Find(NationalNo);

            _LoadInfo();
        }
        private void llEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_Person == null)
            {
                return; 
            }
            frmAddEditPerson frm = new frmAddEditPerson(_Person.PersonID);
            frm.DataBack += LoadPersonInfo;
            frm.ShowDialog();
        }
        public void ResetPersonCard()
        {
            lblPersonID.Text = "N/A";
            lblNationalNo.Text = "[??]";
            lblName.Text = "[???]";
            lblGender.Text = "[??]";
            lblCountry.Text = "[??]";
            lblEmail.Text = "[??]";
            lblPhone.Text = "[??]";
            lblAddress.Text = "[??]";
            lblDateOfBirth.Text = "[??]";
            ppPersonImage.Image = Resources.man;
            _Person = null;

        }
    }
}
