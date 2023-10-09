using _1_Person_management;
using System;
using System.Xml.Linq;
using Xunit;
using static _1_Person_management.PersonManager;

namespace YourNamespace.Tests
{
    public class PersonManagerTests
    {
/*        [Fact]
        public void DisplayAllPersons_Test()
        {

            var personManager = new PersonManager();
            personManager.CreatePerson("John", "Doe");

            personManager.RemovePerson("John");
            Exception ex = Assert.Throws<NullReferenceException>(() => personManager.DisplayAllPersons());
            Assert.Equal("it's Empty!", ex.Message);
        }*/

        [Fact]
        public void CreatePerson_Test()
        {
            
            var personManager = new PersonManager();

            Exception ex = Assert.Throws<InvalidPersonNameException>(() => personManager.CreatePerson("John1", "Doe"));
            Assert.Equal("Invalid name: Name should not contain numbers.", ex.Message);
        }

        [Fact]
        public void RemovePerson_Test()
        {
            var personManager = new PersonManager();
            personManager.CreatePerson("John", "Doe");

            Exception ex = Assert.Throws<InvalidPersonNameException>(() => personManager.RemovePerson("J0hn"));
            Assert.Equal("Invalid name: Name should not contain numbers.", ex.Message);

        }

        [Fact]
        public void FindPersonByName_Test()
        {
            var personManager = new PersonManager();

            Exception ex = Assert.Throws<NullReferenceException>(() => personManager.FindPersonByName("AAAA"));
            Assert.Equal("Person not found: "+ "AAAA", ex.Message);
        }
    }
}
