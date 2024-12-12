using CRM.Entities;
using CRM.Repositories;
using CRM.Repositories.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDataRepository _repoSvc;
        public UserService(IUserDataRepository repoSvc)
        {
            _repoSvc = repoSvc;
        }
        public async Task <bool> DeleteAsync(int Id)
        {
            return await _repoSvc.DeleteAsync(Id);
        }

        public async Task <List<User>> GetAllAsync()
        {
            return await _repoSvc.GetAllAsync();
        }

        public async Task  <int> GetCountAsync()
        {    
            var users=await _repoSvc.GetAllAsync();
            return  users.Count();
        }

        public async Task <User> GetUserAsync(int Id)
        {
            return await _repoSvc.GetUserAsync(Id);
        }

        public async Task <bool> InsertAsync (User user)
        {
            return await  _repoSvc.InsertAsync(user);
        }

        public async Task <bool> UpdateAsync(User user)
        {
            return await _repoSvc.UpdateAsync(user);
        }
    }
}
