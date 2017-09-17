using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Race.ApplicationService.Models;
using Race.ApplicationService.Services;

namespace Race.Host.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
