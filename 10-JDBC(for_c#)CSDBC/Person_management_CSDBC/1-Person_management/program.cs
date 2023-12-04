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
                        householdManager.GetAllHouseHolds();
                        break;
                    case 3:
                        householdManager.UpdateHousehold();
                        break;
                    case 4:
                        householdManager.DeleteHousehold();
                        break;
                    case 5:
                        personManager.InsertPersonWithDetails();
                        break;
                    case 6:
                        personManager.DisplayAllPersons();
                        break;
                    case 7:
                        personManager.UpdatePerson();
                        break;
                    case 8:
                        personManager.RemovePerson();
                        break;
                    case 9:
                        petManager.CreatePet();
                        break;
                    case 10:
                        petManager.DisplayPets();
                        break;
                    case 11:
                        petManager.UpdatePet();
                        break;
                    case 12:
                        petManager.DeletePet();
                        break;
                    case 13:
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