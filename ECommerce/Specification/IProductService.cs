using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCO;
namespace Specification
{
    //interfaces are used to define contract
   public interface IProductService
    {

        //all methods in interface are abstract
        List<Product> GetAll();
        Product Get(int id);
        bool Insert(Product product);
        bool Update(Product product);
        bool Delete(int id);

    }
}
