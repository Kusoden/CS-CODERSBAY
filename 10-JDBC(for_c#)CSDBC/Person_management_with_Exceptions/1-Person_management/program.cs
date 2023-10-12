
using static _1_Person_management.PersonManager;

namespace _1_Person_management
{
    class Person_Management
    {
        static void Main()
        {
            Database.CallDB();


            PersonManager personManager = new PersonManager();

            while (true)
            {
                Console.WriteLine("Enter a person's first name (or type 'exit' to quit):");
                string firstName = Console.ReadLine().Trim();

                if (firstName.ToLower() == "exit")
                {
                    break;
                }

                Console.WriteLine("Enter the person's last name:");
                string lastName = Console.ReadLine().Trim();

                Console.WriteLine("Enter the person's birthday (optional, format: yyyy-MM-dd):");
                string birthday = Console.ReadLine().Trim();

                Console.WriteLine("Enter the person's address (optional):");
                string address = Console.ReadLine().Trim();

                Console.WriteLine("Enter the person's gender (Male/Female/Unknown):");
                string gender = Console.ReadLine().Trim();

                try
                {
                    if (!string.IsNullOrEmpty(birthday) && !string.IsNullOrEmpty(address))
                    {
                        personManager.CreatePerson(firstName, lastName, birthday, new Address(address), (Person.Gender)Enum.Parse(typeof(Person.Gender), gender));
                    }
                    else if (!string.IsNullOrEmpty(birthday))
                    {
                        personManager.CreatePerson(firstName, lastName, birthday, null, (Person.Gender)Enum.Parse(typeof(Person.Gender), gender));
                    }

                    Console.WriteLine("Person created and added to the database.");
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("MySQL Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            Console.WriteLine("All persons in the database:");
            personManager.DisplayAllPersons();

        }

    }
}


