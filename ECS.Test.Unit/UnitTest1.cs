using NSubstitute;
using NUnit.Framework;

namespace ECS.Test.Unit
{
    public class Tests
    {

	    private IHeater _fakeHeater;
	    private ITempSensor _fakeTempSensor;
	    private ECS _uut;
        [SetUp]
        public void Setup()
        {
	        _fakeHeater = Substitute.For<IHeater>();
	        _fakeTempSensor = Substitute.For<ITempSensor>();

	        _uut = new ECS(25, _fakeTempSensor, _fakeHeater);

        }

        [Test]
        public void GetThreshold_Test()
        {
	        Assert.That(_uut.GetThreshold(), Is.EqualTo(25));
        }

        [TestCase(43)]
        [TestCase(0)]
        [TestCase(-222)]
        public void GetTemp_Test(int a)
        {
	        _fakeTempSensor.GetTemp().Returns(a);
	        Assert.That(_uut.GetCurTemp(), Is.EqualTo(a));
        }

        [TestCase(10)]
        [TestCase(0)]
        [TestCase(-9)]
        public void SetThreshold_Test(int a)
        {
	        _uut.SetThreshold(a);
            Assert.That(_uut.GetThreshold(), Is.EqualTo(a));
        }

        [Test]
        public void RegulateHigh_Test()
        {
	        _fakeTempSensor.GetTemp().Returns(26);
	        _uut.Regulate();
	        _fakeHeater.Received(1).TurnOff();
        }

        [Test]
        public void RegulateLow_Test()
        {
	        _fakeTempSensor.GetTemp().Returns(24);
	        _uut.Regulate();
	        _fakeHeater.Received(1).TurnOn();
        }

        [Test]
        public void RegulateEqual_Test()
        {
	        _fakeTempSensor.GetTemp().Returns(25);
	        _uut.Regulate();
	        _fakeHeater.Received(1).TurnOff();
        }

        [TestCase(false, false, false)]
        [TestCase(false, true, false)]
        [TestCase(true, false, false)]
        [TestCase(true, true, true)]
        public void RunSelfTest_Test(bool hReturn, bool tReturn, bool Result)
        {
	        _fakeTempSensor.RunSelfTest().Returns(tReturn);
	        _fakeHeater.RunSelfTest().Returns(hReturn);
            Assert.That(_uut.RunSelfTest(), Is.EqualTo(Result));
        }

    }
}