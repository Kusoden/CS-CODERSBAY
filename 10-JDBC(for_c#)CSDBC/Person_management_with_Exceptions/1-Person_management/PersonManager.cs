using MySql.Data.MySqlClient;

namespace _1_Person_management;

public class PersonManager
{
    private readonly List<Person> personList;
    private string connectionString;

    public PersonManager()
    {
        personList = new List<Person>();
    }

    public static void CreatePersonsTable(MySqlConnection connection)
    {
        string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS Persons (
                ID INT NOT NULL AUTO_INCREMENT,
                FirstName VARCHAR(255) NOT NULL,
                LastName VARCHAR(255) NOT NULL,
                Birthday DATE,
                Address VARCHAR(255),
                Gender VARCHAR(10),
                PRIMARY KEY (ID)
            );
            ";

        MySqlCommand cmd = new MySqlCommand(createTableQuery, connection);
        cmd.ExecuteNonQuery();
        Console.WriteLine("Persons table created or already exists.");

        // Add the test query
        string testQuery = "SELECT 1";
        MySqlCommand testCmd = new(testQuery, connection);
        int result = (int)testCmd.ExecuteScalar();
        Console.WriteLine("Test query result: " + result);

    }
    public static void CreateHouseholdsTable(MySqlConnection connection)
    {
        string createTableQuery = @"
        CREATE TABLE IF NOT EXISTS Households (
            ID INT NOT NULL AUTO_INCREMENT,
            HouseholdName VARCHAR(255) NOT NULL,
            PRIMARY KEY (ID)
        );
        ";

        MySqlCommand cmd = new MySqlCommand(createTableQuery, connection);
        cmd.ExecuteNonQuery();
        Console.WriteLine("Households table created or already exists.");
    }

    public static void CreatePetsTable(MySqlConnection connection)
    {
        string createTableQuery = @"
        CREATE TABLE IF NOT EXISTS Pets (
            ID INT NOT NULL AUTO_INCREMENT,
            PetName VARCHAR(255) NOT NULL,
            OwnerID INT NOT NULL,
            PRIMARY KEY (ID),
            FOREIGN KEY (OwnerID) REFERENCES Persons(ID)
        );
        ";

        MySqlCommand cmd = new MySqlCommand(createTableQuery, connection);
        cmd.ExecuteNonQuery();
        Console.WriteLine("Pets table created or already exists.");
    }



    public static void RemovePerson(string firstNameToDelete, string lastNameToDelete)
    {
        string connectionString = "server=127.0.0.1;User ID=root;Password=;Database=personmanagerdb";

        using (MySqlConnection connection = new(connectionString))
        {
            connection.Open();

            string sql = "DELETE FROM Persons WHERE FirstName = @FirstName AND LastName = @LastName";
            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@FirstName", firstNameToDelete);
                cmd.Parameters.AddWithValue("@LastName", lastNameToDelete);
                cmd.ExecuteNonQuery();
            }

            connection.Close();
        }
    }
    public static void InsertPersonIntoDatabase(string firstName, string lastName)
    {
        string connectionString = "server=127.0.0.1;User ID=root;Password=;Database=personmanagerdb";

        using (MySqlConnection connection = new(connectionString))
        {
            connection.Open();

            string insertQuery = "INSERT INTO Persons (FirstName, LastName) VALUES (@FirstName, @LastName);";

            MySqlCommand cmd = new(insertQuery, connection);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);

            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }

    public static void InsertPersonIntoDatabase(string firstName, string lastName, string birthday, Person.Gender gender)
    {
        string connectionString = "server=127.0.0.1;User ID=root;Password=;Database=personmanagerdb";

        using (MySqlConnection connection = new (connectionString))
        {
            connection.Open();

            string insertQuery = "INSERT INTO Persons (FirstName, LastName, Birthday, Gender) " +
                                "VALUES (@FirstName, @LastName, @Birthday, @Gender);";

            MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Birthday", birthday);
            cmd.Parameters.AddWithValue("@Gender", gender); // Assuming gender is an enum

            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }

    public static void InsertPersonIntoDatabase(string firstName, string lastName, string birthday, Address address, Person.Gender gender)
    {
        string connectionString = "server=127.0.0.1;User ID=root;Password=;Database=personmanagerdb";

        using (MySqlConnection connection = new(connectionString))
        {
            connection.Open();

            string insertQuery = "INSERT INTO Persons (FirstName, LastName, Birthday, Address, PersonGender) " +
                                "VALUES (@FirstName, @LastName, @Birthday, @Address, @Gender);";

            MySqlCommand cmd = new(insertQuery, connection);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Birthday", birthday);
            cmd.Parameters.AddWithValue("@Address", address.ToString()); 
            cmd.Parameters.AddWithValue("@Gender", gender);

            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }

    public static void InsertPersonWithDetails()
    {
        Console.WriteLine("Choose the level of detail for creating a person:");
        Console.WriteLine("1. First Name and Last Name");
        Console.WriteLine("2. First Name, Last Name, Birthday, and Gender");
        Console.WriteLine("3. First Name, Last Name, Birthday, Address, and Gender");

        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("Enter a person's first name:");
                string firstName = Console.ReadLine().Trim();
                Console.WriteLine("Enter the person's last name:");
                string lastName = Console.ReadLine().Trim();
                InsertPersonIntoDatabase(firstName, lastName);
                break;
            case "2":
                Console.WriteLine("Enter a person's first name:");
                string firstName2 = Console.ReadLine().Trim();
                Console.WriteLine("Enter the person's last name:");
                string lastName2 = Console.ReadLine().Trim();
                Console.WriteLine("Enter the person's birthday FORMAT: YYYY-MM-DD (write the lines '-' between them) :");
                string birthday2 = Console.ReadLine().Trim();
                Console.WriteLine("Enter the person's gender (Male or Female):");
                string genderInput = Console.ReadLine().Trim();
                if (Enum.TryParse<Person.Gender>(genderInput, out var gender2))
                    InsertPersonIntoDatabase(firstName2, lastName2, birthday2, gender2);
                else
                    Console.WriteLine("Invalid gender input.");
                break;
            case "3":
                Console.WriteLine("Enter a person's first name:");
                string firstName3 = Console.ReadLine().Trim();
                Console.WriteLine("Enter the person's last name:");
                string lastName3 = Console.ReadLine().Trim();
                Console.WriteLine("Enter the person's birthday FORMAT: YYYY-MM-DD (write the lines '-' between them) :");
                string birthday3 = Console.ReadLine().Trim();
                Console.WriteLine("Enter the person's PLZ (Postal Code):");
                int plz = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the person's Location:");
                string location = Console.ReadLine().Trim();
                Console.WriteLine("Enter the person's Street Name:");
                string streetName = Console.ReadLine().Trim();
                Console.WriteLine("Enter the person's House Number:");
                int houseNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the person's gender (Male or Female):");
                string genderInput3 = Console.ReadLine().Trim();
                if (Enum.TryParse<Person.Gender>(genderInput3, out var gender3))
                {
                    Address address3 = new (streetName, houseNumber, plz, location);
                    InsertPersonIntoDatabase(firstName3, lastName3, birthday3, address3, gender3);
                }
                else
                    Console.WriteLine("Invalid gender input.");
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }


    public class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException(string message) : base(message) { }
    }

    public Person FindPersonByName(string name)
    {
        foreach (Person person in personList)
            if (person.FirstName.Equals(name))
                return person;
        throw new NullReferenceException("Person not found: " + name);
    }

    public static void DisplayAllPersons()
    {
        string connectionString = "server=127.0.0.1;User ID=root;Password=;Database=personmanagerdb";
        using (MySqlConnection connection = new(connectionString))
        {
            connection.Open();

            string sql = "SELECT FirstName, LastName, Birthday, Address, Gender FROM Persons";
            using (MySqlCommand cmd = new(sql, connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string firstName = reader.GetString("FirstName");
                        string lastName = reader.GetString("LastName");
                        string birthday = reader.IsDBNull(reader.GetOrdinal("Birthday")) ? "Birthday unknown" : reader.GetString("Birthday");
                        string address = reader.IsDBNull(reader.GetOrdinal("Address")) ? "Adress unknown" : reader.GetString("Address");
                        string gender = reader.IsDBNull(reader.GetOrdinal("Gender")) ? "Gender unknown" : reader.GetString("Gender");

                        Console.WriteLine($"{firstName} {lastName} {birthday} {address} {gender}");
                    }
                }
            }

            connection.Close();
        }
    }

    public static bool PersonExists(string firstName, string lastName)
    {
        string connectionString = "server=127.0.0.1;User ID=root;Password=;Database=personmanagerdb";
        using (MySqlConnection connection = new(connectionString))
        {
            connection.Open();

            string sql = "SELECT COUNT(*) FROM Persons WHERE FirstName = @FirstName AND LastName = @LastName";
            using (MySqlCommand cmd = new(sql, connection))
            {
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }

            connection.Close();
        }
    }

    public static void UpdatePerson(string currentFirstName, string currentLastName, string newFirstName, string newLastName)
    {
        string connectionString = "server=127.0.0.1;User ID=root;Password=;Database=personmanagerdb";
        using (MySqlConnection connection = new(connectionString))
        {
            connection.Open();

            if (PersonExists(currentFirstName, currentLastName))
            {
                string sql = "UPDATE Persons SET FirstName = @NewFirstName, LastName = @NewLastName WHERE FirstName = @CurrentFirstName AND LastName = @CurrentLastName";
                using (MySqlCommand cmd = new(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@NewFirstName", newFirstName);
                    cmd.Parameters.AddWithValue("@NewLastName", newLastName);
                    cmd.Parameters.AddWithValue("@CurrentFirstName", currentFirstName);
                    cmd.Parameters.AddWithValue("@CurrentLastName", currentLastName);
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Person data updated.");
            }
            else
                Console.WriteLine("Person not found in the database.");

            connection.Close();
        }
    }
}
    /*public void CreatePerson(string firstName, string lastName)
    {
        
        if (firstName.Any(char.IsDigit) || lastName.Any(char.IsDigit))
            throw new InvalidPersonNameException("Invalid firstName: Name should not contain numbers.");
        else
        {
            using (MySqlConnection connection = new (connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Persons (FirstName, LastName) VALUES (@FirstName, @LastName)";
                MySqlCommand cmd = new(insertQuery, connection);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void CreatePerson(string name, string lastName, string birthday, Address address, Person.Gender gender)
    {
        if (name.Any(char.IsDigit) || lastName.Any(char.IsDigit))
            throw new InvalidPersonNameException("Invalid name: Name should not contain numbers.");
        else
        {
            using (MySqlConnection connection = new(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Persons (FirstName, LastName, Birthday, Address, Gender) VALUES (@FirstName, @LastName, @Birthday, @Address, @Gender)";
                MySqlCommand cmd = new (insertQuery, connection);
                cmd.Parameters.AddWithValue("@FirstName", name);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Birthday", birthday);
                cmd.Parameters.AddWithValue("@Address", address.ToString());
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.ExecuteNonQuery();
            }
        }
    }*/