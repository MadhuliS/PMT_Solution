using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using PlanMyTripDAL;

namespace PlanMyTripWebAPI.Controllers
{
    public class SearchController : ApiController
    {
        PMTRepository planMyTripDBContext = null;

        [Route("SearchFlight/{o}/{d}/{dt}")]
        public JsonResult<List<PlanMyTripDAL.usp_SearchFlights_Result>> GetFlightByUSP(string o,string d,DateTime dt)
        {
            planMyTripDBContext = new PMTRepository();
            var flightList = planMyTripDBContext.GetFlightDetailsByUPI(o, d, dt);
            var jsonRes = Json<List<PlanMyTripDAL.usp_SearchFlights_Result>>(flightList);
            return jsonRes;
        }
    }
}
