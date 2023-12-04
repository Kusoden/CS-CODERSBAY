using MySql.Data.MySqlClient;
using static _1_Person_management.Database;

namespace _1_Person_management
{
    public class HouseholdManager : HouseholdInterface
    {
        private readonly List<HouseholdConstructor> household;

        public HouseholdManager()
        {
            household = new List<HouseholdConstructor>();
        }
        public void CreateHouseholdsTable()
        {
            string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Households (
                    ID INT NOT NULL AUTO_INCREMENT,
                    HouseholdName VARCHAR(255) NOT NULL,
                    PRIMARY KEY (ID)
                );
                ";
            try
            {
                MySqlCommand cmd = new(createTableQuery, GetInstance());
                cmd.ExecuteNonQuery();
                Console.WriteLine("Households table created or already exists.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CreateHousehold(string name)
        {
            string insertQuery = "INSERT INTO Households (HouseholdName) VALUES (@HouseholdName);";

            try
            {
                using MySqlCommand cmd = new(insertQuery, GetInstance());
                cmd.Parameters.AddWithValue("@HouseholdName", name);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Household created.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateHousehold()
        {
            string updateQuery = "UPDATE Households SET HouseholdName = @NewHouseholdName WHERE ID = @ID;";

            Console.WriteLine("Enter the ID of the household to update:");
            int householdID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the new household name:");
            string newHouseholdName = Console.ReadLine().Trim();

            try
            {
                using MySqlCommand cmd = new(updateQuery, GetInstance());
                cmd.Parameters.AddWithValue("@NewHouseholdName", newHouseholdName);
                cmd.Parameters.AddWithValue("@ID", householdID);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Household updated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteHousehold()
        {
            string checkExistenceSql = "SELECT 1 FROM Households WHERE ID = @ID";

            Console.WriteLine("Enter the ID of the household to delete:");
            int householdID = int.Parse(Console.ReadLine());

            using MySqlCommand checkCmd = new(checkExistenceSql, GetInstance());
            checkCmd.Parameters.AddWithValue("@ID", householdID);


            object result = checkCmd.ExecuteScalar();

            if (result != null)
            {
                string deleteSql = "DELETE FROM Households WHERE ID = @ID";
                using MySqlCommand deleteCmd = new(deleteSql, GetInstance());
                deleteCmd.Parameters.AddWithValue("@ID", householdID);
                deleteCmd.ExecuteNonQuery();

                Console.WriteLine("Household deleted.");
            }
            else
            {
                Console.WriteLine("Household not found in the database.");
            }
        }

        public void GetAllHouseHolds()
        {
            Console.WriteLine("All households in the database:");

            string selectAllQuery = "SELECT * FROM Households;";

            try
            {

                using MySqlCommand cmd = new(selectAllQuery, GetInstance());
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32("ID");
                    string householdName = reader.GetString("HouseholdName");

                    Console.WriteLine($"housenumber: {id}   house name: {householdName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
