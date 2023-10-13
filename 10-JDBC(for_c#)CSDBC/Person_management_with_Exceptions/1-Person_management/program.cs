using MySql.Data.MySqlClient;
using static _1_Person_management.PersonManager;

namespace _1_Person_management
{
    class Person_Management
    {
        private static string? firstName;
        private static string? lastName;

        static void Main()
        {
            Database.CallDB();

            PersonManager personManager = new();

            while (true)
            {
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Add a person");
                Console.WriteLine("2. Display all persons");
                Console.WriteLine("3. Remove a person");
                Console.WriteLine("4. Update a person");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PersonManager.InsertPersonWithDetails();
                        break;
                        try
                        {
                            InsertPersonIntoDatabase(firstName, lastName);
                            Console.WriteLine("Person created and added to the database.");
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



        /*        static void Main()
        {
            string connectionString = "server=127.0.0.1;User ID=root;Password=;Database=personmanagerdb";

            using (MySqlConnection connection = new(connectionString))
            {
                connection.Open();

                // Insert a person into the Persons table
                InsertPerson(connection, "John", "Doe");

                Console.WriteLine("Person inserted successfully.");

                connection.Close();
            }
        }*/