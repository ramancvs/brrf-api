using BRRF.Common;
using BRRF.Core.BusinessManager;
using BRRF.Core.BusinessManager.Interface;
using BRRF.DataAccess.Model;
using BRRF.SAM.Handlers.Query;
using BRRF.SAM.Handlers.QueryHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BRRF.SAM.WebApi.Helpers;

namespace BRRF.SAM.WebApi.Controllers
{
    public class GetSurveyController : ApiController
    {
        IDispatcher _dispatcher;
        public GetSurveyController()
        {
            _dispatcher = new Dispatcher();
            _dispatcher.Register<GetSurvey, List<Survey>>(new GetSurveyHandler());
            _dispatcher.Register(new AuditHandler());
        }

        // GET: api/GetSurvey
        public List<Survey> Get()
        {
            return _dispatcher.Execute<GetSurvey, List<Survey>>(new GetSurvey { BrandName = UserContext.GetUserContext(Request).brand_name });
        }

        //// GET: api/GetSurvey/5

        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/GetSurvey
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GetSurvey/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GetSurvey/5
        public void Delete(int id)
        {
        }
    }
}
