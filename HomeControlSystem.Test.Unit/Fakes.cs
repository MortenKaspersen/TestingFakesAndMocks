using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeControlSystem.Test.Unit
{
    internal class FakeHeater : IHeater
    {
        public int TurnOffCalledTimes { get; set; }
        public int TurnOnCalledTimes { get; set; }

        public FakeHeater()
        {
            TurnOnCalledTimes = 0;
            TurnOffCalledTimes = 0;
        }

        //Implementing TurnOn();
        public void TurnOn()
        {
            ++TurnOnCalledTimes;
        }

        //Implementing TurnOff();
        public void TurnOff()
        {
            ++TurnOffCalledTimes;
        }
        
    }

    internal class FakeTempSensor : ITempSensor
    {
        public int Temp { get; set; }

        public FakeTempSensor()
        {
            Temp = 0;
        }

        public int GetTemp()
        {
            return Temp;
        }

    }






}
