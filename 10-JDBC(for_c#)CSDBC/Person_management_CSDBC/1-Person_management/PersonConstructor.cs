namespace _1_Person_management
{
    public class PersonConstructor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public Gender PersonGender { get; set; }
        public int HouseholdID { get; set; }

        public enum Gender
        {
            male,
            female,
            Unknown
        }
        public PersonConstructor(string firstName, string lastName, string birthday, Gender gender, int householdID)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            PersonGender = gender;
            HouseholdID = householdID;
        }
    }
}