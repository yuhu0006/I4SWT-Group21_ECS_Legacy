using NUnit.Framework;

namespace ECS.Test.Unit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase(10)]
        [TestCase(0)]
        [TestCase(-9)]
        public void GetThreshold_Test(int a)
        {
            ECS UUT = new ECS(a,new FakeTempSensor(21), new FakeHeater());
            Assert.That(UUT.GetThreshold(), Is.EqualTo(a));
        }

        [TestCase(43)]
        [TestCase(0)]
        [TestCase(-222)]
        public void GetTemp_Test(int a)
        {
            ECS UUT = new ECS(21, new FakeTempSensor(a), new FakeHeater());
            Assert.That(UUT.GetCurTemp(), Is.EqualTo(a));
        }

        [TestCase(10)]
        [TestCase(0)]
        [TestCase(-9)]
        public void SetThreshold_Test(int a)
        {
            ECS UUT = new ECS(10, new FakeTempSensor(21), new FakeHeater());
            UUT.SetThreshold(a);
            Assert.That(UUT.GetThreshold(), Is.EqualTo(a));
        }

        [Test]
        public void RegulateHigh_Test()
        {
            FakeHeater MyHeater = new FakeHeater();
            ECS UUT = new ECS(10, new FakeTempSensor(21), MyHeater);
            UUT.Regulate();
            Assert.That(MyHeater.TurnOffCalled, Is.EqualTo(true));
        }

        [Test]
        public void RegulateLow_Test()
        {
            FakeHeater MyHeater = new FakeHeater();
            ECS UUT = new ECS(10, new FakeTempSensor(4), MyHeater);
            UUT.Regulate();
            Assert.That(MyHeater.TurnOnCalled, Is.EqualTo(true));
        }

        [Test]
        public void RegulateEqual_Test()
        {
            FakeHeater MyHeater = new FakeHeater();
            ECS UUT = new ECS(10, new FakeTempSensor(10), MyHeater);
            UUT.Regulate();
            Assert.That(MyHeater.TurnOffCalled, Is.EqualTo(true));
        }

        [Test]
        public void RunSelfTest_Test()
        {
            ECS UUT = new ECS(10, new FakeTempSensor(21), new FakeHeater());
            Assert.That(UUT.RunSelfTest(), Is.EqualTo(true));
        }

    }
}