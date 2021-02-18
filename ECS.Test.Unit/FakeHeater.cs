using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Test.Unit
{
    public class FakeHeater : IHeater
    {
        public bool TurnOffCalled { get; private set; } = false;
        public bool TurnOnCalled { get; private set; } = false;

        public bool RunSelfTest()
        {
            return true;
        }

        public void TurnOff()
        {
            Console.WriteLine("FakeHeater turned off");
            TurnOffCalled = true;
        }

        public void TurnOn()
        {
            Console.WriteLine("FakeHeater turned on");
            TurnOnCalled = true;
        }
    }
}
