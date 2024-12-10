using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TryModuleFilterApp.Filters
{
        public class ExecutionTimeFilter : ActionFilterAttribute
        {
            private Stopwatch _stopwatch;

            // This method is called before the action method executes
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                _stopwatch = Stopwatch.StartNew(); // Start measuring time
                base.OnActionExecuting(filterContext);
            }

            // This method is called after the action method executes
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                _stopwatch.Stop(); // Stop measuring time
                var executionTime = _stopwatch.ElapsedMilliseconds; // Get execution time in milliseconds

                // You can log the execution time, for example, in the debug console:
                Debug.WriteLine($"Action executed in {executionTime} ms");

                base.OnActionExecuted(filterContext);
            }
        }
}