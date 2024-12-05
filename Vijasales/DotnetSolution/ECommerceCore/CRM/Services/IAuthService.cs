using CRM.Entities;
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
        bool Login(string email, string password);
        bool Register(User user);
        //string ForgotPassword(string email);
        bool ResetPassword(string email, string oldpassword, string newpassword);
        User Get(int id);
        bool UpdateProfile(User user);
    }
}
