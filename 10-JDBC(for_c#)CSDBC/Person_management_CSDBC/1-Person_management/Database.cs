using MySql.Data.MySqlClient;
namespace _1_Person_management
{
    public class Database
    {//https://learn.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-in-visual-studio
        public static string DBLink = "server=120.0.0.1;User ID=root;Password=;Database=personmanagerdb";
        public static MySqlConnection DBSqlConn = new(DBLink);
        public static void OpenDB()
        {
            MySqlConnection conn;
            try
            {
                conn = new(DBLink);
                conn.Open();
                Console.WriteLine("Connected to the Database.");
                Household.CreateHouseholdsTable();
                PersonManager.CreatePersonsTable();
                PersonManager.CreatePetsTable();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Failed to connect to the Database: " + ex.Message);
                return;
            }
        }
        public static void CloseDB()
        {
            try
            {
                MySqlConnection conn = new(DBLink);
                conn.Close();
                Console.WriteLine("disconnected from Database!");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Failed to connect to the Database: " + ex.Message);
            }
        }
        public sealed class Singleton /* https://refactoring.guru/design-patterns/singleton */
        {
            private static Singleton instance = null;
            private static readonly object padlock = new object();

            Singleton()
            {
            }

            public static Singleton Instance
            {
                get
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                        return instance;
                    }
                }
            }
        }
    }
}