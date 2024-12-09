1. ASP.NET framework is heart of ASP.NET MVC application. Basically, ASP.NET is a request processing engine. It takes incoming request as input and sends it through internal pipeline till the end point.
2. The life cycle of an ASP.NET application starts with a request sent by a browser to the Web server.
3. In integrated mode in IIS 7.0, a unified pipeline handles all requests. When the integrated pipeline receives a request, the request passes through stages that are common to all requests. These stages are represented by the RequestNotification enumeration. All requests can be configured to take advantage of ASP.NET functionality, because that functionality is encapsulated in managed-code modules that have access to the request pipeline. For example, even though the .htm file-name extension is not explicitly mapped to ASP.NET, a request for an HTML page still invokes ASP.NET modules. This enables you to take advantage of ASP.NET authentication and authorization for all resources.

4. So whenever a request comes from Client to Server, it will hit HTTP.SYS First. Hypertext Transfer Protocol Stack (HTTP.sys)  – The HTTP listener is part of the networking subsystem of Windows operating systems, and it is implemented as a kernel-mode device driver called the HTTP protocol stack (HTTP.sys). HTTP.sys listens for HTTP requests from the network, passes the requests onto IIS for processing, and then returns processed responses to client browsers.

5. HTTP.SYS is Responsible for pass the request to particular Application pool. How HTTP.SYS comes to know where to send the request ?  This is not a random pickup. Whenever we creates a new Application Pool, the ID of the Application Pool is being generated and it’s registered with the HTTP.SYS. So whenever HTTP.SYS Received the request from any web application, it checks for the Application Pool and based on the application pool it send the request.

