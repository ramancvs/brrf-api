
namespace BRRF.DataAccess
{
    public static class SqlText_Globalbrrf
    {
        public static string Select_Tenant = "select * from [tenant]";
        public static string Select_Survey = "exec sp_GetSurvey";
        public static string Approve_Survey = "exec sp_ApproveSurvey";
    }
}
