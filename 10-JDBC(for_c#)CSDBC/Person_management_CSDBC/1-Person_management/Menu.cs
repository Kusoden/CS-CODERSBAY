namespace _1_Person_management
{
    public class Menu
    {
        public int MainMenu()
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create a household");
            Console.WriteLine("2. Display all households");
            Console.WriteLine("3. Update Household");
            Console.WriteLine("4. Delete Household");
            Console.WriteLine("5. Add a person");
            Console.WriteLine("6. Display all persons");
            Console.WriteLine("7. Update a person");
            Console.WriteLine("8. delete a person");
            Console.WriteLine("9. Create a pet");
            Console.WriteLine("10. Display all pets");
            Console.WriteLine("11. Update Pet");
            Console.WriteLine("12. Delete Pet");
            Console.WriteLine("13. Exit");

            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }

        public string GetHouseHoldName()
        {
            Console.WriteLine("Enter the household name:");
            string householdName = Console.ReadLine().Trim();
            return householdName;
        }

        public void AllHouseholds()
        {
            Console.WriteLine("All households in the database:");
        }
    }
}
