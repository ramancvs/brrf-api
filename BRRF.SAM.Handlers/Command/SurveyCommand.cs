using BRRF.Core.BusinessManager.Interface;
using BRRF.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRRF.SAM.Handlers.Command
{
    public class SurveyCommand : BaseRequest, ICommand
    {
        public int Id { get; set; }
        public int PBLSiteNumber { get; set; } 
        public string Brand { get; set; } 
        public string SiteAddress { get; set; }
        public string SiteCity { get; set; }
        public string SiteState { get; set; } 
        public string SiteZipcode { get; set; }
        public string SurveyDate { get; set; }
    }
}
