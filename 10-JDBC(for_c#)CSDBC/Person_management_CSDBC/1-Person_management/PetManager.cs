using MySql.Data.MySqlClient;
using static _1_Person_management.Database;

namespace _1_Person_management
{
    internal class PetManager : PetInterface
    {
        private readonly List<Pet> pet;

        public PetManager()
        {
            pet = new List<Pet>();
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

        public void CreatePet(string petName, int ownerID)
        {
            string insertQuery = "INSERT INTO Pets (PetName, OwnerID) VALUES (@PetName, @OwnerID);";

            using MySqlCommand cmd = new(insertQuery, GetInstance());
            cmd.Parameters.AddWithValue("@PetName", petName);
            cmd.Parameters.AddWithValue("@OwnerID", ownerID);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Pet created and associated with the owner.");
        }

        public void DisplayPets()
        {
            string selectAllQuery = "SELECT P.ID, P.PetName, CONCAT_WS(' ', Per.FirstName, Per.LastName) AS OwnerName " +
                                    "FROM Pets P " +
                                    "INNER JOIN Persons Per ON P.OwnerID = Per.ID;";

            using (MySqlCommand cmd = new MySqlCommand(selectAllQuery, GetInstance()))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int petID = reader.GetInt32("ID");
                    string petName = reader.GetString("PetName");
                    string ownerName = reader.GetString("OwnerName");

                    Console.WriteLine($"ID: {petID}, Name: {petName}, Owner: {ownerName}");
                }
            }
        }



        public void UpdatePet(int petID, string newPetName)
        {
            string updateQuery = "UPDATE Pets SET PetName = @NewPetName WHERE ID = @PetID;";

            using MySqlCommand cmd = new(updateQuery, GetInstance());
            cmd.Parameters.AddWithValue("@NewPetName", newPetName);
            cmd.Parameters.AddWithValue("@PetID", petID);
            cmd.ExecuteNonQuery();
        }

        public void DeletePet(int petID)
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
        }


    }
}
