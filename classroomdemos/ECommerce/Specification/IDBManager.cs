using ECommerceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceEntities;


namespace Specification
{
    public interface IDBManager
    {
        bool Insert(Product product);
        bool Update(Product product);
        bool Delete(int id);
        int GetCount();
        List<Product> GetAll();
        Product GetById(int id);


    }
}
