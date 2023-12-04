namespace _1_Person_management
{
    public interface PersonInterface
    {
        void CreatePersonsTable();
        void RemovePerson();
        void CreatePerson(string firstName, string lastName, int householdID);
        void CreatePerson(string firstName, string lastName, string birthday, PersonConstructor.Gender gender, int householdID);
        void InsertPersonWithDetails();
        PersonConstructor FindPersonByName(string name);
        void DisplayAllPersons();
        bool PersonExists(string firstName, string lastName);
        bool PersonExists(int ownerID);
        void UpdatePerson();
    }
}