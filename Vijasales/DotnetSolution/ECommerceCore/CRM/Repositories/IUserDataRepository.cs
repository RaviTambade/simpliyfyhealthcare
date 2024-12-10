using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Repositories
{
    public interface IUserDataRepository
    {
       Task< List<User> >GetAllAsync();
        Task<bool> InsertAsync(User user);
       Task< bool> UpdateAsync(User user);
       Task< bool> DeleteAsync(int Id);

        Task<User> GetUserAsync(int id);
    }
}
