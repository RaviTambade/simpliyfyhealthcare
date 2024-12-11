using CRM.Entities;
using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Services
{
    public interface IAuthService
    {
        Task <bool> LoginAsync(string email, string password);
        Task<bool> RegisterAsync(User user);
        //string ForgotPassword(string email);
        Task<bool> ResetPasswordAsync(string email, string oldpassword, string newpassword);
        Task<bool> LogoutAsync();
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);



    }
}
