using ShoppingCart.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VijaySalesSOA.Filters;

namespace VijaySalesSOA
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
           // GlobalConfiguration.Configuration.Filters.Add(new Filters.SessionStateAttribute());

        }

        protected  void Session_Start()
        {
            //this.Request.RequestContext.HttpContext.Session.Add("cart", new Cart());
            Cart theCart = new Cart();
            
            this.Session.Add("cart", theCart);
        }
    }
}
