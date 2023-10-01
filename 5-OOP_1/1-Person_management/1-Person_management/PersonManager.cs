using System;
using System.Collections.Generic;

namespace PersonManager
{
    public class PersonManager
    {
        private List<Person> personList;

        public PersonManager()
        {
            personList = new List<Person>();
        }

        public void AddPerson(Person person)
        {
            personList.Add(person);
        }

        public void DisplayAllPersons()
        {
            foreach (Person person in personList)
            {
                Console.WriteLine($"{person.Name} {person.LastName} {person.Birthday} {person.Address} {person.PersonGender}");
            }
        }

        public void CreatePerson(string name, string lastName)
        {
            Person person = new Person(name, lastName);
            personList.Add(person);
        }

        public void CreatePerson(string name, string lastName, string birthday, Address address, Person.Gender gender)
        {
            Person person = new Person(name, lastName, birthday, address, gender);
            personList.Add(person);
        }

        public void CreatePerson(string name, string lastName, Person.Gender gender, string birthday)
        {
            Person person = new Person(name, lastName, gender, birthday);
            personList.Add(person);
        }

        public void RemovePerson(string name)
        {
            for (int i = personList.Count - 1; i >= 0; i--)
            {
                Person p = personList[i];
                if (p.Name.Equals(name))
                    personList.RemoveAt(i);
            }
        }
    }
}
