using BRRF.Core.BusinessManager.Interface;
using BRRF.DataAccess.Model;
using System.Collections.Generic;

namespace BRRF.SAM.Handlers.Query
{
    /// <summary>
    /// Request surveys
    /// </summary>
    public class GetSurvey: BaseRequest , IQuery<List<Survey>>
    {
        public int Id { get; set; }
        public int PBLSiteNumber { get; set; } 
        public string SiteAddress { get; set; }
        public string SiteCity { get; set; }
        public string SiteState { get; set; }
        public string SiteZipcode { get; set; }
        public string SurveyDate { get; set; }
        public string ApprovedStatus { get; set; }
        
    }
}
