using MySql.Data.MySqlClient;
using static _1_Person_management.Database;

namespace _1_Person_management
{
    internal class PetManager : PetInterface
    {
        Validation validation = new Validation();

        private readonly List<PetConstructor> pet;

        public PetManager()
        {
            pet = new List<PetConstructor>();
        }

        #region Create Table
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
        #endregion

        public void CreatePet(string[] createData)
        {
            string petName = createData[0];
            int ownerID = int.Parse(createData[1]);

            if (validation.PersonExists(ownerID))
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
            string selectAllQuery = @"SELECT P.ID, P.PetName FROM Pets P
                                      INNER JOIN Persons Per ON P.OwnerID = Per.ID;
";

            using MySqlCommand cmd = new MySqlCommand(selectAllQuery, GetInstance());
            using MySqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("All pets in the database:");
            while (reader.Read())
            {
                int petID = reader.GetInt32("ID");
                string petName = reader.GetString("PetName");
                string ownerName = reader.GetString("OwnerName");

                Console.WriteLine($"ID: {petID}, Name: {petName}, Owner: {ownerName}");
            }
        }



        public void UpdatePet(string[] updateData)
        {
            int petID = int.Parse(updateData[0]);
            string newPetName = updateData[1];

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

        public void DeletePet(int deleteData)
        {
            try
            {
                string deleteQuery = "DELETE FROM Pets WHERE ID = @PetID;";

                using MySqlCommand deleteCmd = new(deleteQuery, GetInstance());
                deleteCmd.Parameters.AddWithValue("@PetID", deleteData);
                deleteCmd.ExecuteNonQuery();

                int rowsAffected = deleteCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Household deleted.");
                }
                else
                {
                    Console.WriteLine("Household not found in the database.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }


    }
}
