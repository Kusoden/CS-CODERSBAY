using MySql.Data.MySqlClient;
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
                Household.CreateHouseholdsTable(conn);
                PersonManager.CreatePersonsTable(conn);
                PersonManager.CreatePetsTable(conn);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Failed to connect to the Database: " + ex.Message);
            }
        }

    }
}