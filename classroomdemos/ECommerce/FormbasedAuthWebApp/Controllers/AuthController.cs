using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace FormbasedAuthWebApp.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password, string returnUrl)
        {
            if (email == "ravi.tambade@transflower.in" && password == "seed")
            {
                // Create an authentication ticket and set the cookie
                FormsAuthentication.SetAuthCookie(email, false);

                // Redirect to the return URL or default
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/", System.StringComparison.OrdinalIgnoreCase))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                // Invalid login attempt
                ModelState.AddModelError("", "Invalid username or password.");
                return View();
            }
        }

        // GET: Account/Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut(); 
            return RedirectToAction("Login", "Auth");
        }
    }


}
 