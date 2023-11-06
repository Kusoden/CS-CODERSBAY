namespace _1_Person_management
{
    public class Household
    {
        public int ID { get; set; }
        public string HouseholdName { get; set; }

        public Household(string householdName)
        {
            HouseholdName = householdName;
        }
    }
}
