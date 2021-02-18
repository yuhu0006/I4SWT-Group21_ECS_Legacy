using System;

namespace ECS
{
    internal class TempSensor : ITempSensor
    {
        private readonly Random gen = new Random();

        public int GetTemp()
        {
            return gen.Next(-5, 45);
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}