﻿using System;
using System.Collections.Generic;

namespace _1_Person_management
{
    public class PersonManager
    {
        private readonly List<Person> personList;

        public PersonManager()
        {
            personList = new List<Person>();
        }

        public void DisplayAllPersons()
        {
            foreach (Person person in personList)
                Console.WriteLine($"{person.Name} {person.LastName} {person.Birthday} {person.Address} {person.PersonGender}");
        }

        public void CreatePerson(string name, string lastName)
        {
            Person person = new(name, lastName);
            personList.Add(person);
        }

        public void CreatePerson(string name, string lastName, string birthday, Address address, Person.Gender gender)
        {
            Person person = new(name, lastName, birthday, address, gender);
            personList.Add(person);
        }

        public void CreatePerson(string name, string lastName, Person.Gender gender, string birthday)
        {
            Person person = new(name, lastName, gender, birthday);
            personList.Add(person);
        }

        public void RemovePerson(string name)
        {
            for (int personIndex = personList.Count - 1; personIndex >= 0; personIndex--)
            {
                Person p = personList[personIndex];
                if (p.Name.Equals(name))
                    personList.RemoveAt(personIndex);
            }
        }
    }
}
