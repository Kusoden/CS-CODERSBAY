using MySql.Data.MySqlClient;
using static _1_Person_management.PersonManager;

namespace _1_Person_management
{
    class Person_Management
    {
        static void Main()
        {
            MySqlConnection connection = new("server=127.0.0.1;User ID=root;Password=;Database=personmanagerdb");

            Database.CallDB();

            while (true)
            {
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Add a person");
                Console.WriteLine("2. Display all persons");
                Console.WriteLine("3. Remove a person");
                Console.WriteLine("4. Update a person");
                Console.WriteLine("5. Create a household");
                Console.WriteLine("6. Display all households");
                Console.WriteLine("7. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        try
                        {
                            PersonManager.InsertPersonWithDetails();
                            Console.WriteLine("Person created and added to the database.\n");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;
                    case "2":
                        Console.WriteLine("All persons in the database:");
                        DisplayAllPersons();
                        break;
                    case "3":
                        Console.WriteLine("Enter the first name of the person to delete:");
                        string firstNameToDelete = Console.ReadLine().Trim();
                        Console.WriteLine("Enter the last name of the person to delete:");
                        string lastNameToDelete = Console.ReadLine().Trim();

                        try
                        {
                            RemovePerson(firstNameToDelete, lastNameToDelete);
                            Console.WriteLine("Person removed from the database.");
                        }
                        catch (InvalidPersonNameException ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case "4":
                        Console.WriteLine("Enter the first name of the person to update:");
                        string firstNameToUpdate = Console.ReadLine().Trim();
                        Console.WriteLine("Enter the last name of the person to update:");
                        string lastNameToUpdate = Console.ReadLine().Trim();

                        if (PersonManager.PersonExists(firstNameToUpdate, lastNameToUpdate))
                        {
                            Console.WriteLine("Enter the new first name:");
                            string newFirstName = Console.ReadLine().Trim();
                            Console.WriteLine("Enter the new last name:");
                            string newLastName = Console.ReadLine().Trim();

                            try
                            {
                                PersonManager.UpdatePerson(firstNameToUpdate, lastNameToUpdate, newFirstName, newLastName);
                                Console.WriteLine("Person data updated.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Person not found in the database.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Enter the household name:");
                        string householdName = Console.ReadLine().Trim();
                        Household.CreateHousehold(connection, householdName);
                        Console.WriteLine("Household created.");
                        break;

                    case "6":
                        Console.WriteLine("All households in the database:");
                        List<Household> households = Household.GetAllHouseholds(connection);
                        foreach (var household in households)
                        {
                            Console.WriteLine($"ID: {household.ID}, Name: {household.HouseholdName}");
                        }
                        break;

                    case "7":
                        Console.WriteLine("Exiting the program.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

    }
}