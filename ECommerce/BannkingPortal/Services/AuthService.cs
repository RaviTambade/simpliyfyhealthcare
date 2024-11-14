using BannkingPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BannkingPortal.Services
{
    public class AuthService : IAuthService
    {
        public bool ForgotPassword(string username)
        {
            return false;
        }

        public bool Login(string username, string password)
        {
            bool status = false;
            //fetch all banking credentials
            //verify email and password from collection.
            //set true if avaialble

            
            return status;

        }

        public bool Register(User user)
        {
            throw new NotImplementedException();
        }

        public bool RestPassword(string username, string oldPassword, string newPassword)
        {

            bool status=false;
            return status;
           
        }
    }
}