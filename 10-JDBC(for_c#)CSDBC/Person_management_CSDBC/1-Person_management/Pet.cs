namespace _1_Person_management
{
    public class Pet
    {
        public int ID { get; set; }
        public string PetName { get; set; }
        public int OwnerID { get; set; }

        public Pet(int id, string petName, int ownerID)
        {
            ID = id;
            PetName = petName;
            OwnerID = ownerID;
        }
    }
}
