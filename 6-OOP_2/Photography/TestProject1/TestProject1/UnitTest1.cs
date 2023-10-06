using Photography;

namespace TestProject1
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
            Lens fisheye = new(100, 1001);
            Camera CameraS = new("Sony", 155, 1010, true, fisheye);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}