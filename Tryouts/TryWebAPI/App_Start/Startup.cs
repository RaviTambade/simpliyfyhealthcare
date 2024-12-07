using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security;
using System.IdentityModel.Tokens.Jwt;
using System.IdentityModel.Tokens;
using System.Text;
using System.Configuration;
using Microsoft.Owin.Cors;
using System.Reflection;
using System.Web.Http;

[assembly: OwinStartup(typeof(TryWebAPI.Startup))]
namespace TryWebAPI
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            try
            {
                // Enable CORS if needed (for cross-domain requests)
                app.UseCors(CorsOptions.AllowAll);

                var issuer = ConfigurationManager.AppSettings["JwtIssuer"];
                var audience = ConfigurationManager.AppSettings["JwtAudience"];
                var key = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["JwtSecret"]);

                // Configure JWT Bearer token authentication
                app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key)
                    }
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in OWIN startup: " + ex.Message);
                throw;
            }

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config); // Register routes, filters, etc.
            app.UseWebApi(config); // Attach Web API to OWIN pipeline
          

        }
    }
}

/*
Nugget packages for  WEB API  OWIN middleware setup


Microsoft.Owin.Host.SystemWeb
Microsoft.Owin
Microsoft.Owin.Cors
Microsoft.Owin.WebApi
Microsoft.Owin.Host.SystemWeb
Microsoft.Owin.Security.Jwt
Microsoft.Owin.Hosting



 */