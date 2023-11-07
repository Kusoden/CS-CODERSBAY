namespace _1_Person_management
{
    public interface PetInterface
    {
        void CreatePetsTable();
        void CreatePet(string petName, int ownerID);
        void DisplayPets();
        void UpdatePet(int petID, string newPetName);
        void DeletePet(int petID);
    }
}
