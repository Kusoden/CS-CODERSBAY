using System;

namespace PersonManager
{
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public Address Address { get; set; }
        public Gender PersonGender { get; set; }

        public enum Gender
        {
            Male,
            Female
        }

        public Person(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }

        public Person(string name, string lastName, string birthday, Address address, Gender gender)
        {
            Name = name;
            LastName = lastName;
            Birthday = birthday;
            Address = address;
            PersonGender = gender;
        }

        public Person(string name, string lastName, Gender gender, string birthday)
        {
            Name = name;
            LastName = lastName;
            Birthday = birthday;
            PersonGender = gender;
        }


    }

}