Application Pool:  Application pool is the container of worker process.  Application pools is used to separate sets of IIS worker processes that share the same configuration.  Application pools enables a better security, reliability, and availability for any web application.  The worker process serves as the process boundary that separates each application pool so that when one worker process or application is having an issue or recycles, other applications or worker processes are not affected. This makes sure that a particular web application doesn’t not impact other web application as they they are configured into different application pools.
When Application pool receive the request, it simply pass the request to worker process (w3wp.exe) .
Worker Process: :  Worker Process (w3wp.exe) runs the ASP.Net application in IIS. This process is responsible to manage all the request and response that are coming from client system.  All the ASP.Net functionality runs under the scope of worker process.  When a request comes to the server from a client worker process is responsible to generate the request and response. Worker Process loads up ASP.Net run time. Application domain is created.
4. After the application domain has been created and the HostingEnvironment object has been instantiated, application objects such as HttpContext, HttpRequest, and HttpResponse are created and initialized. The HttpContext class contains objects that are specific to the current application request, such as the HttpRequest and HttpResponse objects. The HttpRequest object contains information about the current request, which includes cookies and browser information. The HttpResponse object contains the response that is sent to the client, which includes all the rendered output and cookies.
5. After all application objects have been initialized, the application is started by creating an instance of the HttpApplication class. If the application has a Global.asax file, ASP.NET instead creates an instance of the Global.asax class that is derived from the HttpApplication class. It then uses the derived class to represent the application. An instance of the HttpApplication object is assigned to the request. The request is processed by the HttpApplication class. Different events are raised by this class for processing the request.
6. For MVC application in Application_Start event for Global.ascx RegisterRoutes(RouteTable.Routes) API for RouteConfig is invoked.
7. Inside the RegisterRoutes we register route by giving: route name and constraints.
routes.MapRoute(
name: “Default”,
url: “{controller}/{action}/{id}”,
defaults: new { controller = “Home”, action = “Contact”, id = UrlParameter.Optional }

8. The MapRoute is actually extension method in RouteCollectionExtensions.cs. Now, you can see how the route with particular URL is being register and associated with MvcRouteHandler.

9. Post this ASP.NET starts executing the HTTP Modules registered in the pipeline. In BeginProcessRequest there is a cycle that iterates all modules and execute each of it.
10. One of the module is UrlRoutingModule. The goal of this module is basically matching incoming request by URL with pre-defined Route configuration and return corresponding handler for this request.
11. HttpApplication calls the Init method for each of the registered modules. Init method has HttpApplication as parameter, in the Init method for Url Routing Module for the event handler PostResolveRequestCache of HttpApplication object it assigns the method PostResolveRequestCache Method within the routing module. When the HttpApplication event is fire the PostResolveRequestCache method of the UrlRouting Module gets fired. In this method following steps are performed
12. Match the request to defined route
13. For found matched Route it gets corresponding route handler (MvcRouteHandler). MvcRouteHandler was configured earlier in the application start.
14. Get HttpHandler method for the MvcRouteHandler is called which returns the instance of MvcHandler
15. This in turn calls the RemapHandler method in the HttpContext instance, to this method MvcHandler is passed. Remapahandler tells IIS which Httphandler we want to use.
16. Once handler has been set, handlers process request method is been called by ASP.Net framework.
17. We know that HttpHandlers are special objects that handles requests and produce a response. MvcHandler produce nothing by itself. Instead, it uses ControllerBuilder object for creating Controller and call controller Execute method. It is Execute method responsibility to find corresponding action, call action and wrap action return result it HTTP response
18. MVC handler supports both sync and async process request methods.
Sync Process Request
• It declares IController and IControllerFactory these are initialized in the ProcessRequestInit method. IControllerFactory instance is
initialized to DefaultControllerFactory and then the IControllerFactory instance calls the CreateController API which creates the appropriate
controller instance and is assigned to IController.
• Then the IController Execute method is invoked.

Async Process Request
• In async world the things are bit more complex. There are no one single method, but 2 instead. BeginProcessRequest and EndProcessRequest.
• The request initialization and creation of factory and controller is exactly the same. The difference in execution, for async controller 2
delegates are being created.
• Then Controller BeginExecute method is invoked.

19. In summary after the controller object is created using the controller factory following happens :
a. The Execute() method of the controllerbase is called
b. This Execute() method calls the ExecuteCore() method which is declared abstract and is defined by Controller class.
c. The Controller class’s implementation of the ExecuteCore() method retrieves the action name from the RouteData
d. ExecuteCore() method calls ActionInvoker’s InvokeAction() method.

20. Controller has following method which can be overridden and called in the same sequence
1. Initialize – Override to perform custom initialization before ControllerBase.Initialize sets Controller.ControllerContext with the encapsulated route data.
2. BeginExecuteCore
3. CreateTempDataProvider – Override to use a custom TempData provider. SessionStateTempDataProvider is used by default.
4. CreateActionInvoker – Override to use a custom action invoker. AsyncControllerActionInvoker is used by default
5. Controller then Invokes the Authentication Filters. Controller.OnAuthentication() API is invoked which then invokes the individual IAuthenticationFilters, prior to invoking filters it checks if the request I already authenticated if not then it invokes IAuthentication Filters. Use IAuthenticationFilter to authenticate a user action toward the intended resources. Authentication filters execute in order until one of the filters returns a non-null result.
6. Post Authentication Filters Controller invokes the Authorization filters. Controller.On Authorization() API is invoked which then invokes the individual IAuthorizationFilters, prior to invoking filters it checks if the authorization context existis if not then it invokes IAuthorization Filters. Use IAuthorizationFilters to authorize a user action toward the intended resources. Authorization filters execute in order until one of the filters returns a non-null result.
7. Then controller calls the InvokeAction method, this is where the action filters kick in. Action filters are executed before (OnActionExecuting) and after (OnActionExecuted) an action is executed. IActionFilter interface provides you two methods OnActionExecuting and OnActionExecuted methods which will be executed before and after an action gets executed respectively. You can also make your own custom ActionFilters filter by implementing IActionFilter.
8. When action is executed, it process the user inputs with the help of model (Business Model or Data Model) and prepare Action Result.
9. Controller then Invokes the Controller.OnResultExecuting() API. Controller implements IResultFilter (by inheriting ActionFilterAttribute). OnResultExecuting methods are executed in order before the result is executed.
10. Post the the Controller.OnResultExecuting Result filters are kicked in. Result filters are executed before (OnResultExecuting) and after (OnResultExecuted) the ActionResult is executed. IResultFilter interface provides you two methods OnResultExecuting and OnResultExecuted methods which will be executed before and after an ActionResult gets executed respectively. You can also make your own custom ResultFilters filter by implementing IResultFilter
11. Controller then executes the ActionResult.ExecuteResult() which prepares the return ActionResult.
a. The Action Result type can be ViewResult, PartialViewResult, RedirectToRouteResult, RedirectResult, ContentResult, JsonResult, FileResult and EmptyResult. Various Result type provided by the ASP.NET MVC can be categorized into two category- ViewResult type and NonViewResult type.
b. The Result type which renders and returns an HTML page to the browser, falls into ViewResult category and other result type which returns only data either in text format, binary format or a JSON format, falls into NonViewResult category.
c. ViewResult type i.e. view and partial view are represented by IView(System.Web.Mvc.IView) interface and rendered by the appropriate View Engine which is this case is Razor.
d. View generation and rendering is handled by IViewEngine (System.Web.Mvc.IViewEngine) interface of the view engine.
e. By default ASP.NET MVC provides WebForm and Razor view engines. You can also create your custom engine by using IViewEngine interface and can registered your custom view engine in to your Asp.Net MVC application start.
f. Since ViewResult is the most common type of ActionResult we will look into what happens if the the ExecuteResult() method of the ViewResult is called. Following happens after the ExecuteResult() method of ViewResult is called.
i. ExecuteResult of ViewResultBase is Invoked
ii. ViewResultBase calls the FindView of the ViewResult
iii. ViewResult returns the ViewEngineResult
iv. The Render() method of the ViewEngineResult is called to Render the view using the ViewEngine.
v. The response is returned to the client.

12. To summarize Filters associated with controllers, there are 5 types of filters, they are executed in below sequence
a. AuthenticationFilter – Executes after Controller.OnAuthentication.
b. AuthorizeFilter – Executes before other filter or action method
c. ActionFilter – Executes before and after action method
d. ResultFilter – Executes before and after action result
e. ExceptionFilter – Executes when action method, action result and other filter throws exception