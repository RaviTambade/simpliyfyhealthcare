using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
namespace TryModuleFilterApp.Modules
{
    public class LoggingModule : IHttpModule
    {
        // Initialize the module and hook into events of the HttpApplication pipeline.
        public void Init(HttpApplication context)
        {
            // Subscribe to the BeginRequest event
            context.BeginRequest += new EventHandler(this.OnBeginRequest);
            context.EndRequest += new EventHandler(this.OnEndRequest);
        }

        // The event handler that gets triggered at the BeginRequest event
        private void OnBeginRequest(object sender, EventArgs e)
        {
            // Get the current HTTP context
            HttpContext context = HttpContext.Current;

            // Log the incoming request details (URL and method)
            string message = $"Request Started: {context.Request.HttpMethod} {context.Request.Url}";
            System.Diagnostics.Debug.WriteLine(message);

            // Optionally, you could log this information to a file or database
        }

        private void OnEndRequest(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            string message = $"Request Ended: {context.Response.StatusCode}";
            System.Diagnostics.Debug.WriteLine(message);
        }

        // Clean up any resources when the module is no longer needed
        public void Dispose()
        {
            // Cleanup code (if necessary)
        }
    }
}

/*
 


How to create a custom HTTP module in an ASP.NET Framework application:

1.Create a class that implements IHttpModule.
2.Implement the Init and Dispose methods to hook into the HTTP pipeline and clean up resources.
3.Register the module in the web.config file to ensure that 
    it is invoked during the HTTP request-response lifecycle.
4.Subscribe to events in the HTTP pipeline (e.g., BeginRequest, EndRequest, AuthenticateRequest, etc.)
to perform your custom logic.

 */