using BRRF.DataAccess.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace BRRF.DataAccess
{
    public class DBContext
    {
        public static Func<DbConnection> _globalConnectionFactory = () => new SqlConnection("Data Source=192.168.38.30;Initial Catalog=Globalbrrf;Persist Security Info=True;User ID=Globalbrrf;Password=Globalbrrf@432");
        private Func<DbConnection> _tenantConnection;

        public List<Brand> Brands { get; set; }

        public void LoadTenantConnection(string BrandName)
        {
            var brand =
                Tenants.ToList().Where(x => x.Brand.ToLower() == BrandName.ToLower()).First();
            if (brand == null)
                throw new Exception("Brand not found");

            _tenantConnection = () => new SqlConnection(brand.ConnectionString);
        }

        public IEnumerable<Tenant> Tenants
        {
            get { return LoadTenants(); }
        }


        public IEnumerable<Survey> Survey
        {
            get { return LoadSurvey(); }
        }



        private IEnumerable<Tenant> LoadTenants()
        {
            var sql = SqlText_Globalbrrf.Select_Tenant;
            using (var connection = _globalConnectionFactory())
            {
                connection.Open();
                var tenant = connection.Query<Tenant>(sql).ToList();
                return tenant;
            }
        }

        private IEnumerable<Survey> LoadSurvey()
        {
            var sql = SqlText_Globalbrrf.Select_Survey;
            using (var connection = _tenantConnection())
            {
                connection.Open();
                var survey = connection.Query<Survey>(sql).ToList();
                return survey;
            }
        }

        public void ApproveSurvey(Survey survey)
        {
            try
            {
                var sql = SqlText_Globalbrrf.Approve_Survey;
                using (var connection = _tenantConnection())
                {
                    connection.Open();
                    connection.Execute("INSERT INTO ApprovedSurvey SELECT " + survey.Id + ",1");
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}
