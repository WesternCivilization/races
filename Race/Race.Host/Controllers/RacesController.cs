using Race.Host.Models;
using Race.Host.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Race.Host.Controllers
{
    [RoutePrefix("api/races")]
    public class RacesController : BaseApiController
    {
        private readonly IRaceDayService _raceDayService;

        public RacesController(IRaceDayService raceDayService)
        {
            _raceDayService = raceDayService;
        }

        [HttpGet]
        public IHttpActionResult GetRaces()
        {
            Func<IEnumerable<RaceData>> action = () => _raceDayService.GetRaces();

            IHttpActionResult result = Execute(action);

            return result;
        }        
    }
}
