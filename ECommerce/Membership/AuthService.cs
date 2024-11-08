using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership
{
    public class AuthService : IAuthService
    {
        public bool ForgotPassword(string username)
        {
            throw new NotImplementedException();
        }

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool Register(User user)
        {
            throw new NotImplementedException();
        }

        public bool RestPassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
