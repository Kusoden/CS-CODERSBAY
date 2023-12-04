using MySql.Data.MySqlClient;
using static _1_Person_management.Database;

namespace _1_Person_management
{
    internal class PetManager : PetInterface
    {
        PersonInterface personManager = new PersonManager();

        private readonly List<PetConstructor> pet;

        public PetManager()
        {
            pet = new List<PetConstructor>();
        }

        public void CreatePetsTable()
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
                MySqlCommand cmd = new(createTableQuery, GetInstance());
                cmd.ExecuteNonQuery();
                Console.WriteLine("Pets table created or already exists.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CreatePet()
        {

            Console.WriteLine("Enter the name of the pet:");
            string petName = Console.ReadLine().Trim();

            Console.WriteLine("Enter the owner's ID:");
            int ownerID = Convert.ToInt32(Console.ReadLine());

            if (personManager.PersonExists(ownerID))
            {
                string insertQuery = "INSERT INTO Pets (PetName, OwnerID) VALUES (@PetName, @OwnerID);";

                using MySqlCommand cmd = new(insertQuery, GetInstance());
                cmd.Parameters.AddWithValue("@PetName", petName);
                cmd.Parameters.AddWithValue("@OwnerID", ownerID);
                cmd.ExecuteNonQuery();

                Console.WriteLine("Pet created and associated with the owner.");

            }
            else
            {
                Console.WriteLine("Owner not found in the database. Please create the owner first.");
            }
        }

        public void DisplayPets()
        {
            string selectAllQuery = "SELECT P.ID, P.PetName, CONCAT_WS(' ', Per.FirstName, Per.LastName) AS OwnerName " +
                                    "FROM Pets P " +
                                    "INNER JOIN Persons Per ON P.OwnerID = Per.ID;";

            using (MySqlCommand cmd = new MySqlCommand(selectAllQuery, GetInstance()))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {

                Console.WriteLine("All pets in the database:");
                while (reader.Read())
                {
                    int petID = reader.GetInt32("ID");
                    string petName = reader.GetString("PetName");
                    string ownerName = reader.GetString("OwnerName");

                    Console.WriteLine($"ID: {petID}, Name: {petName}, Owner: {ownerName}");
                }
            }
        }



        public void UpdatePet()
        {

            Console.WriteLine("Enter the ID of the pet to update:");
            int petID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the new pet name:");
            string newPetName = Console.ReadLine().Trim();

            try
            {
                string updateQuery = "UPDATE Pets SET PetName = @NewPetName WHERE ID = @PetID;";

                using MySqlCommand cmd = new(updateQuery, GetInstance());
                cmd.Parameters.AddWithValue("@NewPetName", newPetName);
                cmd.Parameters.AddWithValue("@PetID", petID);
                cmd.ExecuteNonQuery();

                Console.WriteLine("Pet updated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void DeletePet()
        {
            Console.WriteLine("Enter the ID of the pet to delete:");
            int petID = int.Parse(Console.ReadLine());

            try
            {
                string checkQuery = "SELECT COUNT(*) FROM Pets WHERE ID = @PetID;";

                using MySqlCommand checkCmd = new(checkQuery, GetInstance());
                checkCmd.Parameters.AddWithValue("@PetID", petID);

                int petCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (petCount > 0)
                {
                    string deleteQuery = "DELETE FROM Pets WHERE ID = @PetID;";

                    using MySqlCommand deleteCmd = new(deleteQuery, GetInstance());
                    deleteCmd.Parameters.AddWithValue("@PetID", petID);
                    deleteCmd.ExecuteNonQuery();
                }
                else
                {
                    Console.WriteLine("Pet with ID " + petID + " does not exist.");
                }
                Console.WriteLine("Pet deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }


    }
}
