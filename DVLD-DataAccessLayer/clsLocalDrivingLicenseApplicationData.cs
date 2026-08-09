using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsLocalDrivingLicenseApplicationData 
    {

        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int LocalDrivingLicenseApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID,LicenseClassID)
                             VALUES
                             (@ApplicationID,@LicenseClassID);

                             SELECT CAST(SCOPE_IDENTITY() AS INT);";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            //...

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                    LocalDrivingLicenseApplicationID = Convert.ToInt32( result);

            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }

            return LocalDrivingLicenseApplicationID;
        }

        public static bool UpdateLocalDrivingLicenseApplication(int LDLApplicationID, int ApplicationID, int LicenseClassID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE LocalDrivingLicenseApplications
                             SET ApplicationID = @ApplicationID,
							     LicenseClassID = @LicenseClassID 
                             WHERE LocalDrivingLicenseApplicationID = @LDLApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);

            //...

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteLocalDrivingLicenseApplication(int LDLApplicationID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLApplicationID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool GetLocalDrivingLicenseApplicationInfoByID(int LDLApplicationID, ref int ApplicationID,ref int LicenseClassID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    // Param1 = (string)reader["Param1"];
                    //...

                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
                }
                else
                {
                    IsFound = false;
                }

                reader.Close();
            }
            catch (Exception)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool GetPersonActiveApplicationWithLicenseClass(int ApplicantPersonID, int LicenseClassID, ref  int LocalDrivingLicenseApplicationID,ref int ApplicationID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from LocalDrivingLicenseApplications join Applications 
                            on LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                            where ApplicantPersonID = @ApplicantPersonID and ApplicationStatus = 1 and LicenseClassID = @LicenseClassID ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    // Param1 = (string)reader["Param1"];
                    //...
                    LocalDrivingLicenseApplicationID = Convert.ToInt32( reader["LocalDrivingLicenseApplicationID"]);
                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);

                }
                else
                {
                    IsFound = false;
                }

                reader.Close();
            }
            catch (Exception)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool IsLocalDrivingLicenseApplicationExist(int LDLApplicationID)
        {
            bool IsExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLApplicationID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                IsExist = (result != null);

                //Doctor approach:
                //SqlDataReader reader = command.ExecuteReader();
                //IsExist = reader.HasRows;
                //reader.Close();

            }
            catch (Exception)
            {
                IsExist = false;
            }
            finally
            {
                connection.Close();
            }

            return IsExist;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM LocalDrivingLicenseApplications_View";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dataTable.Load(reader);

                reader.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }

        public static bool DoesPassTestType(int LDLAppID, int TestTypeID) {

            bool doesPass = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Top 1 TestResult
							FROM LocalDrivingLicenseApplications AS ld JOIN
								TestAppointments AS ta ON ld.LocalDrivingLicenseApplicationID =
								ta.LocalDrivingLicenseApplicationID JOIN
								Tests ON ta.TestAppointmentID = Tests.TestAppointmentID
							WHERE ld.LocalDrivingLicenseApplicationID = @LDLAppID
									AND(ta.TestTypeID = @TestTypeID)	
							order by Tests.TestID DESC;";

            SqlCommand command = new SqlCommand(query, connection);

            //param

            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                connection.Open();
                
                object result = command.ExecuteScalar();

                if(result != null){
                    doesPass = Convert.ToBoolean(result);
                }
                

            }
            catch (Exception ex) { 
            
                doesPass = false;
            }
            finally
            {
                connection.Close();
                
            }
            return doesPass;
            
        }

        public static int GetPassedTestsCount(int LDLAppID) {
            int passedTestsCount = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select count(*) as PassedTestsCount  from LocalDrivingLicenseApplications ld join 
	                            TestAppointments ta ON ta.LocalDrivingLicenseApplicationID = ld.LocalDrivingLicenseApplicationID join 
	                            Tests ON Tests.TestAppointmentID = ta.TestAppointmentID
                            where ld.LocalDrivingLicenseApplicationID = @LDLAppID and Tests.TestResult = 1;";

            SqlCommand command = new SqlCommand(query, connection);

            //param

            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int Count))  
                    passedTestsCount = Count;


            }
            catch { }
            finally
            {
                connection.Close();

            }
            return passedTestsCount;
        }

        public static bool DoesHaveActiveTestAppointment(int LDLAppID, int TestTypeID)
        {

            bool doesPass = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Top 1 TestResult
							FROM LocalDrivingLicenseApplications AS ld JOIN
								TestAppointments AS ta ON ld.LocalDrivingLicenseApplicationID =
								ta.LocalDrivingLicenseApplicationID JOIN
								Tests ON ta.TestAppointmentID = Tests.TestAppointmentID
							WHERE ld.LocalDrivingLicenseApplicationID = @LDLAppID
									AND(ta.TestTypeID = @TestTypeID)	
							order by Tests.TestID DESC;";

            SqlCommand command = new SqlCommand(query, connection);

            //param

            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                doesPass = result != null;

            }
            catch (Exception ex)
            {

                doesPass = false;
            }
            finally
            {
                connection.Close();

            }
            return doesPass;

        }

        public static bool DoesFailPrevTest(int LDLAppID, int TestTypeID)
        {

            bool DoesFail = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select Fail = 1  from Tests join TestAppointments on Tests.TestAppointmentID = TestAppointments.TestAppointmentID 
                            where TestTypeID = @TestTypeID
                            and LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                            and TestResult = 0;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if(result != null )
                    DoesFail = Convert.ToBoolean(result);

            }
            catch (Exception ex)
            {

                
            }
            finally
            {
                connection.Close();

            }
            return DoesFail;

        }

        
    }
}
