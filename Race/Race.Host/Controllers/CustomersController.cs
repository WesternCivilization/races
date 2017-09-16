using Race.Host.Models;
using Race.Host.Services;
using System;
using System.Web.Http;

namespace Race.Host.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomersController : BaseApiController
    {
        private readonly IRaceDayService _raceDayService;

        public CustomersController(IRaceDayService raceDayService)
        {
            _raceDayService = raceDayService;
        }

        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            Func<CustomersData> action = () => _raceDayService.GetCustomers();

            IHttpActionResult result = Execute(action);

            return result;
        }
    }
}
