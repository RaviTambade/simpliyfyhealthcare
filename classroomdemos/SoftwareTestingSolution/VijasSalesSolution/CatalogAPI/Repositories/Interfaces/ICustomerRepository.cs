using CatalogAPI.Models.Entities;
namespace CatalogAPI.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        
        Customer Get(int id);
        bool Insert(Customer customer);
        bool Update(Customer customer);

        bool Delete(Customer customer);
    }
}
