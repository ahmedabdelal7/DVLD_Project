using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsTest
    {
        enum enMode
        {
            AddNew ,Updated
        }
        enMode _Mode;

        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes {  get; set; }
        public int CreatedByUser {  get; set; }

        public clsTest() {
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = string.Empty;
            CreatedByUser = -1;
            _Mode = enMode.AddNew;  
        }

        clsTest(int testID,int testAppointmentID, bool testResult, string notes, int createdByUser)
        {
            TestID = testID;
            TestAppointmentID = testAppointmentID;
            TestResult = testResult;
            Notes = notes;
            CreatedByUser = createdByUser;

            _Mode= enMode.Updated;
        }


        public static clsTest Find(int testID)
        {
            int testAppointmentID = -1, createdByUser = -1;
            bool testResult = false;
            string notes = "";



        }


    }
}
