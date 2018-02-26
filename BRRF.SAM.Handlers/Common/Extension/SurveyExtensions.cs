using BRRF.DataAccess.Model;
using BRRF.SAM.Handlers.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRRF.SAM.Handlers.Common.Extension
{
    public static class SurveyExtensions
    {
        public static Survey Map(this SurveyCommand surveyCommand)
        {
            return new Survey() {
                Id = surveyCommand.Id,
                PBLSiteNumber = surveyCommand.PBLSiteNumber,
                Brand = surveyCommand.Brand,
                SiteAddress = surveyCommand.SiteAddress,
                SiteCity = surveyCommand.SiteCity,
                SiteState = surveyCommand.SiteState,
                SiteZipcode = surveyCommand.SiteZipcode,
                SurveyDate = surveyCommand.SurveyDate,
            };
        }
    }
}
