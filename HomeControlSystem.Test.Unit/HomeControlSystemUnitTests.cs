using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HomeControlSystem.Test.Unit
{
    [TestFixture]
    class HomeControlSystemUnitTests
    {
        //member variables to hold uut and fakes
        private FakeTempSensor _fakeTempSensor;
        private FakeHeater _fakeHeater;
        private HomeControl _uut;

        [SetUp]
        public void Setup()
        {
            //creating the fake stubs and mocks
            _fakeHeater = new FakeHeater();
            _fakeTempSensor = new FakeTempSensor();

            //injecting them into the uut via the constructor
            _uut = new HomeControl(_fakeHeater, _fakeTempSensor);
        }

        [Test]
        public void Regulate_TempIsHigh_HeaterIsTurnedOff()
        {
            //Setup Stub with desired response
            _fakeTempSensor.Temp = 30;

            //Act
            _uut.Regulate();

            //Assert on mock, was the heater called correctly
            Assert.That(_fakeHeater.TurnOffCalledTimes, Is.EqualTo(1));
        }

        [Test]
        public void Regulate_TempIsLow_HeaterIsTurnedOn()
        {
            //Setup Stub with desired response
            _fakeTempSensor.Temp = 5;

            //Act
            _uut.Regulate();

            //Assert on mock, was the heater called correctly
            Assert.That(_fakeHeater.TurnOnCalledTimes, Is.EqualTo(1));
        }


        

    }
}