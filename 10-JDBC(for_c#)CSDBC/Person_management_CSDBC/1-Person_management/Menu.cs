using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using static _1_Person_management.PersonConstructor;

namespace _1_Person_management
{
    public class Menu
    {
        PersonInterface personManager = new PersonManager();
        Validation validation = new Validation();
        public int MainMenu()
        {
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
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 13)
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            return choice;
        }

        #region Person
        public PersonConstructor CreatePersonInputHandler()
        {
            PersonConstructor person = new PersonConstructor("firstname", "lastname", "00001122", Gender.Unknown, 2);

            Console.WriteLine("Choose the level of detail for creating a person:");
            Console.WriteLine("1. First and Last Name with Household ID");
            Console.WriteLine("2. First and Last Name, Birthday, Gender and Household ID");

            Console.Write("Enter your choice: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    do
                    {
                        Console.WriteLine("Enter a person's first name:");
                        person.FirstName = Console.ReadLine().Trim();
                    } while (string.IsNullOrEmpty(person.FirstName) || !Regex.IsMatch(person.FirstName, @"^[a-zA-Z]+$"));

                    do
                    {
                        Console.WriteLine("Enter the person's last name:");
                        person.LastName = Console.ReadLine().Trim();
                    } while (string.IsNullOrEmpty(person.LastName) || !Regex.IsMatch(person.LastName, @"^[a-zA-Z]+$"));

                    while (true)
                    {
                        Console.WriteLine("Enter the house number:");
                        string input = Console.ReadLine();

                        if (int.TryParse(input, out int householdID))
                        {
                            person.HouseholdID = householdID;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number for the household ID.");
                        }
                    }

                    try
                    {
                        personManager.CreatePerson(person);
                        Console.WriteLine("Person created and added to the database.\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "2":
                    do
                    {
                        Console.WriteLine("Enter a person's first name:");
                        person.FirstName = Console.ReadLine().Trim();
                    } while (string.IsNullOrEmpty(person.FirstName) || !Regex.IsMatch(person.FirstName, @"^[a-zA-Z]+$"));

                    do
                    {
                        Console.WriteLine("Enter the person's last name:");
                        person.LastName = Console.ReadLine().Trim();
                    } while (string.IsNullOrEmpty(person.LastName) || !Regex.IsMatch(person.LastName, @"^[a-zA-Z]+$"));

                    while (true)
                    {
                        Console.WriteLine("Enter the person's birthday, format should be according to this (YYYYMMDD):");
                        person.Birthday = Console.ReadLine().Replace(" ", "");

                        if (!Regex.IsMatch(person.Birthday, @"^\d{4}\d{2}\d{2}$"))
                        {
                            Console.WriteLine("Please re-enter the birthday in the format YYYYMMDD.");
                        }
                        else
                        {
                            break;
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Enter the person's gender (Male or Female):");
                        string genderInput = Console.ReadLine().ToLower().Replace(" ", "");

                        if (genderInput == "male" || genderInput == "female")
                        {
                            if (Enum.TryParse(genderInput, out PersonConstructor.Gender gender))
                            {
                                person.PersonGender = gender;
                                break;
                            }
                        }

                        Console.WriteLine("Invalid gender input. Please enter Male or Female.");
                    }

                    while (true)
                    {
                        Console.WriteLine("Enter the house number:");
                        string input = Console.ReadLine();

                        if (int.TryParse(input, out int householdID))
                        {
                            person.HouseholdID = householdID;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number for the household ID.");
                        }
                    }
                    try
                    {
                        personManager.CreatePerson(person);
                        Console.WriteLine("Person created and added to the database.\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            return person;
        }


        public string[] updatePersonHandler()
        {
            string firstNameToUpdate;
            string lastNameToUpdate;
            string newFirstName = "";
            string newLastName = "";

            do
            {
                Console.WriteLine("Enter the first name of the person to update:");
                firstNameToUpdate = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(firstNameToUpdate) || !Regex.IsMatch(firstNameToUpdate, @"^[a-zA-Z]+$"));

            do
            {
                Console.WriteLine("Enter the last name of the person to update:");
                lastNameToUpdate = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(lastNameToUpdate) || !Regex.IsMatch(lastNameToUpdate, @"^[a-zA-Z]+$"));

            if (validation.PersonExists(firstNameToUpdate, lastNameToUpdate))
            {
                do
                {
                    Console.WriteLine("Enter the new first name:");
                    newFirstName = Console.ReadLine().Trim();
                } while (string.IsNullOrEmpty(newFirstName) || !Regex.IsMatch(newFirstName, @"^[a-zA-Z]+$"));

                do
                {
                    Console.WriteLine("Enter the new last name:");
                    newLastName = Console.ReadLine().Trim();
                } while (string.IsNullOrEmpty(newLastName) || !Regex.IsMatch(newLastName, @"^[a-zA-Z]+$"));
            }
            else
            {
                Console.WriteLine("Person not found in the database.");
            }
            return new string[] { firstNameToUpdate, lastNameToUpdate, newFirstName, newLastName };
        }

        public string[] DeletePersonInputHandler()
        {
            string firstNameToDelete;
            string lastNameToDelete;

            do
            {
                Console.WriteLine("Enter the first name of the person to delete:");
                firstNameToDelete = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(firstNameToDelete) || !Regex.IsMatch(firstNameToDelete, @"^[a-zA-Z]+$"));

            do
            {
                Console.WriteLine("Enter the last name of the person to delete:");
                lastNameToDelete = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(lastNameToDelete) || !Regex.IsMatch(lastNameToDelete, @"^[a-zA-Z]+$"));

            return new string[] { firstNameToDelete, lastNameToDelete };
        }
        #endregion

        #region HouseHold

        public string HouseholdNameHandler()
        {
            string householdName;

            do
            {
                Console.WriteLine("Enter the household name:");
                householdName = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(householdName));

            return householdName;
        }


        public string[] UpdateHouseHoldHandler()
        {
            int householdID;
            string HouseHoldnumber; //string version of the integer so i can return it back with the array
            string newHouseholdName;

            while (true)
            {
                Console.WriteLine("Enter the ID of the household to update:");
                HouseHoldnumber = Console.ReadLine();

                if (int.TryParse(HouseHoldnumber, out householdID))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a number for the household ID.");
                }
            }

            do
            {
                Console.WriteLine("Enter the new household name:");
                newHouseholdName = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(newHouseholdName) || !Regex.IsMatch(newHouseholdName, @"^[a-zA-Z]+$"));

            return new string[] { HouseHoldnumber, newHouseholdName };
        }

        public int DeleteHouseHoldHandler()
        {
            string input;
            do
            {
                Console.WriteLine("Enter the ID of the household to delete:");
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input) || !Regex.IsMatch(input, @"^\d+$"));

            int householdID = int.Parse(input);
            return householdID;
        }

        #endregion

        #region Pet

        public string[] CreatePetHandler()
        {
            string petName;
            string ownerID;
            do
            {
                Console.WriteLine("Enter the name of the pet:");
                petName = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(petName) || !Regex.IsMatch(petName, @"^[a-zA-Z]+$"));

            do
            {
                Console.WriteLine("Enter the owner's ID:");
                ownerID = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(ownerID) || !Regex.IsMatch(ownerID, @"^\d+$"));

            return new string[] { petName, ownerID };
        }

        public string[] UpdatePetHandler()
        {
            string petID;
            string newPetName;

            do
            {
                Console.WriteLine("Enter the ID of the pet to update:");
                petID = Console.ReadLine();
            } while (string.IsNullOrEmpty(petID) || !Regex.IsMatch(petID, @"^\d+$"));

            do
            {
                Console.WriteLine("Enter the new pet name:");
                newPetName = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(newPetName) || !Regex.IsMatch(newPetName, @"^[a-zA-Z]+$"));

            return new string[] { petID, newPetName };
        }

        public int DeletePetHandler()
        {
            string input;
            do
            {
                Console.WriteLine("Enter the ID of the Pet to delete:");
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input) || !Regex.IsMatch(input, @"^\d+$"));

            int petID = int.Parse(input);

            return petID;
        }

        #endregion
    }
}