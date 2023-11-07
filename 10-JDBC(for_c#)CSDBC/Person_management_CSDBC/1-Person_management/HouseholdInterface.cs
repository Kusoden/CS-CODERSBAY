namespace _1_Person_management
{
    public interface HouseholdInterface
    {
        void CreateHouseholdsTable();
        void CreateHousehold(string householdName);
        void UpdateHousehold(int householdID, string newHouseholdName);
        void DeleteHousehold(int householdID);
        void DisplayHouseholds();
    }
}
