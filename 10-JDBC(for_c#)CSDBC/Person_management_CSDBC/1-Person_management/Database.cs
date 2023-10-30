using MySql.Data.MySqlClient;
namespace _1_Person_management
{
    public class Database
    {//https://learn.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-in-visual-studio
        public static string DBLink = "server=127.0.0.1;User ID=root;Password=;Database=personmanagerdb";
        public static MySqlConnection DBSqlConn = new(DBLink);
        private Database()
        {
        }

        private class Singleton
        {
            internal static readonly Database instance = new();
        }

        public static Database GetInstance()
        {
            return Singleton.instance;
        }

        public void OpenDB()
        {
            try
            {
                DBSqlConn.Open();
                Console.WriteLine("Connected to the Database.");
                Household.CreateHouseholdsTable();
                PersonManager.CreatePersonsTable();
                PersonManager.CreatePetsTable();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Failed to connect to the Database: " + ex.Message);
            }
        }

        public void CloseDB()
        {
            try
            {
                DBSqlConn.Close();
                Console.WriteLine("Disconnected from the Database!");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Failed to connect to the Database: " + ex.Message);
            }
        }

    }
}