using BRRF.SAM.Handlers.Query;
using BRRF.DataAccess.Model;
using System.Collections.Generic;
using System.Linq;
using BRRF.Core.BusinessManager.Interface;

namespace BRRF.SAM.Handlers.QueryHandler
{
    public class GetSurveyHandler : HandlerBase, IQueryHandler<GetSurvey, List<Survey>>
    {
        /// <summary>
        /// Get all surveys for a tenant
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<Survey> Execute(GetSurvey query)
        {
            {
                LoadTenantConnection(query.BrandName);
                return Survey.ToList();
            }
        }
    }
}
