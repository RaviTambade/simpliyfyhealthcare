using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Specification;
using ECommerceEntities;

namespace ECommerceServices

{
    public partial class AuthService : IAuthService
    {
       

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
