using System.Configuration;

namespace DVLD_DataAccessLayer
{
    public class clsDataAccessSettings
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    }
}
