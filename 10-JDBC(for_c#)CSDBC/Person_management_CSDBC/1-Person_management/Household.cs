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
            connection.Open();
            string insertQuery = "INSERT INTO Households (HouseholdName) VALUES (@HouseholdName);";

            using (MySqlCommand cmd = new(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@HouseholdName", householdName);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Household created.");
            }
            connection.Close();
        }

        public static Household ReadHousehold(MySqlConnection connection, int householdID)
        {
            connection.Open();
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
            connection.Close();
            return null;

        }

        public static void UpdateHousehold(MySqlConnection connection, int householdID, string newHouseholdName)
        {
            connection.Open();
            string updateQuery = "UPDATE Households SET HouseholdName = @NewHouseholdName WHERE ID = @ID;";

            using (MySqlCommand cmd = new(updateQuery, connection))
            {
                cmd.Parameters.AddWithValue("@NewHouseholdName", newHouseholdName);
                cmd.Parameters.AddWithValue("@ID", householdID);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Household updated.");
            }
            connection.Close();
        }

        public static void DeleteHousehold(MySqlConnection connection, int householdID)
        {
            connection.Open();
            string deleteQuery = "DELETE FROM Households WHERE ID = @ID;";

            using (MySqlCommand cmd = new(deleteQuery, connection))
            {
                cmd.Parameters.AddWithValue("@ID", householdID);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Household deleted.");
            }
            connection.Close();
        }

        public static List<Household> DisplayHouseholds(MySqlConnection connection)
        {
            connection.Open();
            string selectAllQuery = "SELECT * FROM Households;";
            List<Household> households = new List<Household>();

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
        }
    }
}
