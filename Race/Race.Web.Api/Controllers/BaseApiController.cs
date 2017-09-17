using System;
using System.Net;
using System.Web.Http;
using Race.Common.Service;

namespace Race.Host.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        private readonly ILogger _logger;

        protected BaseApiController(ILogger logger)
        {
            _logger = logger;
        }

        protected IHttpActionResult Execute<R>(Func<R> action) where R : class
        {
            try
            {
                R response = action();

                if (response == null) return NotFound();

                return Content(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                _logger.LogException(Severity.Error, ex.Message, ex);
                return InternalServerError();
            }
        }
    }
}
