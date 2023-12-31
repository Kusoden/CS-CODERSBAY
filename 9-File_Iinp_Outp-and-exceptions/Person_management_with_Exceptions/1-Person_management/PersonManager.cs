﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _1_Person_management;

public class PersonManager
{
    private readonly List<Person> personList;

    public PersonManager()
    {
        personList = new List<Person>();
    }

    public void DisplayAllPersons()
    {
        /*        if (personList == null)
                    throw new NullReferenceException("it's Empty!");
                else
                {*/
        foreach (Person person in personList)
            Console.WriteLine($"{person.Name} {person.LastName} {person.Birthday} {person.Address} {person.PersonGender}");
        /*        }*/
    }

    public void CreatePerson(string name, string lastName)
    {
        if (name.Any(char.IsDigit) || lastName.Any(char.IsDigit))
            throw new InvalidPersonNameException("Invalid name: Name should not contain numbers.");
        else
        {
            Person person = new(name, lastName);
            personList.Add(person);
        }
    }

    public void CreatePerson(string name, string lastName, string birthday, Address address, Person.Gender gender)
    {
        if (name.Any(char.IsDigit) || lastName.Any(char.IsDigit))
            throw new InvalidPersonNameException("Invalid name: Name should not contain numbers.");
        else
        {
            Person person = new(name, lastName, birthday, address, gender);
            personList.Add(person);
        }
    }

    public void CreatePerson(string name, string lastName, Person.Gender gender, string birthday)
    {
        if (name.Any(char.IsDigit) || lastName.Any(char.IsDigit))
            throw new InvalidPersonNameException("Invalid name: Name should not contain numbers.");
        else
        {
            Person person = new(name, lastName, gender, birthday);
            personList.Add(person);
        }
    }




    public void RemovePerson(string name)
    {
        if (name.Any(char.IsDigit))
            throw new InvalidPersonNameException("Invalid name: Name should not contain numbers.");
        else
        {
            for (int personIndex = personList.Count - 1; personIndex >= 0; personIndex--)
            {
                Person p = personList[personIndex];
                if (p.Name.Equals(name))
                    personList.RemoveAt(personIndex);
            }
        }
    }

    public class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException(string message) : base(message) { }
    }

    public Person FindPersonByName(string name)
    {
        foreach (Person person in personList)
            if (person.Name.Equals(name))
                return person;
        throw new NullReferenceException("Person not found: " + name);
    }

}