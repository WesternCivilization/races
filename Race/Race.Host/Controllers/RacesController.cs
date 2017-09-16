using Race.Host.Models;
using Race.Host.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Race.Host.Controllers
{
    [RoutePrefix("api/races")]
    public class RacesController : ApiController
    {
        private readonly IRaceDayService _raceDayService;

        public RacesController(IRaceDayService raceDayService)
        {
            _raceDayService = raceDayService;
        }

        [HttpGet]
        public IEnumerable<RaceData> GetRaces()
        {
            return null;
        }
    }
}
