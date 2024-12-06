using CRM.Entities;
using CRM.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VijaySales.Security;
using CRM.Repositories.ORM;

namespace CRM.Services
{
    public class AuthService : IAuthService
    {
        private readonly IDataRepository repo;
        public AuthService()
        {
            repo = new UserRepository();
        }

        public bool Login(string email, string password)
        {
            List<User> users = repo.GetAll();
            foreach (var user in users)
            {
                if (user.Email == email && PasswordEncryptionManager.Verify(password, user.Password))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Logout()
        {
            throw new NotImplementedException();
        }

        public bool Register(User user)
        {
            ;
            return repo.Insert(user);
        }

        public bool ResetPassword(string email, string oldpassword, string newpassword)
        {
            List<User> users = repo.GetAll();
            foreach (var user in users)
            {
                if (user.Email == email && PasswordEncryptionManager.Verify(oldpassword, user.Password))
                {
                    user.Password = newpassword;
                    repo.Update(user);
                    return true;
                }
            }
            return false;
        }


    }
}
