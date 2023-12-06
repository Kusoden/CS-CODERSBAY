using MySql.Data.MySqlClient;
using static _1_Person_management.Database;

namespace _1_Person_management
{
    public class Validation
    {
        public bool PersonExists(string firstName, string lastName)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM Persons WHERE FirstName = @FirstName AND LastName = @LastName";
                using MySqlCommand cmd = new(sql, GetInstance());
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Failed to connect to the Database: " + ex.Message);
                return false;
            }
        }

        public bool PersonExists(int ownerID)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM Persons WHERE ID = @ID";
                using MySqlCommand cmd = new(sql, GetInstance());
                cmd.Parameters.AddWithValue("@ID", ownerID);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Failed to connect to the Database: " + ex.Message);
                return false;
            }
        }
    }
}
