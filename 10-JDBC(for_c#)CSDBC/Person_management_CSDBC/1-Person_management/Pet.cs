using MySql.Data.MySqlClient;
using System.Drawing;
using static _1_Person_management.Database;
namespace _1_Person_management
{
    public class Pet
    {

        public int ID { get; set; }
        public string PetName { get; set; }
        public int OwnerID { get; set; }

        public Pet(int id, string petName, int ownerID)
        {
            ID = id;
            PetName = petName;
            OwnerID = ownerID;
        }

        public static void CreatePet(string petName, int ownerID)
        {
            string insertQuery = "INSERT INTO Pets (PetName, OwnerID) VALUES (@PetName, @OwnerID);";

            using MySqlCommand cmd = new(insertQuery, DBSqlConn);
            cmd.Parameters.AddWithValue("@PetName", petName);
            cmd.Parameters.AddWithValue("@OwnerID", ownerID);
            cmd.ExecuteNonQuery();
        }

        //TODO: Name of the owner instead of ID
        public static void DisplayPets()
        {
            string selectAllQuery = "SELECT P.ID, P.PetName, CONCAT_WS(' ', Per.FirstName, Per.LastName) AS OwnerName " +
                                    "FROM Pets P " +
                                    "INNER JOIN Persons Per ON P.OwnerID = Per.ID;";

            using (MySqlCommand cmd = new MySqlCommand(selectAllQuery, DBSqlConn))
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



        public static void UpdatePet(int petID, string newPetName)
        {
            string updateQuery = "UPDATE Pets SET PetName = @NewPetName WHERE ID = @PetID;";

            using MySqlCommand cmd = new(updateQuery, DBSqlConn);
            cmd.Parameters.AddWithValue("@NewPetName", newPetName);
            cmd.Parameters.AddWithValue("@PetID", petID);
            cmd.ExecuteNonQuery();
        }

        public static void DeletePet(int petID)
        {
            string checkQuery = "SELECT COUNT(*) FROM Pets WHERE ID = @PetID;";

            using MySqlCommand checkCmd = new(checkQuery, DBSqlConn);
            checkCmd.Parameters.AddWithValue("@PetID", petID);

            int petCount = Convert.ToInt32(checkCmd.ExecuteScalar());

            if (petCount > 0)
            {
                string deleteQuery = "DELETE FROM Pets WHERE ID = @PetID;";

                using MySqlCommand deleteCmd = new(deleteQuery, DBSqlConn);
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
