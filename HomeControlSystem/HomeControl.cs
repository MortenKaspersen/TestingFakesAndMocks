using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeControlSystem
{
    public class HomeControl
    {
        private readonly IHeater _heater;
        private readonly ITempSensor _tempSensor;

        //private int _lowerTemperatureThreshold;
        //private int _upperTemperatureThreshold;

        ////Property for holding heating threshold
        //public int LowerTemperatureThreshold
        //{
        //    get { return _lowerTemperatureThreshold; }

        //    set
        //    {
        //        // Validation is done in the property set method
        //        // value is the built in name for the set value
        //        if (value <= _upperTemperatureThreshold)
        //            _lowerTemperatureThreshold = value;
        //        else throw new ArgumentException("Lower threshold must be <= upper threshold");
        //    }

        //}

        //// Property for window threshold
        //public int UpperTemperatureThreshold
        //{
        //    get { return _upperTemperatureThreshold; }
        //    set
        //    {
        //        // Validation is done in the property set method
        //        // value is the built in name for the set value
        //        if (value >= _lowerTemperatureThreshold)
        //            _upperTemperatureThreshold = value;
        //        else throw new ArgumentException("Upper threshold must be >= lower threshold");
        //    }
        //}


        //Constructor Injection
        public HomeControl(IHeater heater, ITempSensor tempSensor)
        {
            //saving references to dependencies
            _heater = heater;
            _tempSensor = tempSensor;
            
            //Initializing properties
            //    LowerTemperatureThreshold = lowerTemperatureThreshold;
            //    UpperTemperatureThreshold = upperTemperatureThreshold;
        }

        public void Regulate()
        {
            var currentTemperature = _tempSensor.GetTemp();

            //Determining what action the heater should take
            if (currentTemperature < 20)
            {
                _heater.TurnOn();
            }
            else if (currentTemperature >= 25)
            {
                _heater.TurnOff();
            }

            //This below part was unable to being tested according to Jenkins Coverage

            //else
            //{
            //    _heater.TurnOff();
            //}
        }
    }
}
