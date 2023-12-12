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

            #region Create tables from instances
            householdManager.CreateHouseholdsTable();
            personManager.CreatePersonsTable();
            petManager.CreatePetsTable();
            #endregion

            while (true)
            {

                int choice = menu.MainMenu();

                switch (choice)
                {
                    case 1:
                        householdManager.CreateHousehold(menu.HouseholdNameHandler());
                        break;
                    case 2:
                        householdManager.GetAllHouseHolds();
                        break;
                    case 3:
                        householdManager.UpdateHousehold(menu.UpdateHouseHoldHandler());
                        break;
                    case 4:
                        householdManager.DeleteHousehold(menu.DeleteHouseHoldHandler());
                        break;
                    case 5:
                        personManager.CreatePerson(menu.CreatePersonInputHandler());
                        break;
                    case 6:
                        personManager.GetAllPersons();
                        break;
                    case 7:
                        personManager.UpdatePerson(menu.updatePersonHandler());
                        break;
                    case 8:
                        personManager.RemovePerson(menu.DeletePersonInputHandler());
                        break;
                    case 9:
                        petManager.CreatePet(menu.CreatePetHandler());
                        break;
                    case 10:
                        petManager.DisplayPets();
                        break;
                    case 11:
                        petManager.UpdatePet(menu.UpdatePetHandler());
                        break;
                    case 12:
                        petManager.DeletePet(menu.DeletePetHandler());
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