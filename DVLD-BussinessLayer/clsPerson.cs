using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_BussinessLayer
{
    public class clsPerson
    {

        enum enMode
        {
            AddNew, Update
        }
        enMode _Mode;
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public short Gender { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }


        public clsPerson()
        {
            PersonID = -1;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Email = string.Empty;
            Address = string.Empty;
            Phone = string.Empty;
            Gender = 0;
            NationalityCountryID = -1;
            ImagePath = string.Empty;

            _Mode = enMode.AddNew;

        }

        private clsPerson(int personID, string nationalNo, string firstName, string secondName, string thirdName, string lastName,
            DateTime dateOfBirth, string email, string address, string phone, short gender, int nationalityCountryID, string imagePath)
        {
            PersonID = personID;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            Address = address;
            Phone = phone;
            Gender = gender;
            NationalityCountryID = nationalityCountryID;
            ImagePath = imagePath;

            _Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

            return PersonID > -1;
        }
        private bool _Update()
        {

            return clsPersonData.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }

        public static bool Delete(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }
        public static clsPerson Find(int PersonID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Email = "", Phone = "", ImagePath = "";
            short Gender = 0;
            int NationalityCountryID = -1;
            DateTime DateOfBirth = DateTime.MinValue;

            if (clsPersonData.GetPersonByID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                 DateOfBirth, Email, Address, Phone, Gender, NationalityCountryID, ImagePath);
            }
            return null;

        }
        public static clsPerson Find(string NationalNo)
        {
            int PersonID = 0;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Email = "", Phone = "", ImagePath = "";
            short Gender = 0;
            int NationalityCountryID = -1;
            DateTime DateOfBirth = DateTime.MinValue;

            if (clsPersonData.GetPersonByNationalNo(NationalNo, ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                 DateOfBirth, Email, Address, Phone, Gender, NationalityCountryID, ImagePath);
            }
            return null;

        }
        public static bool IsExist(int PersonID)
        {
            return clsPersonData.IsPersonExistByID(PersonID);
        }
        public static bool IsExist(string NationalNo)
        {
            return clsPersonData.IsPersonExistByNationalNo(NationalNo);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _Update();
            }
            return false;

        }



    }
}
