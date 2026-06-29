using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsCountry
    {
        public int CountryID {  get; set; }
        public string CountryName { get; set; }
        
        private clsCountry(int countryID,string countryName)
        {
            CountryID = countryID;
            CountryName = countryName;
        }

        public static clsCountry FindByID(int countryID) { 
            string countryName = "";   

            if(clsCountryData.GetCountryByID(countryID,ref countryName))
            {
                return new clsCountry(countryID,countryName);
            }
            return null;
        }

        public static clsCountry FindByName(string countryName)
        {
            int countryID = -1;

            if (clsCountryData.GetCountryByName(countryName, ref countryID))
            {
                return new clsCountry(countryID, countryName);
            }
            return null;
        }

        public static DataTable ListAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }
    }
}
