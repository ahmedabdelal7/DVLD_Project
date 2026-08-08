using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsTestAppointmentData
    {

        public static int AddNewTestAppointment(int TestTypeID, int LDLAppID, DateTime AppointmentDate, double PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestAppointmentID)
        {
            int TestAppointmentID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO TestAppointments (
				                TestTypeID,
				                LocalDrivingLicenseApplicationID,
				                AppointmentDate,
				                PaidFees,
				                CreatedByUserID,
				                IsLocked,
				                RetakeTestAppointmentID)
                            VALUES(
				                @TestTypeID,
				                @LocalDrivingLicenseApplicationID,
				                @AppointmentDate,
				                @PaidFees,
				                @CreatedByUserID,
				                @IsLocked,
				                @RetakeTestAppointmentID);
                            SELECT CAST(SCOPE_IDENTITY() AS INT);";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            if(RetakeTestAppointmentID == -1)
            {
                command.Parameters.AddWithValue("@RetakeTestAppointmentID", System.DBNull.Value);
            }
            else command.Parameters.AddWithValue("@RetakeTestAppointmentID", RetakeTestAppointmentID);
            

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    TestAppointmentID = InsertedID;

            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }

            return TestAppointmentID;
        }
        public static bool UpdateTestAppointment(int TestAppointmentID, DateTime AppointmentDate,bool IsLocked, int RetakeTestApplicationID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE TestAppointments
                             SET AppointmentDate = @AppointmentDate,
							     IsLocked = @IsLocked,
							     RetakeTestApplicationID = @RetakeTestApplicationID
                             WHERE TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            if (RetakeTestApplicationID == -1)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", System.DBNull.Value);
            }else
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
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
        public static bool GetTestAppointmentInfoByID(int TestAppointmentID, ref int TestTypeID, ref int LDLAppID, ref DateTime AppointmentDate,
            ref double PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestAppointmentID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    TestTypeID = Convert.ToInt32( reader["TestTypeID"]);
                    LDLAppID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                    AppointmentDate = (DateTime)(reader["AppointmentDate"]);
                    PaidFees = Convert.ToDouble(reader["PaidFees"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    IsLocked = Convert.ToBoolean(reader["IsLocked"]);

                    RetakeTestAppointmentID = reader[7] == DBNull.Value ? -1 : reader.GetInt32(7);

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

        public static DataTable GetAllTestAppointmentsByAppIDAndTestType(int LDLAppID, int TestTypeID)
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select ta.TestAppointmentID , 
		                            ta.AppointmentDate,
		                            ta.PaidFees,
		                            ta.IsLocked
                            from TestAppointments ta
                            where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TestTypeID = @TestTypeID
                            order by TestAppointmentID DESC;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);



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
        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "DELETE FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

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
        public static bool DoesHaveActiveTestAppointment(int LDLAppID, int TestTypeID)
        {
            bool DoesHaveActiveTestAppointment = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select top 1 ta.TestAppointmentID from TestAppointments ta join 
                            LocalDrivingLicenseApplications ld on ld.LocalDrivingLicenseApplicationID = ta.LocalDrivingLicenseApplicationID
                            where ld.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                            and TestTypeID = @TestTypeID
                            and IsLocked = 0;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                DoesHaveActiveTestAppointment = result != null;


            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }

            return DoesHaveActiveTestAppointment;
        }
        public static int GetTestTrialCount(int LDLAppID, int TestTypeID)
        {
            int TrialCount = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select count(*) AS TrialTestCount 
                            from Tests join TestAppointments on Tests.TestAppointmentID = TestAppointments.TestAppointmentID 
                            where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                            and TestTypeID = @TestTypeID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if(result != null && int.TryParse(result.ToString() , out int Count)){
                    TrialCount = Count;
                }


            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }

            return TrialCount;
        }
    }
}
