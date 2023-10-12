using MySql.Data.MySqlClient;

namespace _1_Person_management
{
    class Person_Management
    {
        static void Main()
        {
            Database.CallDB();

            PersonManager personManager = new();

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

                try
                {
                    // Insert the person into the database
                    InsertPersonIntoDatabase(firstName, lastName);

                    Console.WriteLine("Person created and added to the database.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            Console.WriteLine("All persons in the database:");
            personManager.DisplayAllPersons();
        }

        public static void InsertPersonIntoDatabase(string firstName, string lastName)
        {
            string connectionString = "server=127.0.0.1;User ID=root;Password=;Database=personmanagerdb";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Insert a person into the Persons table
                Database.InsertPerson(connection, firstName, lastName);

                connection.Close();
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
    }
}


