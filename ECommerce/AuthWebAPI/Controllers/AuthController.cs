using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POCO;
using Specification;
using Services;
using System.Web;
namespace AuthWebAPI.Controllers
{
    public class AuthController : ApiController
    {

        // POST api/auth
        public void Post([FromBody]  Credenail crednetial)
        {
            IAuthService svc = new AuthService();
            if (svc.Login(crednetial.Email, crednetial.Password))
            { 
                
            }
            else
            {

            }

        }


    }
}
