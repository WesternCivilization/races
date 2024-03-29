﻿using System;
using System.Web.Http;
using System.Web.Http.Cors;
using Race.ApplicationService.Models;
using Race.ApplicationService.Services;
using Race.Common.Service;

namespace Race.Host.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/customers")]
    public class CustomersController : BaseApiController
    {
        private readonly IRaceDayService _raceDayService;

        public CustomersController(
            IRaceDayService raceDayService,
            ILogger logger) : base(logger)
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
