using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using static _1_Person_management.Database;

namespace _1_Person_management
{
    //TODO: return int with a status information and get the cw into the other method
    //it can be switched out so it can have multiple implementations example: mssql, oracle etc.
    internal class PersonManager : PersonInterface
    {
        private readonly List<PersonConstructor> personList;

        public PersonManager()
        {
            personList = new List<PersonConstructor>();
        }

        #region create table
        public void CreatePersonsTable()
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
                );"
            ;
            try
            {
                MySqlCommand cmd = new(createTableQuery, GetInstance());
                cmd.ExecuteNonQuery();
                Console.WriteLine("Persons table created or already exists.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        public void CreatePerson(PersonConstructor person) 
        {
            try
            {
                string insertQuery = "INSERT INTO Persons (FirstName, LastName, Birthday, Gender, HouseholdID) VALUES (@FirstName, @LastName, @Birthday, @Gender, @HouseholdID);";

                MySqlCommand cmd = new(insertQuery, GetInstance());
                cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
                cmd.Parameters.AddWithValue("@LastName", person.LastName);
                cmd.Parameters.AddWithValue("@Birthday", person.Birthday);
                cmd.Parameters.AddWithValue("@Gender", person.PersonGender);
                cmd.Parameters.AddWithValue("@HouseholdID", person.HouseholdID);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Failed to connect to the Database: " + ex.Message);
            }
        }

        public class InvalidPersonNameException : Exception
        {
            public InvalidPersonNameException(string message) : base(message) { }
        }

        public PersonConstructor FindPersonByName(string name)
        {
            foreach (PersonConstructor person in personList)
                if (person.FirstName.Equals(name))
                    return person;
            throw new NullReferenceException("Person not found: " + name); 
        }

        public void DisplayAllPersons()
        {
            try
            {
                string sql = "SELECT FirstName, LastName, Birthday, HouseholdID, Gender FROM Persons";
                using MySqlCommand cmd = new(sql, GetInstance());
                using MySqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("All persons in the database:");

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

        public void UpdatePerson(string[] updateData)
        {
            string firstNameToUpdate = updateData[0];
            string lastNameToUpdate = updateData[1];
            string newFirstName = updateData[2];
            string newLastName = updateData[3];
            try
            {
                string sql = "UPDATE Persons SET FirstName = @NewFirstName, LastName = @NewLastName WHERE FirstName = @CurrentFirstName AND LastName = @CurrentLastName";
                using (MySqlCommand cmd = new(sql, GetInstance()))
                {
                    cmd.Parameters.AddWithValue("@NewFirstName", newFirstName);
                    cmd.Parameters.AddWithValue("@NewLastName", newLastName);
                    cmd.Parameters.AddWithValue("@CurrentFirstName", firstNameToUpdate);
                    cmd.Parameters.AddWithValue("@CurrentLastName", lastNameToUpdate);
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Person data updated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RemovePerson(string[] removeData)
        {
            string firstNameToDelete = removeData[0];
            string lastNameToDelete = removeData[1];

            try
            {
                string sql2 = "DELETE FROM Persons WHERE FirstName = @FirstName AND LastName = @LastName";
                using MySqlCommand deleteCmd = new(sql2, GetInstance());
                deleteCmd.Parameters.AddWithValue("@FirstName", firstNameToDelete);
                deleteCmd.Parameters.AddWithValue("@LastName", lastNameToDelete);

                int rowsAffected = deleteCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Person removed from the database.");
                }
                else
                {
                    Console.WriteLine("Person not found in the database.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}