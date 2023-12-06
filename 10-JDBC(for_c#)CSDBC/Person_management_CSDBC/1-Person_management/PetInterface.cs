namespace _1_Person_management
{
    public interface PetInterface
    {
        void CreatePetsTable();
        void CreatePet(string[] createData);
        void DisplayPets();
        void UpdatePet(string[] updateData);
        void DeletePet(int deleteData);
    }
}
