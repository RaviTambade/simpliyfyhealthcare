using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using POCO;
using Specification;
namespace BinaryDataRepositoryLIb
{
    public class BinaryRepository:IDataRepository
    {
        public bool Serialize(string filename, List<Product> products)
        {
            bool status = false;
            // Code for saving
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filename, FileMode.OpenOrCreate);
            formatter.Serialize(stream, products);
            stream.Close();

            return status;
        }
        public List<Product> Deserialize(string filename)
        {
            List<Product> products =new List<Product> ();
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filename, FileMode.Open);
            if (stream != null) {

                products =(List<Product>) formatter.Deserialize(stream);
            }
            stream.Close();
            // retrive all products from file
            return products;

        }
    }
}
