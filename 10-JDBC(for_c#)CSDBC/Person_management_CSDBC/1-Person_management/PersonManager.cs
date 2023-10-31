using MySql.Data.MySqlClient;
using static _1_Person_management.Database;

namespace _1_Person_management;

public class PersonManager
{
    private readonly List<Person> personList;

    public PersonManager()
    {
        personList = new List<Person>();
    }

    public static void CreatePersonsTable()
    {
        string createTableQuery = @"
        CREATE TABLE IF NOT EXISTS Persons (
            ID INT NOT NULL AUTO_INCREMENT,
            FirstName VARCHAR(255) NOT NULL,
            LastName VARCHAR(255) NOT NULL,
            Birthday DATE,
            Gender VARCHAR(10),
            HouseholdID INT,
            PRIMARY KEY (ID),
            FOREIGN KEY (HouseholdID) REFERENCES Households(ID)
        );
        ";
        try
        {
            MySqlCommand cmd = new(createTableQuery, DBSqlConn);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Persons table created or already exists.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }



    public static void CreatePetsTable()
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

        try
        {
            MySqlCommand cmd = new(createTableQuery, DBSqlConn);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Pets table created or already exists.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }


    public static void RemovePerson(string firstNameToDelete, string lastNameToDelete)
    {
        using MySqlCommand cmd = new("SELECT FirstName, LastName, Birthday, Address, Gender FROM Persons", DBSqlConn);
        using MySqlDataReader reader = cmd.ExecuteReader();

        bool exists = false;

        while (reader.Read())
        {
            string firstName = reader.GetString("FirstName");
            string lastName = reader.GetString("LastName");

            if (firstName == firstNameToDelete && lastName == lastNameToDelete)
            {
                exists = true;
                break;
            }
        }

        reader.Close();

        if (exists)
        {
            string sql2 = "DELETE FROM Persons WHERE FirstName = @FirstName AND LastName = @LastName";
            using MySqlCommand deleteCmd = new(sql2, DBSqlConn);
            deleteCmd.Parameters.AddWithValue("@FirstName", firstNameToDelete);
            deleteCmd.Parameters.AddWithValue("@LastName", lastNameToDelete);
            deleteCmd.ExecuteNonQuery();
            Console.WriteLine("Person removed from the database.");
        }
        else
        {
            Console.WriteLine("Person not found in the database.");
        }
    }

    public static void CreatePerson(string firstName, string lastName, int householdID)
    {

        try
        {
            string insertQuery = "INSERT INTO Persons (FirstName, LastName, HouseholdID) VALUES (@FirstName, @LastName, @HouseholdID);";

            MySqlCommand cmd = new(insertQuery, DBSqlConn);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@HouseholdID", householdID);

            cmd.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Failed to connect to the Database: " + ex.Message);
        }
    }

    public static void CreatePerson(string firstName, string lastName, string birthday, Person.Gender gender, int householdID)
    {
        try
        {
            string insertQuery = "INSERT INTO Persons (FirstName, LastName, Birthday, Gender, HouseholdID) VALUES (@FirstName, @LastName, @Birthday, @Gender, @HouseholdID);";

            MySqlCommand cmd = new(insertQuery, DBSqlConn);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Birthday", birthday);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@HouseholdID", householdID);

            cmd.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Failed to connect to the Database: " + ex.Message);
        }
    }

    public static void CreatePerson(string firstName, string lastName, string birthday, Address address, Person.Gender gender, int householdID)
    {
        try
        {
            string insertQuery = "INSERT INTO Persons (FirstName, LastName, Birthday, PersonGender, HouseholdID) VALUES (@FirstName, @LastName, @Birthday, @Gender, @HouseholdID);";

            MySqlCommand cmd = new(insertQuery, DBSqlConn);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Birthday", birthday);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@HouseholdID", householdID);

            cmd.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Failed to connect to the Database: " + ex.Message);
        }
    }

    public static void InsertPersonWithDetails()
    {
        Console.WriteLine("Choose the level of detail for creating a person:");
        Console.WriteLine("1. First and Last Name with Household ID");
        Console.WriteLine("2. First and Last Name, Birthday, Gender and Household ID");

        Console.Write("Enter your choice: ");
        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("Enter a person's first name:");
                string firstName = Console.ReadLine().Trim();
                Console.WriteLine("Enter the person's last name:");
                string lastName = Console.ReadLine().Trim();
                Console.WriteLine("Enter the house number:");
                int householdID1 = int.Parse(Console.ReadLine());
                CreatePerson(firstName, lastName, householdID1);
                break;
            case "2":
                Console.WriteLine("Enter a person's first name:");
                string firstName2 = Console.ReadLine().Trim();
                Console.WriteLine("Enter the person's last name:");
                string lastName2 = Console.ReadLine().Trim();
                Console.WriteLine("Enter the person's birthday (YYYY-MM-DD):");
                string birthday2 = Console.ReadLine().Trim();
                Console.WriteLine("Enter the person's gender (Male or Female):");
                string genderInput = Console.ReadLine().Trim();
                if (Enum.TryParse<Person.Gender>(genderInput, out var gender2))
                {
                    Console.WriteLine("Enter the house number:");
                    int householdID2 = int.Parse(Console.ReadLine());
                    CreatePerson(firstName2, lastName2, birthday2, gender2, householdID2);
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
        try
        {
            string sql = "SELECT FirstName, LastName, Birthday, HouseholdID, Gender FROM Persons";
            using MySqlCommand cmd = new(sql, DBSqlConn);
            using MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string firstName = reader.GetString("FirstName");
                string lastName = reader.GetString("LastName");
                string birthday = reader.IsDBNull(reader.GetOrdinal("Birthday")) ? "unknown" : reader.GetString("Birthday");
                string gender = reader.IsDBNull(reader.GetOrdinal("Gender")) ? "unknown" : reader.GetString("Gender");
                string address = reader.GetString("HouseholdID");

                Console.WriteLine($"\nFirstname: {firstName} Lastname: {lastName}\nBirthday: {birthday}\nGender: {gender}\nHouse Number: {address}\n");
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Failed to connect to the Database: " + ex.Message);
        }
    }

    public static bool PersonExists(string firstName, string lastName)
    {
        try
        {
            string sql = "SELECT COUNT(*) FROM Persons WHERE FirstName = @FirstName AND LastName = @LastName";
            using MySqlCommand cmd = new(sql, DBSqlConn);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Failed to connect to the Database: " + ex.Message);
            return false;
        }
    }

    public static bool PersonExists(int ownerID)
    {
        try
        {
            string sql = "SELECT COUNT(*) FROM Persons WHERE ID = @ID";
            using MySqlCommand cmd = new(sql, DBSqlConn);
            cmd.Parameters.AddWithValue("@ID", ownerID);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            return count > 0;
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Failed to connect to the Database: " + ex.Message);
            return false;
        }
    }

    public static void UpdatePerson(string currentFirstName, string currentLastName, string newFirstName, string newLastName)
    {
        if (PersonExists(currentFirstName, currentLastName))
        {
            string sql = "UPDATE Persons SET FirstName = @NewFirstName, LastName = @NewLastName WHERE FirstName = @CurrentFirstName AND LastName = @CurrentLastName";
            using (MySqlCommand cmd = new(sql, DBSqlConn))
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
    }
}