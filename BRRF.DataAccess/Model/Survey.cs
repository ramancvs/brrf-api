namespace BRRF.DataAccess.Model
{
    public class Survey
    {
        public int Id { get; set; }
        public int PBLSiteNumber { get; set; }
        public string Brand { get; set; }
        public string SiteAddress { get; set; }
        public string SiteCity { get; set; }
        public string SiteState { get; set; }
        public string SiteZipcode { get; set; }
        public string SurveyDate { get; set; }
        public string ApprovedStatus { get; set; }

        
    }
}
