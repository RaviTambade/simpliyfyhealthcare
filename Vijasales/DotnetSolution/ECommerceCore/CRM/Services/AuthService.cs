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
        private readonly IUserDataRepository repo;
        public AuthService()
        {
            repo = new UserRepository();
        }

        public async Task < bool> LoginAsync(string email, string password)
        {
            List<User> users = await repo.GetAllAsync();
            foreach (var user in users)
            {
                if (user.Email == email && PasswordEncryptionManager.Verify(password, user.Password))
                {
                    return true;
                }
            }
            return false;
        }

        public async Task< bool> LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterAsync(User user)
        {
            ;
            return await repo.InsertAsync(user);
        }

        public async Task<bool> ResetPasswordAsync(string email, string oldpassword, string newpassword)
        {
            List<User> users = await repo.GetAllAsync();
            foreach (var user in users)
            {
                if (user.Email == email && PasswordEncryptionManager.Verify(oldpassword, user.Password))
                {
                    user.Password = newpassword;
                    await repo.UpdateAsync(user);
                    return true;
                }
            }
            return false;
        }


    }
}
