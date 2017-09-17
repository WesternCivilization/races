using System;
using System.Net;
using System.Web.Http;

namespace Race.Host.Controllers
{
    public abstract class BaseApiController : ApiController
    {
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
                // TODO: Log the exception - Skipped for brevity
                return InternalServerError();
            }
        }
    }
}
