using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCO;
namespace Specification
{
    public interface IDataRepository
    {
        bool Serialize(string filename, List<Product> products);
        List<Product> Deserialize(string filename);

    }
}
