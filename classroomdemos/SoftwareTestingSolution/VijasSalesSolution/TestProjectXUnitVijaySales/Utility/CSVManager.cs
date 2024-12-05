using HR.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectXUnitVijaySales.Utility
{
    public class CSVManager
    {
        public static void WriteToCSV()
        {
            // Example data to write
            string[] lines = { "John,Doe,25", "Jane,Smith,30", "Bob,Johnson,40" };

            // Write data to the file
            string fileName = @"D:/Ravi/TAP/TAP/softwaretesting/solutions/VijasSalesSolution/TestProjectXUnitVijaySales/SampleData/people.json";

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (string line in lines)
                {
                    writer.WriteLine(line);
                }
            }
            Console.WriteLine("Data has been written to CSV.");
        }
        public static List<Person> GetSampleDataFromCSV()
        {
            // Read data from the file
            string fileName = @"D:/Ravi/TAP/TAP/softwaretesting/solutions/VijasSalesSolution/TestProjectXUnitVijaySales/SampleData/people.csv";

            List<Person> people = new List<Person>();

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Split the line by comma to get individual values
                    string[] parts = line.Split(',');

                    string firstName = parts[0];
                    string lastName = parts[1];
                    int age = int.Parse(parts[2]);
                    Person prn=new Person {  Name=firstName, Age=age };
                    people.Add(prn);
                }
            }
            return people;
        }
    }
}