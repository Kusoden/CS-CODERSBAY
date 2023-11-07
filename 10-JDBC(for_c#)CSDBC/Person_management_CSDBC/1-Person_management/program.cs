using System.Linq;
using static _1_Person_management.Database;

namespace _1_Person_management
{
    class Person_Management
    {
        static void Main()
        {
            while (true)
            {
                HouseholdInterface householdManager = new HouseholdManager();
                PersonInterface personManager = new PersonManager();
                PetInterface petManager = new PetManager();

                Console.WriteLine("\nThere should be no pets connected to that Person, to be able to delete the Person.");
                Console.WriteLine("There should be no Person connected to that Household, to be able to delete the Household.\n");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Create a household");
                Console.WriteLine("2. Display all households");
                Console.WriteLine("3. Update Household");
                Console.WriteLine("4. Delete Household");
                Console.WriteLine("5. Add a person");
                Console.WriteLine("6. Display all persons");
                Console.WriteLine("7. Update a person");
                Console.WriteLine("8. delete a person");
                Console.WriteLine("9. Create a pet");
                Console.WriteLine("10. Display all pets");
                Console.WriteLine("11. Update Pet");
                Console.WriteLine("12. Delete Pet");
                Console.WriteLine("13. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter the household name:");
                        string householdName = Console.ReadLine().Trim();
                        householdManager.CreateHousehold(householdName);
                        break;

                    case "2":
                        Console.WriteLine("All households in the database:");
                        householdManager.DisplayHouseholds();
                        break;

                    case "3":
                        Console.WriteLine("Enter the ID of the household to update:");
                        int householdIDToUpdate = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the new household name:");
                        string newHouseholdName = Console.ReadLine().Trim();

                        try
                        {
                            householdManager.UpdateHousehold(householdIDToUpdate, newHouseholdName);                            
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case "4":
                        Console.WriteLine("Enter the ID of the household to delete:");
                        int householdIDToDelete = int.Parse(Console.ReadLine());
                        try
                        {
                            householdManager.DeleteHousehold(householdIDToDelete);                            
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case "5":
                        try
                        {
                            personManager.InsertPersonWithDetails();                            
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case "6":
                        Console.WriteLine("All persons in the database:");
                        personManager.DisplayAllPersons();
                        break;

                    case "7":
                        Console.WriteLine("Enter the first name of the person to update:");
                        string firstNameToUpdate = Console.ReadLine().Trim();

                        Console.WriteLine("Enter the last name of the person to update:");
                        string lastNameToUpdate = Console.ReadLine().Trim();

                        if (personManager.PersonExists(firstNameToUpdate, lastNameToUpdate))
                        {
                            Console.WriteLine("Enter the new first name:");
                            string newFirstName = Console.ReadLine().Trim();
                            Console.WriteLine("Enter the new last name:");
                            string newLastName = Console.ReadLine().Trim();

                            try
                            {
                                personManager.UpdatePerson(firstNameToUpdate, lastNameToUpdate, newFirstName, newLastName);                                
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

                    case "8":
                        Console.WriteLine("Enter the first name of the person to delete:");
                        string firstNameToDelete = Console.ReadLine().Trim();

                        Console.WriteLine("Enter the last name of the person to delete:");
                        string lastNameToDelete = Console.ReadLine().Trim();

                        personManager.RemovePerson(firstNameToDelete, lastNameToDelete);

                        break;

                    case "9":
                        Console.WriteLine("Enter the name of the pet:");
                        string petName = Console.ReadLine().Trim();

                        Console.WriteLine("Enter the owner's ID:");
                        int ownerID = Convert.ToInt32(Console.ReadLine());

                        if (personManager.PersonExists(ownerID))
                        {
                            petManager.CreatePet(petName, ownerID);                            
                        }
                        else
                        {
                            Console.WriteLine("Owner not found in the database. Please create the owner first.");
                        }
                        break;

                    case "10":
                        Console.WriteLine("All pets in the database:");
                        petManager.DisplayPets();
                        break;

                    case "11":
                        Console.WriteLine("Enter the ID of the pet to update:");
                        int petIDToUpdate = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the new pet name:");
                        string newPetName = Console.ReadLine().Trim();

                        try
                        {
                            petManager.UpdatePet(petIDToUpdate, newPetName);
                            Console.WriteLine("Pet updated.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case "12":
                        Console.WriteLine("Enter the ID of the pet to delete:");
                        int petIDToDelete = int.Parse(Console.ReadLine());
                        try
                        {
                            petManager.DeletePet(petIDToDelete);
                            Console.WriteLine("Pet deleted.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;


                    case "13":
                        Console.WriteLine("Exiting the program.");
                        GetInstance().Close();
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

    }
}