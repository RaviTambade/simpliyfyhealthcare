using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCatalog.Entities;
using TestProjectXUnitVijaySales.Utility;
using HR.Entities;
using HR.Respositories;

namespace VijaySales.Tests.BusinessObjectTests
{
    public class HRTests
    {

        [Fact]
        public static void GetPeopleTestXML()
        {
            //Arrange
            XMLManager xmlAgent = new XMLManager();
            List<Person> expectedPeople = xmlAgent.GetXmlSampleData();

            //Act
            List<Person> actualPeople = HRManager.GetAllPeople();

            //Assert
            Assert.Equal(expectedPeople, actualPeople);
        }


        [Fact]
        public static void GetPeopleTestJSON()
        {
            //Arrange
            JSONManager dataAgent = new JSONManager();
            List<Person> expectedPeople = dataAgent.ReadJSONSampleData();

            //Act
            List<Person> actualPeople = HRManager.GetAllPeople();

            //Assert
            Assert.Equal(expectedPeople, actualPeople);
        }


        [Fact]
        public static void GetPeopleTestCSV()
        {
            //Arrange
            List<Person> expectedPeople = CSVManager.GetSampleDataFromCSV();

            //Act
            List<Person> actualPeople = HRManager.GetAllPeople();

            //Assert
            Assert.Equal(expectedPeople, actualPeople);
        }
    }
}