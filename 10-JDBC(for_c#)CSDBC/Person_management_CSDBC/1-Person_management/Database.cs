using MySql.Data.MySqlClient;
namespace _1_Person_management
{
    public class Database
    {//https://learn.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-in-visual-studio
        public static string DBLink = "server=127.0.0.1;User ID=root;Password=;Database=personmanagerdb";
        public static MySqlConnection DBSqlConn = new(DBLink);
/*        public Database()
        {
        }
*/
        public static MySqlConnection GetInstance()
        {
            if (DBSqlConn == null)
            {
                DBSqlConn = new(DBLink);
            } else if (DBSqlConn.State == System.Data.ConnectionState.Broken)
            {
                DBSqlConn.Close();
            }
            if (DBSqlConn.State == System.Data.ConnectionState.Closed)
            {
                DBSqlConn.Open();
            }
            return DBSqlConn;
        }

        public void CloseDB()
        {

            Console.WriteLine("Exiting the program...");
            try
            {
                DBSqlConn.Close();
                Console.WriteLine("Disconnected from the Da  tabase!");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Failed to connect to the Database: " + ex.Message);
            }
        }

    }
}