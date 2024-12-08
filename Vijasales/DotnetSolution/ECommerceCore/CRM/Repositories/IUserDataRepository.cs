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
        List<User> GetAll();
        bool Insert(User user);
        bool Update(User user);
        bool Delete(int Id);

        User GetUser(int id);
    }
}
