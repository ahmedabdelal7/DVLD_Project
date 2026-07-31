using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {

        public int ID {  get; set; }
        public enLicenseClass LicenseClassID { get; set; }

        enum enMode { AddNew, Update}
        enMode _Mode;

        public enum enLicenseClass
        {
            SmallMotorcycle = 1, HeavyMotorcycle = 2, OrdinaryDrivingLicense = 3,
            Commercial = 4, Agricultural = 5, SmallAndMediumBus = 6, TruckAndHeavyVehicles = 7
        }



        public clsLocalDrivingLicenseApplication() 
        {
            ID = -1;
            LicenseClassID = enLicenseClass.OrdinaryDrivingLicense;
            ApplicationID = -1;

            _Mode = enMode.AddNew;

        }

        clsLocalDrivingLicenseApplication(
                int lDLApplicationID, int applicationID, int applicantPersonID, DateTime applicationDate,
                enApplicationType applicationTypeID,enApplicationStatus applicationStatus,
                DateTime lastStatusDate, double paidFees, enLicenseClass licenseClassID, int createdByUserID
            )
        {
            ID = lDLApplicationID;
            ApplicationID = applicationID;
            ApplicantPersonID = applicantPersonID;
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationStatus = applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            LicenseClassID = licenseClassID;
            CreatedByUserID = createdByUserID;

            _Mode = enMode.Update;
        }

        public static int GetPersonActiveApplicationLicenseWithClass(int personID, enLicenseClass licenseClass)
        {
            //We should return object later on :
            int ID = -1;
            if(clsLocalDrivingLicenseApplicationData.GetPersonActiveApplicationWithLicenseClass(personID,(int)licenseClass, ref ID)){
                return ID;
            }
            return -1;
        }
        private bool _AddNew()
        {
            

            if (base.Save())
            {
                
                ID = clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(ApplicationID, (int)LicenseClassID);
            }

            return ID != -1;
            
        }
        public bool _Update() {

            int localDrivingLicenseAppID = -1;
            int applicationID = -1;
            int LicenseClassID = -1;

            if (base.Save()) {

                return (clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication(localDrivingLicenseAppID, applicationID, (int)LicenseClassID));

            }
            return false;
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

        public static clsLocalDrivingLicenseApplication Find(int LocalDrivingLicenseAppID)
        {
            int applicationID = -1, applicantPersonID = -1, createdByUser;//last
            DateTime applicationDate = DateTime.Now;
            enApplicationType applicationTypeID = enApplicationType.NewLocalLicense;
            enApplicationStatus applicationStatus = enApplicationStatus.New;
            DateTime lastStatusDate = DateTime.Now;
            double paidFees = 0.0;
            int licenseClassID  = (int)enLicenseClass.OrdinaryDrivingLicense;

            
            if(clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseAppID,ref applicationID, ref licenseClassID))
            {
                clsApplication Application  = clsApplication.Find(applicationID);
                if (Application == null)
                    return null;

                applicantPersonID = Application.ApplicantPersonID;
                applicationDate = Application.ApplicationDate;
                applicationTypeID = Application.ApplicationTypeID;
                applicationStatus = Application.ApplicationStatus;
                lastStatusDate = Application.LastStatusDate;
                paidFees = Application.PaidFees;
                createdByUser = Application.CreatedByUserID;

                //return full object
                //

                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseAppID, applicationID, applicantPersonID,applicationDate,
                    applicationTypeID, applicationStatus, lastStatusDate, paidFees,(enLicenseClass)licenseClassID,createdByUser);

            }
            return null;    

        }

        public bool Delete(int LocalDrivingLicenseAppID)
        {
            //Delete local then delete base
            if (clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(LocalDrivingLicenseAppID))
            {
                if (base.Delete(ApplicationID))
                    return true;
            }
            return false;

        }
        

    }
}
