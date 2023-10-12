﻿using System;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace _1_Person_management
{
    internal class Database
    {//https://learn.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-in-visual-studio
        public static void CallDB()/* Project -> Manage NuGet Packages*/
        {
            MySqlConnection conn;
            string myConnectionString = "server=127.0.0.1;User ID=root;Password=;Database=personmanagerdb";

            try
            {
                conn = new MySqlConnection(myConnectionString);
                conn.Open();
                Console.WriteLine("Connected to the Database.");
                CreatePersonsTable(conn);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Failed to connect to the Database: " + ex.Message);
            }
        }


        public static void InsertPerson(MySqlConnection connection, string firstName, string lastName)
        {
            string insertQuery = "INSERT INTO Persons (FirstName, LastName) VALUES (@FirstName, @LastName);";

            MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);

            cmd.ExecuteNonQuery();
        }

        public static void CreatePersonsTable(MySqlConnection connection)
        {
            string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS Persons (
                ID INT NOT NULL AUTO_INCREMENT,
                FirstName VARCHAR(255) NOT NULL,
                LastName VARCHAR(255) NOT NULL,
                Birthday DATE,
                Address VARCHAR(255),
                Gender VARCHAR(10),
                PRIMARY KEY (ID)
            );
            ";

            MySqlCommand cmd = new MySqlCommand(createTableQuery, connection);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Persons table created or already exists.");

            // Add the test query
            string testQuery = "SELECT 1";
            MySqlCommand testCmd = new (testQuery, connection);
            int result = (int)testCmd.ExecuteScalar();
            Console.WriteLine("Test query result: " + result);

        }


    }
}