using NUnit.Framework;

namespace ECS.Test.Unit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GetThreshold_()
        {
            ECS UUT = new ECS(10,new FakeTempSensor(10), new FakeHeater());
        }
    }
}