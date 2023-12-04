namespace _1_Person_management
{
    public class PetConstructor
    {
        public int ID { get; set; }
        public string PetName { get; set; }
        public int OwnerID { get; set; }

        public PetConstructor(int id, string petName, int ownerID)
        {
            ID = id;
            PetName = petName;
            OwnerID = ownerID;
        }
    }
}
