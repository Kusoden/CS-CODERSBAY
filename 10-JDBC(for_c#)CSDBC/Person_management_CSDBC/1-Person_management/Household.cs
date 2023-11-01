using MySql.Data.MySqlClient;
using static _1_Person_management.Database;

namespace _1_Person_management
{
    internal class Household
    {
        public int ID { get; set; }
        public string HouseholdName { get; set; }

        public Household(string householdName)
        {
            HouseholdName = householdName;
        }

        public static void CreateHouseholdsTable()
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
                MySqlCommand cmd = new(createTableQuery, DBSqlConn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Households table created or already exists.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void CreateHousehold(string householdName)
        {
            string insertQuery = "INSERT INTO Households (HouseholdName) VALUES (@HouseholdName);";
            try
            {
                using MySqlCommand cmd = new(insertQuery, DBSqlConn);
                cmd.Parameters.AddWithValue("@HouseholdName", householdName);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Household created.");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateHousehold(int householdID, string newHouseholdName)
        {
            string updateQuery = "UPDATE Households SET HouseholdName = @NewHouseholdName WHERE ID = @ID;";
            try {
            using MySqlCommand cmd = new(updateQuery, DBSqlConn);
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

        public static void DeleteHousehold(int householdID)
        {
            string checkExistenceSql = "SELECT 1 FROM Households WHERE ID = @ID";
            using MySqlCommand checkCmd = new(checkExistenceSql, DBSqlConn);
            checkCmd.Parameters.AddWithValue("@ID", householdID);

            object result = checkCmd.ExecuteScalar();

            if (result != null)
            {
                string deleteSql = "DELETE FROM Households WHERE ID = @ID";
                using MySqlCommand deleteCmd = new(deleteSql, DBSqlConn);
                deleteCmd.Parameters.AddWithValue("@ID", householdID);
                deleteCmd.ExecuteNonQuery();

                Console.WriteLine("Household deleted.");
            }
            else
            {
                Console.WriteLine("Household not found in the database.");
            }
        }


        public static void DisplayHouseholds()
        {
            string selectAllQuery = "SELECT * FROM Households;";

            using (MySqlCommand cmd = new(selectAllQuery, DBSqlConn))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("ID");
                    string householdName = reader.GetString("HouseholdName");

                    Console.WriteLine($"housenumber: {id}   house name: {householdName}");
                }
            }
        }
    }
}
