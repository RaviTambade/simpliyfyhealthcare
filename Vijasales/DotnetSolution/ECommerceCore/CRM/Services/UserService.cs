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
        private readonly IDataRepository _repoSvc;
        public UserService()
        {
            _repoSvc = new UserRepository();
        }
        public bool Delete(int Id)
        {
            return _repoSvc.Delete(Id);
        }

        public List<User> GetAll()
        {
            return _repoSvc.GetAll();
        }

        public int GetCount()
        {
            return _repoSvc.GetAll().Count;
        }

        public User GetUser(int Id)
        {
            return _repoSvc.GetUser(Id);
        }

        public bool Insert(User user)
        {
            return _repoSvc.Insert(user);
        }

        public bool Update(User user)
        {
            return _repoSvc.Update(user);
        }
    }
}
