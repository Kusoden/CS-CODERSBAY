namespace _1_Person_management
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string? Address { get; set; }
        public Gender PersonGender { get; set; }

        public enum Gender
        {
            Male,
            Female,
            Unknown
        }

        public Person(string firstName, string lastName) : this(firstName, lastName, "N/A", Gender.Unknown)
        { }

        public Person(string firstName, string lastName, string birthday, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            PersonGender = gender;
        }

        public Person(string firstName, string lastName, Gender gender, string birthday) : this(firstName, lastName, birthday, gender)
        { }
    }


}
