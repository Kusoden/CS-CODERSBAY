
using _1_Person_management;

namespace PersonManagement_Test;

public class UnitTest1
{
    [Fact]
    public void DisplayAllPersons()
    {
        Address address1 = new("kaplanstr", 1, 4020, "Linz");

        PersonManager magi = new();

        Exception ex = Assert.Throws<NullReferenceException>(() => magi.DisplayAllPersons()); /*Verify outofrange exception*/
        Assert.Equal("it's Empty!", ex.Message);
    }
}