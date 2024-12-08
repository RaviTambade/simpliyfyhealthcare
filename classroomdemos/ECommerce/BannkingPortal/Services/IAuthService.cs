using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BannkingPortal.Models;

namespace BannkingPortal.Services
{
    public interface IAuthService
    {
        bool Login(string username, string password);
        bool Register(User user);
        bool ForgotPassword(string username);
        bool RestPassword(string username, string oldPassword, string newPassword);

    }
}