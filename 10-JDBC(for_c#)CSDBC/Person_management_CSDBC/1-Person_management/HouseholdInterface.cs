namespace _1_Person_management
{
    public interface HouseholdInterface
    {
        void CreateHouseholdsTable();
        void CreateHousehold(string name);
        void UpdateHousehold(string[] updateData);
        void DeleteHousehold(int deleteData);
        void GetAllHouseHolds();
    }
}
