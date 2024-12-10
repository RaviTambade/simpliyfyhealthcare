using CRM.Entities;
using CRM.Repositories.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VijaySales.Security;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace CRM.Repositories.ORM
{
    public class UserRepository : IUserDataRepository
    {
        public async Task < bool> DeleteAsync(int Id)
        {
            bool status = false;
            using(var ctx = new CollectionContext())
            {
                ctx.Users.Remove(ctx.Users.Find(Id));
                ctx.SaveChangesAsync();
                status = true;
            }
            return status;
        }

        public async Task < List<User>> GetAllAsync()
        {
            using(var ctx = new CollectionContext()){
                var users = ctx.Users.ToList();
                return users;
            }
        }

        public async Task<User> GetUserAsync(int id)
        {
           using(var ctx = new CollectionContext())
            {
                var user = ctx.Users.Find(id);
                return user;
            }
        }

        public  async Task<bool> InsertAsync(User user)
        {   
            bool status = false;
            using(var ctx =  new CollectionContext())
            {
                user.Password = PasswordEncryptionManager.Encrypt(user.Password);
 
                ctx.Users.Add(user);
                await ctx.SaveChangesAsync();
                status = true;
            }
            return status;
        }


        public async Task <bool> UpdateAsync(User user)
        {
            bool status = false;
            using(var ctx = new CollectionContext())
            {

                //hashing password before adding to database
                user.Password = PasswordEncryptionManager.Encrypt(user.Password);
                ctx.Users.Remove(ctx.Users.Find(user.Id));
                ctx.Users.Add(user);
               await ctx.SaveChangesAsync();
                status = true;
;            }
            return status;
        }
    }
}
