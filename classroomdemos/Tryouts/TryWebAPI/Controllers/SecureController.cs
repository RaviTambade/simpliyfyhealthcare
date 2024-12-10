using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TryWebAPI.Controllers
{
    [Authorize]
    public class SecureController : ApiController
    {
     
        [HttpGet]
        [Route("api/secure/data")]
        public IHttpActionResult GetSecureData()
        {
            return Ok(new { message = "This is a secure data!" });
        }
    }
}
