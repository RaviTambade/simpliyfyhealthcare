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
        List<User> GetAll();
        User GetUser(int Id);
        bool Delete(int Id);
        bool Insert(User user);
        bool Update(User user);
        int GetCount();


    }
}
