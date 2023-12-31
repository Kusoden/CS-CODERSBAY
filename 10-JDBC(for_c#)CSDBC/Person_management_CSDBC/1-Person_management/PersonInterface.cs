﻿namespace _1_Person_management
{
    public interface PersonInterface
    {
        void CreatePersonsTable();
        void RemovePerson(string[] deleteData);
        void CreatePerson(PersonConstructor person);
        PersonConstructor FindPersonByName(string name);
        void GetAllPersons();
        void UpdatePerson(string[] updateData);
    }
}