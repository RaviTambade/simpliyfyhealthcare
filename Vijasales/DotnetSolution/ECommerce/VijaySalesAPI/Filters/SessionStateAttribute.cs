using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace VijaySalesAPI.Filters
{
    public class SessionStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            // Enable session state for Web API controller action
            HttpContext.Current.Items["AspSessionState"] = HttpContext.Current.Session;
            base.OnActionExecuting(actionContext);
        }
    }
}