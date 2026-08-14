using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsLicenseData
    {

        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseCLass, DateTime IssueDate, DateTime ExpirationDate,
            string Notes, double PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Licenses
                                   (ApplicationID
                                   ,DriverID 
                                   ,LicenseClass 
                                   ,IssueDate 
                                   ,ExpirationDate 
                                   ,Notes 
                                   ,PaidFees 
                                   ,IsActive 
                                   ,IssueReason 
                                   ,CreatedByUserID )
                             VALUES
                                   (@ApplicationID, 
                                   @DriverID, 
                                   @LicenseClass, 
                                   @IssueDate, 
                                   @ExpirationDate, 
                                   @Notes, 
                                   @PaidFees, 
                                   @IsActive, 
                                   @IssueReason, 
                                   @CreatedByUserID);
                            select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseCLass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            //...

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(),out int InsertedID))
                    LicenseID = InsertedID;

            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }

            return LicenseID;
        }

        public static bool GetLicenseInfoByID(int LicenseID,ref int ApplicationID,ref int DriverID,ref int LicenseCLass,ref DateTime IssueDate,
           ref DateTime ExpirationDate,ref string Notes,ref double PaidFees,ref bool IsActive,ref byte IssueReason,ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    DriverID = Convert.ToInt32(reader["DriverID"]);
                    LicenseCLass = Convert.ToInt32(reader["LicenseCLass"]);
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                    Notes = Convert.ToString(reader["Notes"]);
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                    IssueReason = Convert.ToByte(reader["IssueReason"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);

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


        public static DataTable GetAllLicenses()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Licenses";

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


        public static bool DoesHaveLicenseOfLicenseCLass(int PersonID, int LicenseClassID)
        {
            bool DoesHaveLicense = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select Found = 1 from Licenses
                            join Applications on Licenses.ApplicationID = Applications.ApplicationID
                            join LocalDrivingLicenseApplications ld on Applications.ApplicationID = ld.ApplicationID
                            where ApplicantPersonID = @ApplicantPersonID and LicenseClass = @LicenseClass;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                DoesHaveLicense = (result != null);

                //Doctor approach:
                //SqlDataReader reader = command.ExecuteReader();
                //IsExist = reader.HasRows;
                //reader.Close();

            }
            catch (Exception)
            {
                DoesHaveLicense = false;
            }
            finally
            {
                connection.Close();
            }

            return DoesHaveLicense;
        }



        public static bool DeactivateLicense(int LicenseID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Licenses
                         SET IsActive = 0
                         WHERE LicenseID = @LicenseID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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

        
    }
}
