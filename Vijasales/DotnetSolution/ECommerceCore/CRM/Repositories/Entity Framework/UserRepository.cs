using CRM.Entities;
using CRM.Repositories.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VijaySales.Security;

namespace CRM.Repositories.ORM
{
    public class UserRepository : IUserDataRepository
    {
        public bool Delete(int Id)
        {
            bool status = false;
            using(var ctx = new CollectionContext())
            {
                ctx.Users.Remove(ctx.Users.Find(Id));
                ctx.SaveChanges();
                status = true;
            }
            return status;
        }

        public List<User> GetAll()
        {
            using(var ctx = new CollectionContext()){
                var users = ctx.Users.ToList();
                return users;
            }
        }

        public User GetUser(int id)
        {
           using(var ctx = new CollectionContext())
            {
                var user = ctx.Users.Find(id);
                return user;
            }
        }

        public bool Insert(User user)
        {   
            bool status = false;
            using(var ctx =  new CollectionContext())
            {
                user.Password = PasswordEncryptionManager.Encrypt(user.Password);
 
                ctx.Users.Add(user);
                ctx.SaveChanges();
                status = true;
            }
            return status;
        }


        public bool Update(User user)
        {
            bool status = false;
            using(var ctx = new CollectionContext())
            {

                //hashing password before adding to database
                user.Password = PasswordEncryptionManager.Encrypt(user.Password);
                ctx.Users.Remove(ctx.Users.Find(user.Id));
                ctx.Users.Add(user);
                ctx.SaveChanges();
                status = true;
;            }
            return status;
        }
    }
}
