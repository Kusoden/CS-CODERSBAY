using System;

namespace _1_Person_management
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
            Female,
            Unknown
        }

        public Person(string name, string lastName) : this(name, lastName, "N/A", null, Gender.Unknown)/*recommendation by Coach Alex, this way it will be automatically updated after the source gets updated.*/
        { }

        public Person(string name, string lastName, string birthday, Address address, Gender gender)
        {
            Name = name;
            LastName = lastName;
            Birthday = birthday;
            Address = address;
            PersonGender = gender;
        }

        public Person(string name, string lastName, Gender gender, string birthday) : this(name,lastName, birthday, null, gender) 
        { }
    }

}
