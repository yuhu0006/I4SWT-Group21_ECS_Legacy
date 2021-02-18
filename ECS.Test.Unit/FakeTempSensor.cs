using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Test.Unit
{
    public class FakeTempSensor : ITempSensor
    {
        private int _temp;
        public FakeTempSensor(int temp)
        {
            _temp = temp;
        }
        public int GetTemp()
        {
            return _temp;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}
