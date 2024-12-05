using HR.Entities;
using System.Text.Json;
using System.Xml.Serialization;

namespace TestProjectXUnitVijaySales.Utility
{
    public class JSONManager
    {
        public JSONManager() { }

        //Deserialization logic
        public List<Person> ReadJSONSampleData()
        {
            //Retrive data from sample given to testers
            //DeSerialization of data from people.json
            //Use File IO
            //Use JsonSerializer.Deserialize method
            //retrieve list of person data
            //return list of person data
            string fileName = @"D:/Ravi/TAP/TAP/softwaretesting/solutions/VijasSalesSolution/TestProjectXUnitVijaySales/SampleData/people.json";
            string jsonString = File.ReadAllText(fileName);
            List<Person> jsonPeople = JsonSerializer.Deserialize<List<Person>>(jsonString);
            return jsonPeople;
        }


        //Serialization
        public bool SetJSONSampleData() {
            bool status = false;
            List<Person> list = new List<Person>();
            list.Add(new Person { Age = 48, Name = "Ravi" });
            list.Add(new Person { Age = 22, Name = "Pragati" });
            list.Add(new Person { Age = 21, Name = "Ajinkya" });

            string fileName = @"D:/Ravi/TAP/TAP/softwaretesting/solutions/VijasSalesSolution/TestProjectXUnitVijaySales/TestingSampleData/people.json";

            var options = new JsonSerializerOptions { IncludeFields = true };
            var peopleJson = JsonSerializer.Serialize<List<Person>>(list, options);
            File.WriteAllText(fileName, peopleJson);
            status = true;
            return status;


        }
      
    }
}