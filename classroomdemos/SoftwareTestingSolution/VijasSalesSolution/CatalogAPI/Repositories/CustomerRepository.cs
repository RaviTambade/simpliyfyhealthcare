using CatalogAPI.Models.Entities;
using CatalogAPI.Repositories.Interfaces;

namespace CatalogAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool Delete(Customer customer)
        {

            //
            return false;
        }

        public Customer Get(int id)
        {

           return   new Customer(); 
        }

        public IEnumerable<Customer> GetAll()
        {
            List<Customer> list = new List<Customer>();
            return list;
        }

        public bool Insert(Customer customer)
        {
            return false;
            
        }

        public bool Update(Customer customer)
        {
            return false;
        }
    }
}
