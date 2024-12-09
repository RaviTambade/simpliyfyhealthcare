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
 

Writing a custom HTTP module in an ASP.NET Framework application allows you to hook into the HTTP request/response pipeline and perform custom logic during various stages of processing. For example, you might want to log requests, modify headers, or handle errors globally.

Here's how you can create a custom HTTP module for your ASP.NET web application:

Steps to Create a Custom HTTP Module
1. Create a Custom HTTP Module Class
The first step is to create a class that implements the IHttpModule interface. This interface requires you to implement two methods:

Init(HttpApplication context): This method is called when the HTTP module is initialized. It's where you hook into the request lifecycle and subscribe to events.
Dispose(): This method is called when the module is no longer needed. Use it to clean up any resources.
Example: Custom HTTP Module to Log Request Details
csharp
Copy code
using System;
using System.Web;

namespace MyCustomModules
{
    public class LoggingModule : IHttpModule
    {
        // Initialize the module and hook into events of the HttpApplication pipeline.
        public void Init(HttpApplication context)
        {
            // Subscribe to the BeginRequest event
            context.BeginRequest += new EventHandler(this.OnBeginRequest);
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

        // Clean up any resources when the module is no longer needed
        public void Dispose()
        {
            // Cleanup code (if necessary)
        }
    }
}
2. Register the Custom HTTP Module in web.config
Once you’ve created the custom HTTP module, you need to register it in the web.config file. You do this by adding an entry under the <system.webServer> section (for IIS 7 and later) or the <system.web> section (for earlier versions).

Example: Registering the HTTP Module in web.config
xml
Copy code
<configuration>
  <system.webServer>
    <modules>
      <!-- Register the custom LoggingModule -->
      <add name="LoggingModule" type="MyCustomModules.LoggingModule, MyAssembly" />
    </modules>
  </system.webServer>

  <!-- For earlier versions of ASP.NET, use the <system.web> section -->
  <system.web>
    <httpModules>
      <add name="LoggingModule" type="MyCustomModules.LoggingModule, MyAssembly" />
    </httpModules>
  </system.web>
</configuration>
name: The name of the module (it can be any unique name).
type: The fully qualified name of the module class, including the namespace and assembly.
For example, if your LoggingModule class is in an assembly called MyAssembly, the type would be MyCustomModules.LoggingModule, MyAssembly.

3. Handle More Events (Optional)
In addition to BeginRequest, you can hook into other events in the HTTP pipeline depending on the logic you want to implement. For example:

EndRequest: Triggered after the request handler executes, useful for logging the response or cleaning up resources.
AuthenticateRequest: Used for custom authentication logic.
AuthorizeRequest: Used for custom authorization logic.
PostRequestHandlerExecute: Triggered just after the handler executes (e.g., page or controller), before the response is sent.
Example: Handling EndRequest in the HTTP Module
csharp
Copy code
public void Init(HttpApplication context)
{
    context.BeginRequest += new EventHandler(this.OnBeginRequest);
    context.EndRequest += new EventHandler(this.OnEndRequest);
}

private void OnEndRequest(object sender, EventArgs e)
{
    HttpContext context = HttpContext.Current;
    string message = $"Request Ended: {context.Response.StatusCode}";
    System.Diagnostics.Debug.WriteLine(message);
}
In this example, the module logs a message when the request ends, showing the response status code.

4. Clean Up Resources in the Dispose Method
While the Dispose() method is optional in many cases, it is important to clean up any resources that your HTTP module might have allocated (e.g., database connections, file handles).

csharp
Copy code
public void Dispose()
{
    // Cleanup code (e.g., releasing resources or unsubscribing from events)
}
For example, if your module opened database connections or files, you'd close them here.

Complete Example: Logging HTTP Request and Response
Here’s a more complete example of a custom logging module that logs both the request and the response:

csharp
Copy code
using System;
using System.Web;

namespace MyCustomModules
{
    public class LoggingModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            // Subscribe to BeginRequest and EndRequest events
            context.BeginRequest += new EventHandler(this.OnBeginRequest);
            context.EndRequest += new EventHandler(this.OnEndRequest);
        }

        private void OnBeginRequest(object sender, EventArgs e)
        {
            // Log incoming request details
            HttpContext context = HttpContext.Current;
            string message = $"Request Started: {context.Request.HttpMethod} {context.Request.Url}";
            System.Diagnostics.Debug.WriteLine(message);
        }

        private void OnEndRequest(object sender, EventArgs e)
        {
            // Log outgoing response details
            HttpContext context = HttpContext.Current;
            string message = $"Response Sent: {context.Response.StatusCode} {context.Request.Url}";
            System.Diagnostics.Debug.WriteLine(message);
        }

        public void Dispose()
        {
            // Cleanup code if necessary
        }
    }
}
This example logs both the start of a request (BeginRequest) and 
the end of a request (EndRequest), 
capturing important information like the request URL and response status code.

How to create a custom HTTP module in an ASP.NET Framework application:

1.Create a class that implements IHttpModule.
2.Implement the Init and Dispose methods to hook into the HTTP pipeline and clean up resources.
3.Register the module in the web.config file to ensure that 
    it is invoked during the HTTP request-response lifecycle.
4.Subscribe to events in the HTTP pipeline (e.g., BeginRequest, EndRequest, AuthenticateRequest, etc.)
to perform your custom logic.


 */