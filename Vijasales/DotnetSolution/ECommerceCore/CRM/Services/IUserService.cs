using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Services
{
    public interface IUserService
    {
        Task <List<User>> GetAllAsync();
        Task <User> GetUserAsync(int Id);
        Task<bool> DeleteAsync(int Id);
        Task<bool> InsertAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<int> GetCountAsync();


    }
}
