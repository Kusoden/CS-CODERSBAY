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
            try { 
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

            using MySqlCommand cmd = new(insertQuery, DBSqlConn);
            cmd.Parameters.AddWithValue("@HouseholdName", householdName);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Household created.");
        }

        public static void UpdateHousehold(int householdID, string newHouseholdName)
        {
            string updateQuery = "UPDATE Households SET HouseholdName = @NewHouseholdName WHERE ID = @ID;";

            using (MySqlCommand cmd = new(updateQuery, DBSqlConn))
            {
                cmd.Parameters.AddWithValue("@NewHouseholdName", newHouseholdName);
                cmd.Parameters.AddWithValue("@ID", householdID);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Household updated.");
            }
        }

        public static void DeleteHousehold(int householdID)
        {
            string deleteQuery = "DELETE FROM Households WHERE ID = @ID;";

            using (MySqlCommand cmd = new(deleteQuery, DBSqlConn))
            {
                cmd.Parameters.AddWithValue("@ID", householdID);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Household deleted.");
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

                    Console.WriteLine($"{id} {householdName}");
                }
            }
        }
        /*        public static List<Household> DisplayHouseholds(MySqlConnection connection)
                {
                    connection.Open();
                    string selectAllQuery = "SELECT * FROM Households;";
                    List<Household> households = new();

                    using (MySqlCommand cmd = new(selectAllQuery, connection))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            households.Add(new Household
                            {

                                ID = reader.GetInt32("ID"),
                                HouseholdName = reader.GetString("HouseholdName")
                            });
                        }
                    }
                    connection.Close();
                    return households;
                }*/
    }
}
