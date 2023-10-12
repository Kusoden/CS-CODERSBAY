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

    public void DisplayAllPersons()
    {
        /*        if (personList == null)
                    throw new NullReferenceException("it's Empty!");
                else
                {*/
        foreach (Person person in personList)
            Console.WriteLine($"{person.Name} {person.LastName} {person.Birthday} {person.Address} {person.PersonGender}");
        /*        }*/
    }

    // CHANGED FOR SQL

    public void CreatePerson(string name, string lastName)
    {
        if (name.Any(char.IsDigit) || lastName.Any(char.IsDigit))
            throw new InvalidPersonNameException("Invalid name: Name should not contain numbers.");
        else
        {
            using (MySqlConnection connection = new (connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Persons (FirstName, LastName) VALUES (@FirstName, @LastName)";
                MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@FirstName", name);
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
            using (MySqlConnection connection = new (connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Persons (FirstName, LastName, Birthday, Address, Gender) " +
                                    "VALUES (@FirstName, @LastName, @Birthday, @Address, @Gender)";
                MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@FirstName", name);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Birthday", birthday);
                cmd.Parameters.AddWithValue("@Address", address.ToString());
                cmd.Parameters.AddWithValue("@Gender", gender.ToString());
                cmd.ExecuteNonQuery();
            }
        }
    }





    public void RemovePerson(string name)
    {
        if (name.Any(char.IsDigit))
            throw new InvalidPersonNameException("Invalid name: Name should not contain numbers.");
        else
        {
            for (int personIndex = personList.Count - 1; personIndex >= 0; personIndex--)
            {
                Person p = personList[personIndex];
                if (p.Name.Equals(name))
                    personList.RemoveAt(personIndex);
            }
        }
    }

    public class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException(string message) : base(message) { }
    }

    public Person FindPersonByName(string name)
    {
        foreach (Person person in personList)
            if (person.Name.Equals(name))
                return person;
        throw new NullReferenceException("Person not found: " + name);
    }

}