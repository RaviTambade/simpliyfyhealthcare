using System.Web;

using System.Web.Http.Filters;

namespace VijaySalesSOA.Filters

{

    public class SessionStateAttribute : ActionFilterAttribute

    {

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)

        {

            // Ensure the session state is initialized for the current request

            var session = HttpContext.Current.Session;

            if (session == null)

            {

                System.Diagnostics.Debug.WriteLine("Session is null in OnActionExecuting.");

            }

            else

            {

                System.Diagnostics.Debug.WriteLine("Session is available in OnActionExecuting.");

            }

            base.OnActionExecuting(actionContext);

        }

        public override void OnActionExecuted(System.Web.Http.Filters.HttpActionExecutedContext actionExecutedContext)

        {

            // Log session after action execution (you can also use this to modify the session if needed)

            var session = HttpContext.Current.Session;

            if (session == null)

            {

                System.Diagnostics.Debug.WriteLine("Session is null in OnActionExecuted.");

            }

            else

            {

                System.Diagnostics.Debug.WriteLine("Session is available in OnActionExecuted.");

            }

            base.OnActionExecuted(actionExecutedContext);

        }

    }

}

