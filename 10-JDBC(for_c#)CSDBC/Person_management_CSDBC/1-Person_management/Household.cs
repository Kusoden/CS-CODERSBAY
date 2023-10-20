using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace _1_Person_management
{
    internal class Household
    {
        public int ID { get; set; }
        public string HouseholdName { get; set; }

        public Household()
        {
        }

        public Household(string householdName)
        {
            HouseholdName = householdName;
        }

        public static void CreateHouseholdsTable(MySqlConnection connection)
        {
            string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Households (
                    ID INT NOT NULL AUTO_INCREMENT,
                    HouseholdName VARCHAR(255) NOT NULL,
                    PRIMARY KEY (ID)
                );
            ";

            MySqlCommand cmd = new(createTableQuery, connection);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Households table created or already exists.");
        }


        public static void CreateHousehold(MySqlConnection connection, string householdName)
        {
            string insertQuery = "INSERT INTO Households (HouseholdName) VALUES (@HouseholdName);";

            using (MySqlCommand cmd = new(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@HouseholdName", householdName);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Household created.");
            }
        }

        public static Household ReadHousehold(MySqlConnection connection, int householdID)
        {
            string selectQuery = "SELECT * FROM Households WHERE ID = @ID;";
            using (MySqlCommand cmd = new(selectQuery, connection))
            {
                cmd.Parameters.AddWithValue("@ID", householdID);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Household
                        {
                            ID = reader.GetInt32("ID"),
                            HouseholdName = reader.GetString("HouseholdName")
                        };
                    }
                }
            }
            return null;
        }

        public static void UpdateHousehold(MySqlConnection connection, int householdID, string newHouseholdName)
        {
            string updateQuery = "UPDATE Households SET HouseholdName = @NewHouseholdName WHERE ID = @ID;";

            using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
            {
                cmd.Parameters.AddWithValue("@NewHouseholdName", newHouseholdName);
                cmd.Parameters.AddWithValue("@ID", householdID);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Household updated.");
            }
        }

        public static void DeleteHousehold(MySqlConnection connection, int householdID)
        {
            string deleteQuery = "DELETE FROM Households WHERE ID = @ID;";

            using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
            {
                cmd.Parameters.AddWithValue("@ID", householdID);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Household deleted.");
            }
        }

        public static List<Household> GetAllHouseholds(MySqlConnection connection)
        {
            string selectAllQuery = "SELECT * FROM Households;";
            List<Household> households = new List<Household>();

            using (MySqlCommand cmd = new MySqlCommand(selectAllQuery, connection))
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

            return households;
        }
    }
}
