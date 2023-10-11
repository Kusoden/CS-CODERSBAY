namespace _1_Person_management
{
    public class Address
    {
        public int Plz { get; set; }
        public string Location { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }

        public Address(string streetName, int houseNumber, int plz, string location)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
            Plz = plz;
            Location = location;
        }

        public override string ToString()
        {
            return $"{Plz} {Location} {StreetName} {HouseNumber}";
        }
    }
}