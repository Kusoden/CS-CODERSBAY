namespace _1_Person_management
{
    class Person_Management
    {
        static void Main()
        {
            HouseholdInterface householdManager = new HouseholdManager();
            PersonInterface personManager = new PersonManager();
            PetInterface petManager = new PetManager();
            Menu menu = new Menu();

            householdManager.CreateHouseholdsTable();
            personManager.CreatePersonsTable();
            petManager.CreatePetsTable();

            while (true)
            {

                int choice = menu.MainMenu();

                switch (choice)
                {
                    case 1:                        
                        householdManager.CreateHousehold(menu.GetHouseHoldName());
                        break;
                    case 2:
                        menu.AllHouseholds();
                        householdManager.GetAllHouseHolds();
                        break;
                    case 3:
                        householdManager.UpdateHousehold();
                        break;
                    case 4:
                        householdManager.DeleteHousehold();
                        break;
                    case 5:
                        try
                        {
                            personManager.InsertPersonWithDetails();                            
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case 6:
                        Console.WriteLine("All persons in the database:");
                        personManager.DisplayAllPersons();
                        break;

                    case 7:
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

                    case 8:
                        Console.WriteLine("Enter the first name of the person to delete:");
                        string firstNameToDelete = Console.ReadLine().Trim();

                        Console.WriteLine("Enter the last name of the person to delete:");
                        string lastNameToDelete = Console.ReadLine().Trim();

                        personManager.RemovePerson(firstNameToDelete, lastNameToDelete);

                        break;

                    case 9:
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

                    case 10:
                        Console.WriteLine("All pets in the database:");
                        petManager.DisplayPets();
                        break;

                    case 11:
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

                    case 12:
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


                    case 13:
                        Console.WriteLine("Exiting the program.");
                        Database.GetInstance().Close();
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

    }
}