namespace _1_Person_management
{
    public class HouseholdConstructor
    {
        public int ID { get; set; }
        public string HouseholdName { get; set; }

        public HouseholdConstructor(string householdName)
        {
            HouseholdName = householdName;
        }
    }
}
