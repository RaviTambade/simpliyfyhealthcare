using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ECommerceEntities;
using Specification;
namespace BinaryDataRepositoryLIb
{
    public class BinaryRepository<T>: IDataRepository<T>
    {
        public bool Serialize(string filename, List<T> products)
        {
            bool status = false;
            // Code for saving
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filename, FileMode.OpenOrCreate);
            formatter.Serialize(stream, products);
            stream.Close();

            return status;
        }
        public List<T> Deserialize(string filename)
        {
            List<T> products =new List<T> ();
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filename, FileMode.Open);
            if (stream != null) {

                products =(List<T>) formatter.Deserialize(stream);
            }
            stream.Close();
            // retrive all products from file
            return products;

        }
    }
}
