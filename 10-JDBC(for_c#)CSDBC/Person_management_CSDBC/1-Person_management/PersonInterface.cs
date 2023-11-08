namespace _1_Person_management
{
    public interface PersonInterface
    {
        void CreatePersonsTable();
        void RemovePerson(string firstNameToDelete, string lastNameToDelete);
        void CreatePerson(string firstName, string lastName, int householdID);
        void CreatePerson(string firstName, string lastName, string birthday, Person.Gender gender, int householdID);
        void InsertPersonWithDetails();
        Person FindPersonByName(string name);
        void DisplayAllPersons();
        bool PersonExists(string firstName, string lastName);
        bool PersonExists(int ownerID);
        void UpdatePerson(string currentFirstName, string currentLastName, string newFirstName, string newLastName);
    }
}