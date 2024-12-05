using CRM.Entities;
using CRM.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Security;

namespace CRM.Services
{
    public class AuthService : IAuthService
    {
        IDataRepository repo;
        public AuthService()
        {
            repo = new UserRepository();
        }
        //public string ForgotPassword(string email)
        //{
        //    throw new NotImplementedException();
        //}

        public User Get(int id)
        {
            List<User> users = repo.GetAll();
            User user = users.Find(x => x.Id == id);
            return user;
        }

        public bool Login(string email, string password)
        {
            List<User> users = repo.GetAll();
            foreach (var user in users)
            {
                if(user.Email == email && Encryption.CheckDecryptPassword(password, user.Password))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Register(User user)
        {
            user.Password = Encryption.EncryptPassword(user.Password);
            return repo.Insert(user);
        }

        public bool ResetPassword(string email, string oldpassword, string newpassword)
        {
            List<User> users = repo.GetAll();
            foreach (var user in users)
            {
                if (user.Email == email && Encryption.CheckDecryptPassword(oldpassword, user.Password))
                {
                    user.Password = Encryption.EncryptPassword(newpassword);
                    return true;
                }
            }
            return false;
        }

        public bool UpdateProfile(User newuser)
        {
            User user = repo.Get(newuser.Id);
            repo.Delete(user);
            repo.Inser(newuser);

        }
    }
}
