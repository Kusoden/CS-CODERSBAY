using MySql.Data.MySqlClient;
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

        public static List<Pet> DisplayPets()
        {
            string selectAllQuery = "SELECT P.ID, P.PetName, P.OwnerID, CONCAT_WS(' ', Per.FirstName, Per.LastName) AS OwnerName " +
                                    "FROM Pets P " +
                                    "INNER JOIN Persons Per ON P.OwnerID = Per.ID;";

            List<Pet> pets = new List<Pet>();

            using (MySqlCommand cmd = new(selectAllQuery, DBSqlConn))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int petID = reader.GetInt32("ID");
                    string petName = reader.GetString("PetName");
                    int ownerID = reader.GetInt32("OwnerID");

                    pets.Add(new Pet(petID, petName, ownerID));
                }
            }

            return pets;
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
            string deleteQuery = "DELETE FROM Pets WHERE ID = @PetID;";

            using MySqlCommand cmd = new(deleteQuery, DBSqlConn);
            cmd.Parameters.AddWithValue("@PetID", petID);
            cmd.ExecuteNonQuery();
        }

    }
}
