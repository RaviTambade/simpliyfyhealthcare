using HR.Entities;
using System.Text.Json;
using System.Xml.Serialization;

namespace TestProjectXUnitVijaySales.Utility
{
    public class XMLManager
    {
        public XMLManager() { }

        //Deserialization logic

        public List<Person> GetXmlSampleData()
        {
            string fileName = @"D:/Ravi/TAP/TAP/softwaretesting/solutions/VijasSalesSolution/TestProjectXUnitVijaySales/SampleData/people.xml";
            List<Person> people = new List<Person>();
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
                people = serializer.Deserialize(stream) as List<Person>;
            }
            return people;
        }
        
        
        //Serialization
     
        public bool SetXMLSampleData()
        {
            bool status = false;
            List<Person> list = new List<Person>();
            list.Add(new Person { Age = 26, Name = "Seema" });
            list.Add(new Person { Age = 12, Name = "Manoj" });
            list.Add(new Person { Age = 23, Name = "Jai" });

            string fileName = @"D:/Ravi/TAP/TAP/softwaretesting/solutions/VijasSalesSolution/TestProjectXUnitVijaySales/SampleData/people.xml";

            using (FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
                serializer.Serialize(stream, list);
            }
            status=true;
            return status;
        }
    }
}