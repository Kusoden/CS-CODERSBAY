using System;
using System.Linq;
using static _1_Person_management.Database;

namespace _1_Person_management
{
    public class LINQHousehold : HouseholdInterface
    {
        public void CreateHouseholdsTable()
        {

        }

        public void CreateHousehold(string householdName)
        {

        }

        public void UpdateHousehold(int householdID, string newHouseholdName)
        {

        }

        public void DeleteHousehold(int householdID)
        {

        }

        public void DisplayHouseholds()
        {/*
            string selectAllQuery = "SELECT * FROM Households;";

            using (MySqlCommand cmd = new(selectAllQuery, GetInstance()))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("ID");
                    string householdName = reader.GetString("HouseholdName");

                    Console.WriteLine($"housenumber: {id}   house name: {householdName}");
                }
            }
*/
            var db = GetInstance();
            var selectAllQuery = from households in db.Households select ;
        }

    }
}
