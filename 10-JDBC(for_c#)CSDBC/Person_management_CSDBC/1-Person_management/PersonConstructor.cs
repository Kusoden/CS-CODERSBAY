namespace _1_Person_management
{
    public class PersonConstructor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public Gender PersonGender { get; set; }

        public enum Gender
        {
            Male,
            Female,
            Unknown
        }

        public PersonConstructor(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public PersonConstructor(string firstName, string lastName, string birthday, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            PersonGender = gender;
        }
    }
}
