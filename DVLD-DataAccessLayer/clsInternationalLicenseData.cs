using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsInternationalLicenseData
    {


        public static int AddNewInternationalLicense(int ApplicationID, DateTime IssueDate, DateTime ExpirationDate, int LocalLicenseID,
            int DriverID, bool IsActive, int CreatedByUserID)
        {
            int InternationalLicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO InternationalLicenses
                                       (ApplicationID,
			                            DriverID,
			                            IssuedUsingLocalLicenseID,
			                            IssueDate,
			                            ExpirationDate,
			                            IsActive,
                                        CreatedByUserID)
                                 VALUES
                                       (@ApplicationID,
			                            @DriverID, 
			                            @IssuedUsingLocalLicenseID,
			                            @IssueDate,
			                            @ExpirationDate,
			                            @IsActive,
			                            @CreatedByUserID;
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", LocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            //...

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                    InternationalLicenseID = (int)result;

            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }

            return InternationalLicenseID;
        }


        public static bool GetLicenseInfoByID(int InternationalLicenseID, ref int ApplicationID, ref DateTime IssueDate, ref DateTime ExpirationDate,
            ref int LocalLicenseID, ref int DriverID,ref bool IsActive,ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from InternationalLicenses where InternationalLicenseID = @InternationalLicenseID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                    LocalLicenseID = Convert.ToInt32(reader["IssuedUsingLocalLicenseID"]);
                    DriverID = Convert.ToInt32(reader["DriverID"]);
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
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



        public static int GetActiveInternationalLicenseIDByLocalLicenseID(int LocalLicenseID)
        {
            int InternationalLicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select InternationalLicenseID from InternationalLicenses 
                            where IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", LocalLicenseID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    if(int.TryParse(reader.ToString(), out int selectedID))
                        InternationalLicenseID= selectedID;
                                        
                }
               

                reader.Close();
            }
            catch (Exception)
            {
                
            }
            finally
            {
                connection.Close();
            }

            return InternationalLicenseID;
        }
    }
}
